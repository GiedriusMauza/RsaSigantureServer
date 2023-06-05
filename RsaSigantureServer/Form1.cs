using System.Net.Sockets;
using System.Net;
using System.Text;

namespace RsaSigantureServer
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void startServerbtn_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            infoTextBox.Text = "Server running...\n";
            IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, 11_000);


            using Socket listener = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(100);


            while (true)
            {
                var handler = await listener.AcceptAsync();
                await Task.Run(async () =>
                {
                    try
                    {
                        while (true)
                        {
                            // Receive message.
                            var buffer = new byte[1_024];
                            var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                            var response = Encoding.UTF8.GetString(buffer, 0, received);

                            var eom = "<|EOM|>";
                            if (response.IndexOf(eom) > -1 /* is end of message */)
                            {

                                if (response.Replace(eom, "").StartsWith("M@"))
                                {
                                    messsageTextBox.Text = response.Replace(eom, "").Replace("M@", "");
                                }
                                else if (response.Replace(eom, "").StartsWith("K@"))
                                {
                                    keyTextBox.Text = response.Replace(eom, "").Replace("K@", "");
                                }
                                else if (response.Replace(eom, "").StartsWith("S@"))
                                {
                                    signatureTextBox.Text = response.Replace(eom, "").Replace("S@", "");
                                }
                                infoTextBox.Text += $"Socket server received message: \"{response.Replace(eom, "")}\"\n";

                                var ackMessage = "<|ACK|>";
                                var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                                await handler.SendAsync(echoBytes, 0);
                                infoTextBox.Text += $"Socket server sent acknowledgment: \"{ackMessage}\"\n";

                                if (response.Replace(eom, "").StartsWith("S@"))
                                {
                                    cts.Cancel();
                                    infoTextBox.Text += "Stopping server...\n";
                                }
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        infoTextBox.Text += ex.Message;
                    }

                    finally
                    {
                        handler.Dispose();
                    }
                }, cts.Token);
            }
        }


        private async void sendBtn_Click(object sender, EventArgs e)
        {
            using Socket client = await SendMessage("M@" + messsageTextBox.Text);
            using Socket client3 = await SendMessage("K@" + keyTextBox.Text);
            using Socket client4 = await SendMessage("S@" + signatureTextBox.Text);
        }

        private async Task<Socket> SendMessage(String messageText)
        {
            IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, 11_000);
            Socket client = new(
                                    ipEndPoint.AddressFamily,
                                    SocketType.Stream,
                                    ProtocolType.Tcp);

            await client.ConnectAsync(ipEndPoint);
            while (true)
            {
                // Send message.
                var message = messageText + "<|EOM|>";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await client.SendAsync(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: \"{message}\"");

                // Receive ack.
                var buffer = new byte[1_024];
                var received = await client.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.WriteLine(
                        $"Socket client received acknowledgment: \"{response}\"");
                    break;
                }
                // Sample output:
                //     Socket client sent message: "Hi friends 👋!<|EOM|>"
                //     Socket client received acknowledgment: "<|ACK|>"
            }

            client.Shutdown(SocketShutdown.Both);
            return client;
        }
    }
}