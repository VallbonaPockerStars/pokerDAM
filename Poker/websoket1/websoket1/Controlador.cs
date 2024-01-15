using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consumidor.Vista;

namespace Consumidor
{
    class Controlador
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        ClientWebSocket socket = new ClientWebSocket();

        new Form1 f = new Form1();

        public Controlador()
        {
            InitListeners();
            LoadData();
            Application.Run(f);
        }

        public void InitListeners()
        {
            f.button1_Conectar.Click += Button2_Click;

            f.button2_Enviar.Click += Enviar;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (f.button1_Conectar.Text == "Connectar")
            {
                Connectar();
            }
            else if (f.button1_Conectar.Text == "Desconectar")
            {
                desconectar();
            }
        }

        public void LoadData()
        {
            f.button1_Conectar.Text = "Connectar";
            f.button1_Conectar.ForeColor = Color.Green;

        }

        public async void Connectar()
        {
            //Nombre
            string url = f.textBox1_URL.Text;

            //Url
            string nom = f.textBox2_Nom.Text;

            string wsUri = $"wss://localhost:{url}/api/websocket?nom={nom}";
            string conect = $"S'ha conectat -> {nom}";
            f.listBox1.Items.Add(conect);
            await socket.ConnectAsync(new Uri(wsUri), cts.Token);
            var buffer = new byte[256];


            if (socket.State == WebSocketState.Open)
            {
                await Task.Factory.StartNew(
                    async () =>
                    {
                        var rcvBytes = new byte[256];
                        var rcvBuffer = new ArraySegment<byte>(rcvBytes);
                        while (true)
                        {
                            WebSocketReceiveResult rcvResult = await socket.ReceiveAsync(rcvBuffer, cts.Token);
                            if (rcvResult.MessageType == WebSocketMessageType.Close)
                            {
                                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                            }
                            else
                            {
                                byte[] msgBytes = rcvBuffer.Skip(rcvBuffer.Offset).Take(rcvResult.Count).ToArray();
                                string rcvMsg = Encoding.UTF8.GetString(msgBytes);
                                f.listBox1.Items.Add(rcvMsg);
                            }

                        }
                    }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

                f.button1_Conectar.Text = "Desconectar";
                f.button1_Conectar.ForeColor = Color.Red;
            }
        }

        public async void Enviar(object sender, EventArgs e)
        {
            string mensaje = f.textBox3_Textoo.Text;
            if (mensaje == "Adeu")
            {
                cts.Cancel();
                f.Dispose();
                return;
            }
            byte[] sendBytes = Encoding.UTF8.GetBytes(mensaje);
            var sendBuffer = new ArraySegment<byte>(sendBytes);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
          
        }

        public void desconectar()
        {
            cts.Cancel();
            f.Dispose();
        }
    }
}
