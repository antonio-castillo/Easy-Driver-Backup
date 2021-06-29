using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Easy_Driver_Backup
{
    public partial class Form1 : Form
    {

        String currectDirectory = Directory.GetCurrentDirectory();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            progressBar1.Maximum = 1;
     

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool active = true;
            progressBar1.Value = 0;

            Process p = new Process();
            p.StartInfo.Arguments = string.Format("/C Export-WindowsDriver -Online -Destination Driver_Backup");
            p.StartInfo.FileName = "Powershell.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = true;
            p.Start();
            p.WaitForExit();
            active = false;

            if (active == false)
            {
                progressBar1.Value = 1;
                MessageBox.Show("The copy of drivers has been completed");
            }

            Process.Start("explorer.exe", currectDirectory);


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/antonio-castillo");
        }
    }
}
