using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consumidor;

namespace Consuimidor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // new Program().Start().Wait();
           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Controlador();
        }

        //public async Task Start()
        //{
            
        //    Console.Title = "Client";
        //    Console.Write("Introdueix el Nom ");
        //    var nom = Console.ReadLine();

        //    Console.Write("Connectant....");
        //    var cts = new CancellationTokenSource();
        //    var socket = new ClientWebSocket();

        //    string wsUri = "wss://localhost:44330/api/websocket?nom="+nom+"";
        //    await socket.ConnectAsync(new Uri(wsUri), cts.Token);
        //    Console.WriteLine(socket.State);

        //    var buffer = new byte[256];
        //    if (socket.State == WebSocketState.Open)
        //    {
                
        //        await Task.Factory.StartNew(
        //            async () =>
        //            {
                        
        //                var rcvBytes = new byte[256];
        //                var rcvBuffer = new ArraySegment<byte>(rcvBytes);
        //                while (true)
        //                {
                            
        //                    WebSocketReceiveResult rcvResult = await socket.ReceiveAsync(rcvBuffer, cts.Token);
        //                    if (rcvResult.MessageType == WebSocketMessageType.Close)
        //                    {
                                
        //                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        //                    }
        //                    else
        //                    {
        //                        byte[] msgBytes = rcvBuffer.Skip(rcvBuffer.Offset).Take(rcvResult.Count).ToArray();
        //                        string rcvMsg = Encoding.UTF8.GetString(msgBytes);
        //                        Console.WriteLine(nom+rcvMsg);
        //                    }
        //                }
        //            }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

        //        while (true)
        //        {
        //            string missatge = Console.ReadLine();
        //            if (missatge == "Adeu")
        //            {
        //                cts.Cancel();
        //                return;
        //            }
        //            byte[] sendBytes = Encoding.UTF8.GetBytes(missatge);
        //            var sendBuffer = new ArraySegment<byte>(sendBytes);
        //            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cts.Token);
        //        }
        //    }
        //}
    }
}