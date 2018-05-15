using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
namespace GetInfoRM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetIdDisk();
            GetIdCPU();
            GetIdBoard();
            GetHostName();
        }

        public void GetIdDisk()
        {
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            lblDisk.Text = dsk["VolumeSerialNumber"].ToString();
        }

        public void GetIdBoard()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            foreach (ManagementObject mo in moc)
            {
                lblBoard.Text = (string)mo["SerialNumber"];
            }
        }

        public void GetIdCPU()
        {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                lblCPU.Text = mo["ProcessorID"].ToString();
            }
        }

        public void GetHostName()
        {
            lblHname.Text = System.Environment.MachineName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblDisk.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblCPU.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblBoard.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblHname.Text);
        }
    }
}
