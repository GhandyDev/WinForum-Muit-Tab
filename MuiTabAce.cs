using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForum_Muit_Tab
{
    public partial class MuiTabAce : Form
    {
        public MuiTabAce()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            WebClient wc = new WebClient();
            TabPage tp = new TabPage("Untitled");
            tp.Controls.Add(wb);
            wb.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
            wb.Url = new Uri(string.Format("file:///{0}/ace/editor.html", Directory.GetCurrentDirectory()));
        }

        private WebBrowser GetWebBrowser()
        {
            WebBrowser fst = null;
            TabPage tp = tabControl1.SelectedTab;
            if (tp != null)
            {
                fst = tp.Controls[0] as WebBrowser;
            }
            return fst;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            GetWebBrowser().Document.InvokeScript("ClearText");
        }

        private void MuiTabAce_Load(object sender, EventArgs e)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                bool flag2 = registryKey.GetValue(friendlyName) == null;
                if (flag2)
                {
                    registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                }
                registryKey = null;
                friendlyName = null;
            }
            catch (Exception)
            {
            }
            WebBrowser wb = new WebBrowser();
            WebClient wc = new WebClient();
            wc.Proxy = null;
            TabPage tp = new TabPage("Untitled");
            tp.Controls.Add(wb);
            wb.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
            wb.Url = new Uri(string.Format("file:///{0}/ace/editor.html", Directory.GetCurrentDirectory()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // in execute you will do it like this
            HtmlDocument document = GetWebBrowser().Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string script = obj.ToString();
            //api.SendLuaScript(script); like this
        }
    }
}
