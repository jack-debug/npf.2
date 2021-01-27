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
        public bool active;
        public UDPtrack()
        {
            InitializeComponent();
        }

        private void UDPtrack_Load(object sender, EventArgs e)
        {
            label4.Text = Form1.UDPip + ":" + Form1.UDPport.ToString();
            Task.Factory.StartNew(this.update);
        }
        private void update()
        {
            label3.Text = Form1.UDPsent.ToString();
            Thread.Sleep(200);
            update();
        }
    }
}
