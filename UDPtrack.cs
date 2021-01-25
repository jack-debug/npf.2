using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wpfVer2
{
    public partial class UDPtrack : Form
    {
        private const string V = ":";
        public bool active = true;
        public string ip = Form1.UDPip;
        public int port = Form1.UDPport;
        public int packets = Form1.UDPsent;
        public UDPtrack()
        {
            InitializeComponent();
        }

        private void UDPtrack_Load(object sender, EventArgs e)
        {
            label4.Text = ip + ":" + port.ToString();
            while (active)
            {
                packets = Form1.UDPsent;
                label3.Text = packets.ToString();
                Thread.Sleep(200);
            }
        }
    }
}
