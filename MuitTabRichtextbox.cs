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
    public partial class MuitTabRichtextbox : Form
    {
        public MuitTabRichtextbox()
        {
            InitializeComponent();
        }

        private FastColoredTextBoxNS.FastColoredTextBox GetTextBox()
        {

            FastColoredTextBoxNS.FastColoredTextBox fst = null;
            TabPage tp = tabControl1.SelectedTab;
            if (tp != null)
            {
                fst = tp.Controls[0] as FastColoredTextBoxNS.FastColoredTextBox;
            }
            return fst;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            FastColoredTextBoxNS.FastColoredTextBox wc = new FastColoredTextBoxNS.FastColoredTextBox(); // to lasy to change the name XD
            TabPage tp = new TabPage("Untitled");
            tp.Controls.Add(wc);
            wc.Language = FastColoredTextBoxNS.Language.Lua;
            wc.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //api.ExecuteScript(GetRichTextBox().text)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetTextBox().Text = "";
        }

        private void MuitTabRichtextbox_Load(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            FastColoredTextBoxNS.FastColoredTextBox wc = new FastColoredTextBoxNS.FastColoredTextBox(); // to lasy to change the name XD
            TabPage tp = new TabPage("Untitled");
            tp.Controls.Add(wc);
            wc.Language = FastColoredTextBoxNS.Language.Lua;
            wc.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
        }
    }
}
