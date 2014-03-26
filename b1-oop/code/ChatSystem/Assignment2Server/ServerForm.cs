using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Assignment2Server
{
    public partial class ServerForm : Form, IServerObserver
    {
        ChatServer server=null;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            byte[] ip = { 127, 0, 0 , 1};

            IPAddress myIP = new IPAddress( ip );

            server = new ChatServer(myIP, 5000, this);
            server.StartServer();

            if (server.ServerRunning)
                lblStatus.Text = "Server is running";
            else
                lblStatus.Text = "Server is not running";
            //MessageBox.Show(server.ServerRunning.ToString());
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                server.StopServer();
        }

        public void ClientAppeared(String nickname)
        {
            if (lstClients.InvokeRequired)
                lstClients.Invoke(new Action<string>(ClientAppeared), new object[]{ nickname });
            else
                lstClients.Items.Add(nickname + " entered the chat.");
        }

        public void ClientDisappeared(String nickname)
        {
            if (lstClients.InvokeRequired)
                lstClients.Invoke(new Action<string>(ClientDisappeared), new object[] { nickname });
            else
                lstClients.Items.Add(nickname + " left the chat.");
        }

        public void NewMessage(String nickname, String message)
        {
            if (lstClients.InvokeRequired)
                lstClients.Invoke(new Action<string, string>(NewMessage), new object[] { nickname, message });
            else
                lstClients.Items.Add(nickname + ": " + message);
        }
    }
}
