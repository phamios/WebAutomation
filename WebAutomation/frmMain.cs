using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace WebAutomation
{
    [ComVisible(true)]
    public partial class frmMain : Form
    {

        private WebBrowser wbMain;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            wbMain = new WebBrowser();
            wbMain.ObjectForScripting = this;
            wbMain.DocumentText =
                "<html>" +
                "<head>" +
                "<script type='text/javascript'>" +
                    "function go(url) " +
                    "{ " +
                        "window.external.go(url);" +
                    "}" +
                "</script>" +
                "</head>" +
                "<body>" +
                "</body>" +
            "</html>";
            this.Controls.Add(wbMain);
        }

        public void go(string url)
        {
            wbBrowser.Navigate(url);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string code = tbxCode.Text;
            wbMain.Document.InvokeScript("eval", new object[] { code }); 
        }
    }
}
