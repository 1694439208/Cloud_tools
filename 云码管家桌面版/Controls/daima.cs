using DSkin.Controls;
using DSkinChatList;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ScintillaNET;

namespace 云码管家桌面版.Controls
{
    public partial class daima : DSkinUserControl
    {
        Scintilla textEditorControl1;
        public daima(Image a,string nam,DSkinTabControl tab)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            //addlist(a);
            Tables = tab;
            name_id = nam;
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
            imag = a;
            new Thread(sqlget).Start();
        }
        public string name_id { set; get; }
        public Image imag { set; get; }
        public static DSkinTabControl Tables;
        /// <summary>
        /// 切换到代码视图
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        public void tz_page2(string data,string name)
        {
            textEditorControl1.Text = data;
            dSkinLabel2.Text = name;
            dSkinTabControl1.SelectedIndex = 1;
        }
        /// <summary>
        /// 切换到列表视图
        /// </summary>
        public void tz_page1()
        {
            dSkinTabControl1.SelectedIndex = 0;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void dSkinButton3_Click(object sender, EventArgs e)
        {
            tz_page1();        }
        //https://xui.ptlogin2.qq.com/cgi-bin/xlogin?appid=527020901&daid=372&low_login=0&qlogin_auto_login=1&s_url=https%3A%2F%2Fwww.weiyun.com%2Fweb%2Fcallback%2Fcommon_qq_login_ok.html%3Flogin_succ&style=20&target=self&link_target=blank&hide_close_icon=1
        private void dSkinButton3_Click_1(object sender, EventArgs e)
        {
            tz_page1();
        }
        /// <summary>
        /// 初始化代码列表
        /// </summary>
        public void sqlget()
        {
            //dSkinListBox1.Items.Clear();
            //Image head = imag;
            //MySqlDataReader reader = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, "select * from code_library WHERE Label='"+ name_id + "' and pd=1", null);
            //int i = 0;
            //while (reader.Read())
            //{
            //    System.Diagnostics.Debug.Print(reader[0].ToString());
            //    System.Diagnostics.Debug.Print(reader[1].ToString());
            //    System.Diagnostics.Debug.Print(Convert.ToString(reader[2].ToString()));
            //    System.Diagnostics.Debug.Print(reader[3].ToString());

            //    UserItem_core item = new UserItem_core() { GroupId = i, Order = 0, Text = reader[1].ToString(), Signature = "创建于"+ Convert.ToString(reader[2].ToString()), Head = head, Visible = true, Signatext = "查看" };
            //    item.MouseDoubleClick += (s, E) =>
            //    {
            //        MessageBox.Show("Test");

            //    };
            //    string data = reader[3].ToString();
            //    string name = reader[1].ToString();
            //    item.bit.MouseClick += (s, E) => { tz_page2(data, name); };
            //    dSkinListBox1.Items.Add(item);
            //    i++;
            //}
        }

        private void dSkinBaseControl1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 查询代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            dSkinListBox1.Items.Clear();
            Image head = imag;
            bool p=urer.urer.CheckParamBool(dSkinTextBox1.Text);
            string k = p ?"js":dSkinTextBox1.Text;
            MySqlDataReader reader = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, "select * from code_library WHERE name LIKE '%"+ k+ "%' and pd=1", null);
            int i = 0;
            while (reader.Read())
            {
                System.Diagnostics.Debug.Print(reader[0].ToString());
                System.Diagnostics.Debug.Print(reader[1].ToString());
                System.Diagnostics.Debug.Print(Convert.ToString(reader[2].ToString()));
                System.Diagnostics.Debug.Print(reader[3].ToString());

                UserItem_core item = new UserItem_core() { GroupId = i, Order = 0, Text = reader[1].ToString(), Signature = "创建于" + Convert.ToString(reader[2].ToString()), Head = head, Visible = true, Signatext = "查看" };
                item.MouseDoubleClick += (s, E) =>
                {
                    MessageBox.Show("Test");

                };
                item.bit.MouseClick += (s, E) => { tz_page2(reader[3].ToString(), reader[1].ToString()); };
                dSkinListBox1.Items.Add(item);
                i++;
            }
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            Tables.Controls.Clear();
            //dSkinTabControl1.Controls.Clear();
            add_code cr = new add_code { Dock = DockStyle.Fill };
            Tables.TabPages.Add(" ");
            Tables.TabPages[Tables.TabCount - 1].Controls.Add(cr);
            cr.Show();
            Tables.SelectedTab = Tables.TabPages[Tables.TabCount - 1];
        }

        private void daima_Load(object sender, EventArgs e)
        {

        }
    }
}
