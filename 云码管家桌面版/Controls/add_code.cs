using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSkin.Controls;
using System.Net;
using ScintillaNET;

namespace 云码管家桌面版.Controls
{
    public partial class add_code : DSkinUserControl
    {
        Scintilla textEditorControl1;
        public add_code()
        {
            InitializeComponent();
            dSkinComboBox1.AddItem("css[3]");
            dSkinComboBox1.AddItem("html[5]");
            dSkinComboBox1.AddItem("JS");
            dSkinComboBox1.AddItem("后端");
            //dSkinComboBox1.AddItem("私人库");
            this.textEditorControl1 = new Scintilla();
            this.textEditorControl1.Margins.Margin1.Width = 1;
            this.textEditorControl1.Margins.Margin0.Type = MarginType.Number;
            this.textEditorControl1.Margins.Margin0.Width = 0x23;
            this.textEditorControl1.ConfigurationManager.Language = "cs";
            this.textEditorControl1.Dock = DockStyle.Fill;
            this.textEditorControl1.ConfigurationManager.IsBuiltInEnabled = true;
            this.textEditorControl1.LineWrapping.Mode = LineWrappingMode.Word;
            this.textEditorControl1.Scrolling.ScrollBars = ScrollBars.Vertical;
            groupBox1.Controls.Add(this.textEditorControl1);
        }

        private void dSkinComboBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            if (!urer.urer.login)
            {
                MessageBox.Show("请登录使用此功能");
            }
            else
            {
                string sql = "INSERT INTO code_library (name,code_snippet,Label,pd,ip,uid) VALUES ('"+ dSkinTextBox2.Text+ "','"+ textEditorControl1.Text.Replace("'","\"")+ "','"+ dSkinComboBox1.Text+ "',0,'"+ GetAddressIP()+ "','"+urer.urer.urere+ "')";
                MySqlHelper.ExecuteScalar(MySqlHelper.Conn, CommandType.Text, sql, null);
                new message("上传成功请等待审核").ShowDialog();
                this.Visible = false;
            }
        }
        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
    }
}
