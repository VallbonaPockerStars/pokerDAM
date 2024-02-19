using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebSocket1.Models;

namespace WebSocket1.Controllers
{
    public class WebSocketController : ApiController
    {
       public static Baraja baraja = new Baraja();

        public HttpResponseMessage Get(string nom)
        {
            HttpContext.Current.AcceptWebSocketRequest(new SocketHandler(nom)); 
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private class SocketHandler : WebSocketHandler
        {

            private static readonly WebSocketCollection Sockets = new WebSocketCollection();
            private static List<WebSocketHandler> Sockets2 = new List<WebSocketHandler>();

            private readonly string _nom;

            public SocketHandler(string nom)
            {
                _nom = nom;
            }


            public override void OnOpen()
            {
                Sockets2.Add(this);

                if (Sockets2.Count >= 2)
                {
                    EnviarCartas();
                }
                else
                {
                    foreach (var socket in Sockets2)
                    {
                        socket.Send("Falta un jugador para comenzar el juego");
                    }

                    while (Sockets2.Count < 2)
                    {
                        
                    }
                    EnviarCartas();
                }
            }

            private void EnviarCartas()
            {
                Random random = new Random();

                List<string> mano = new List<string>();
                for (int i = 0; i < 2; i++)
                {
                    mano.Add(ObtenerCartaAleatoria(random));
                }

                string mensaje = "Tu mano de poker: ";
                Send(mensaje);

                foreach (var carta in mano)
                {
                    Send(carta);
                }

                EnviarCarta(random);

            }

            private void EnviarCarta(Random random)
            {
                Task.Run(async () =>
                {
                    bool ganador = false;
                    while (!ganador)
                    {
                        await Task.Delay(5000);

                        string carta = ObtenerCartaAleatoria(random);
                        foreach (var socket in Sockets2)
                        {
                            if (_nom == "ganador")
                            {
                                ganador = true;
                            }
                            socket.Send(carta);
                        }
                    }
                });
            }


            private string ObtenerCartaAleatoria(Random random)
            {
                int index = random.Next(0, baraja.LongitudBaraja());
                Carta carta = baraja.QuitarCarta(index);
                while (carta == null)
                {
                    index = random.Next(0, baraja.LongitudBaraja());
                    carta = baraja.QuitarCarta(index);
                }

                if (carta.carta.Equals("\U0001F0A0"))
                {
                    return ObtenerCartaAleatoria(random);
                }
                else
                {
                    return carta.carta;
                }
            }

            public override void OnMessage(string mensaje)
            {
                if (mensaje == "Capturada")
                {
                    EnviarCarta(new Random());
                }
                else
                {
                    foreach (var socket in Sockets2)
                    {
                        socket.Send(_nom + ": " + mensaje);
                    }
                }              
            }

            public override void OnClose()
            {
                Sockets2.Remove(this);
                Send(": " + "Desconectado");
            }
        }
    }
}
