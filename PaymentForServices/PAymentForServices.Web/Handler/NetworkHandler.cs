using System;
using System.Net.Sockets;
using System.Text;

namespace PAymentForServices.Web.Handler
{
    public static class NetworkHandler
    {
        public static string ConnectionWithServ(string query)
        {
            TcpClient? client = null;

            var configuration = WebApplication.CreateBuilder().Configuration;
           
            string IP = configuration["IP"];
            int PORT = Convert.ToInt32(configuration["PORT"]);

            try
            {
                client = new TcpClient(IP, PORT);
                NetworkStream stream = client.GetStream();

                byte[] buffer = Encoding.Unicode.GetBytes(query);

                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

                buffer = new byte[client.ReceiveBufferSize];
                int bytes = default;

                StringBuilder response = new StringBuilder();
                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    response.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (stream.DataAvailable);

                return response.ToString();
            }

            catch (Exception ex) { Console.WriteLine(ex.Message); }

            finally
            {
                if (client !is null)
                    client!.Close();
            }

            throw new Exception("Ошибка при подключении к серверу");
        }
    }
}

