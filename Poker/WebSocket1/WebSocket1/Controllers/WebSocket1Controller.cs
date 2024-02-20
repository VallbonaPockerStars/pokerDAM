using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebSocket1.Controllers
{
    public class WebSocketController : ApiController
    {
        public HttpResponseMessage Get(string nom)
        {
            // La crida al websocket serà del tipus   ws://host:port/api/websocket?nom=Pere

            HttpContext.Current.AcceptWebSocketRequest(new SocketHandler(nom)); return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
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
                // Cuando un nuevo usuario se conecta: agregar el SocketHandler a la colección, notificar a todos la incorporación y darle la bienvenida
                Sockets2.Add(this);
                Send(": " + "Conectado");
            }

            public override void OnMessage(string mensaje)
            {
                // Cuando un usuario envía un mensaje, asegurarse de que todos lo reciban
                foreach (var socket in Sockets2)
                {
                    socket.Send(_nom+ ": " + mensaje);
                }
            }

            public override void OnClose()
            {
                // Cuando un usuario se desconecta, despedirlo, eliminar el SocketHandler de la colección y notificar a los demás que se ha ido
                Sockets2.Remove(this);
                Send(": " + "Desconectado");
            }
        }
    }
}
