﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using PAymentForServices.BusinessLogic.Services;
using PAymentForServices.Common.Enums;
using PAymentForServices.Common.Server;
using PAymentForServices.Service.Handler;
using PAymentForServices.Service.Services;

namespace PAymentForServices.Service
{
    public class ClientConnection
    {
        private TcpClient _tcpClient;
        private readonly IAccountService _accountService;
        private readonly IMethodService _methodService;

        public ClientConnection(TcpClient tcpClient,IAccountService accountService, IMethodService methodService)
        {
            _tcpClient = tcpClient;
            _accountService = accountService;
            _methodService = methodService;
        }

        public void Process()
        {
            NetworkStream stream = null;

            try
            {
                //Получение сетевого потока
                stream = _tcpClient.GetStream();

                byte[] buffer = new byte[_tcpClient.ReceiveBufferSize];

                StringBuilder response = new StringBuilder();
                int bytes = default;

                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    response.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (stream.DataAvailable);

                string json = response.ToString();

                var query = JsonSerializer.Deserialize<ServerQuery>(json);

                json = MethodHandler.SearchMethod(query,_methodService);

                buffer = Encoding.Unicode.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length);

            }

            catch (Exception ex) { Console.WriteLine("Error: "+ex.Message); }

            finally
            {
                if (stream != null)
                    stream.Close();

                if (_tcpClient != null)
                    _tcpClient.Close();
            }
        }

        
    }
}
