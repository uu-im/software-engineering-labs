using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using Common;
using System.Threading;

namespace Assignment2Chat
{
    /// <summary>
    /// Simple test class for the client side of the chat system
    /// </summary>
    public partial class Form1 : Form
    {
        Socket socket = null;
        Thread _thread = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to the local host (127.0.0.1)
                byte[] serverIP = { 127, 0, 0, 1 };

                IPAddress serverAddress = new IPAddress(serverIP);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                socket.Connect(serverAddress, 5000);

                // Get nickname from text box and send it to server as array of bytes
                String requestedNickname = txtNickname.Text;
                byte[] message = ConversionUtils.StringToByteArray(requestedNickname);
                socket.Send(message);

                byte[] buffer = new byte[1024];
                int byteCount = socket.Receive(buffer);
                String S = ConversionUtils.ByteArrayToString(buffer, 0, byteCount);
                lstChat.Items.Add("Server: " + S);

                if (S.CompareTo("OK") == 0)
                {
                    // Start listening...
                    _thread = new Thread(new ThreadStart(this.Listen));
                    _thread.Start();
                }
                else
                {
                    MessageBox.Show("Did not get OK status from server");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while trying to connect to server");
            }
        }

        public void Listen()
        {
            byte[] buffer = new byte[1024];
            int byteCount;
            do
            {
                byteCount = socket.Receive(buffer);
                String incomingMessage = ConversionUtils.ByteArrayToString(buffer, 0, byteCount);

                    if (lstChat.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lstChat.Items.Add(incomingMessage);
                        }));
                    }
                    else
                        lstChat.Items.Add(incomingMessage);
            }
            while (true);
        }

        private void btnSendmessage_Click(object sender, EventArgs e)
        {
            if (socket != null)
            {
                String message = txtMessage.Text;
                socket.Send(ConversionUtils.StringToByteArray(message));
            }
            else
                MessageBox.Show("You are not connected to the server...");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
