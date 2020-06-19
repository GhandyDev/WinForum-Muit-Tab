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
    public partial class MuitTabMonacro : Form
    {
        public MuitTabMonacro()
        {
            InitializeComponent();
        }


        WebClient wc = new WebClient();
        private string defPath = Application.StartupPath + "//Monaco//";

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


        private async void addIntel(string label, string kind, string detail, string insertText)
        {
            await Task.Delay(1000);
            string text = "\"" + label + "\"";
            string text2 = "\"" + kind + "\"";
            string text3 = "\"" + detail + "\"";
            string text4 = "\"" + insertText + "\"";
            GetWebBrowser().Document.InvokeScript("AddIntellisense", new object[]
            {
                label,
                kind,
                detail,
                insertText
            });
        }

        private void addGlobalF()
        {
            string[] array = File.ReadAllLines(this.defPath + "//globalf.txt");
            foreach (string text in array)
            {
                bool flag = text.Contains(':');
                if (flag)
                {
                    this.addIntel(text, "Function", text, text.Substring(1));
                }
                else
                {
                    this.addIntel(text, "Function", text, text);
                }
            }
        }

        private void addGlobalV()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalv.txt"))
            {
                this.addIntel(text, "Variable", text, text);
            }
        }

        private void addGlobalNS()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalns.txt"))
            {
                this.addIntel(text, "Class", text, text);
            }
        }

        private void addMath()
        {
            foreach (string text in File.ReadLines(this.defPath + "//classfunc.txt"))
            {
                this.addIntel(text, "Method", text, text);
            }
        }

        private void addBase()
        {
            foreach (string text in File.ReadLines(this.defPath + "//base.txt"))
            {
                this.addIntel(text, "Keyword", text, text);
            }
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            WebClient wc = new WebClient();
            TabPage tp = new TabPage("Untitled");
            tp.Controls.Add(wb);
            wb.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
            wb.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(500);
            wb.Document.InvokeScript("SetTheme", new string[]
            {
                   "Dark" 
                   /*
                    There are 2 Themes Dark and Light
                   */
            });
            addBase();
            addMath();
            addGlobalNS();
            addGlobalV();
            addGlobalF();
        }

        private async void MuitTabMonacro_LoadAsync(object sender, EventArgs e)
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
            wb.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(500);
            wb.Document.InvokeScript("SetTheme", new string[]
            {
                   "Dark" 
            });
            addBase();
            addMath();
            addGlobalNS();
            addGlobalV();
            addGlobalF();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetWebBrowser().Document.InvokeScript("SetText", new object[]
            {
                ""
            });
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
