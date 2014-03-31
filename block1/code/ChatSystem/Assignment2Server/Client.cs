using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Common;

namespace Assignment2Server
{
    public class Client
    {
        private string _nickname;
        private Socket _socket;
        private Thread _thread;
        private ChatServer _server;

        public Client(string nickname, Socket socket, ChatServer server)
        {
            _nickname = nickname;
            _socket = socket;
            _server = server;
        }

        public String Nickname
        {
            get
            {
                return _nickname;
            }
        }

        public void Start()
        {
            _thread = new Thread(new ThreadStart(ListeningLoop));
            _thread.Start();
        }

        public void Stop()
        {
            _thread.Abort();
        }

        public void Send(String message)
        {
            _socket.Send(ConversionUtils.StringToByteArray(message));
        }

        public void ListeningLoop()
        {
            byte[] buffer = new byte[1024];
            int byteCount;
            bool running = true;

            do
            {
                try
                {
                    byteCount = _socket.Receive(buffer);
                    String incomingMessage = ConversionUtils.ByteArrayToString(buffer, 0, byteCount);
                    _server.BroadcastMessage(_nickname, incomingMessage);
                }
                catch (Exception ex)
                {
                    _server.RemoveClient(_nickname);
                    running = false;
                }
            }
            while (running);
        }
    }
}