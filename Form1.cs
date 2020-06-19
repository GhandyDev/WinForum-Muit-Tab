using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForum_Muit_Tab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MuitTabRichtextbox hehe = new MuitTabRichtextbox();
            hehe.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MuitTabMonacro hehe = new MuitTabMonacro();
            hehe.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MuiTabAce hehe = new MuiTabAce();
            hehe.Show();
            this.Hide();
        }
    }
}
