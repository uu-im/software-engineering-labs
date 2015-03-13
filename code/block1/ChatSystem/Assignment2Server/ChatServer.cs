using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using Common;
using System.Windows.Forms;

namespace Assignment2Server
{
    public class ChatServer
    {
        IPAddress _localIP;
        int _listeningPort;
        Thread serverThread = null;
        IServerObserver _ui = null;
        List<Client> clients = null;

        public ChatServer(IPAddress localIP, int listeningPort, IServerObserver ui)
        {
            _localIP = localIP;
            _listeningPort = listeningPort;
            _ui = ui;
            clients = new List<Client>();
        }

        public void StopServer()
        {
            // Stop all threads
            //serverThread.Abort();
            foreach (Client c in clients)
                c.Stop();

            serverThread.Abort();
            Application.Exit();
        }

        public void StartServer()
        {
            try
            {
                serverThread = new Thread(new ThreadStart(Listen));
                serverThread.Start();
            }
            catch (Exception ex)
            {
                throw new ServerStartException("Error while starting server.", ex);
            }
        }

        public Boolean ServerRunning
        {
            get
            {
                return (serverThread != null);
            }
        }

        public void BroadcastMessage(String nickname, String message)
        {
            foreach (Client c in clients)
            {
                c.Send(nickname + ": " + message);
            }

            _ui.NewMessage(nickname, message);
        }

        public void BroadcastMessage(String message)
        {
            foreach (Client c in clients)
            {
                c.Send(message);
            }
        }

        public void RemoveClient(String nickname)
        {
            String message = nickname + " left the chat.";

            Client c = getClient(nickname);
            clients.Remove(c);

            BroadcastMessage(message);
            _ui.ClientDisappeared(nickname);
        }

        /// <summary>
        /// Checks if a nickname is already in use
        /// </summary>
        /// <param name="nickname">nickname to check</param>
        /// <returns>true if not in use, false if in use</returns>
        public Client getClient(String nickname)
        {
            foreach(Client c in clients)
                if (c.Nickname.ToLower().CompareTo(nickname.ToLower()) == 0)
                {
                    return c;
                }
            return null;
        }

        /// <summary>
        /// This function is started in its own thread.
        /// It's an eternal loop that listens for connection requests
        /// from clients, and sets up these connections upon request.
        /// </summary>
        void Listen()
        {
            TcpListener listener = new TcpListener(_localIP, _listeningPort);
            listener.Start();

            while (true)
            {
                try
                {
                    // Wait for a connection
                    Socket clientsocket = listener.AcceptSocket();

                    try {
                        byte[] buffer = new byte[1024];
                        int messagesize = 0;
                    
                        // Wait for data (username)
                        messagesize = clientsocket.Receive(buffer);
                        String requestedNickname = ConversionUtils.ByteArrayToString(buffer,0,messagesize);

                        if (getClient(requestedNickname) == null) // nickname is ok
                        {
                            Client newClient = new Client(requestedNickname, clientsocket, this);
                            clients.Add(newClient);
                            _ui.ClientAppeared(requestedNickname);
                            newClient.Start();
                            newClient.Send("OK");
                            BroadcastMessage(newClient.Nickname + " entered the chat.");
                        }
                        else
                        {
                            clientsocket.Send(ConversionUtils.StringToByteArray("ERROR: User name already taken"));
                        }
                    }
                    catch {
                        clientsocket.Send( ConversionUtils.StringToByteArray("ERROR: Server error"));
                    }
                }
                catch (Exception ex)
                {
                    BroadcastMessage("Internal server error");
                }
            }
        }
    }
}
