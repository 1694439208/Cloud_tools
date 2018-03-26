using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.DirectUI;
using DSkinChatList;
using 云码管家桌面版.Controls;
using DSkin.Controls;
using MySql.Data.MySqlClient;
using System.Net;

namespace 云码管家桌面版
{
    public partial class Form1 : DSkinForm
    {
        public Form1()
        {
            InitializeComponent();
            if (urer.urer.login)
            {
                dSkinLabel6.Text = "注销";
            }
            else { dSkinLabel6.Text = "点击头像登陆"; }
            #region 测试头像加载
            DSkin.Controls.DSkinBrush a = new c();
            a.Brush = new TextureBrush(new Bitmap(Properties.Resources.preferences_system_login_256px_572066_easyicon_net, 100, 100));
            duiPie1.EllipseBrush = a;
            #endregion
            #region 列表
            string[] tatle = { "关于", "网络书签[登陆]", "后端[公共库]", "前端[公共库]", "工具" };
            dSkinListBox1.InnerScrollBar.BackColor = Color.Transparent;
            for (int i = 0; i < 5; i++)//添加分组
            {
                dSkinListBox1.Items.Add(new GroupItem() { Order = i, Text = tatle[i] });
            }
            for (int j = 0; j < 5; j++)//添加用户，GroupId要和分组的Order一致
            {
                if (j == 4)
                {
                    Image head = Properties.Resources.wrench_1019_0009794319px_1152317_easyicon_net;
                    UserItem item = new UserItem() { GroupId = j, Order = 0, Text = "基础工具" , Signature = "基本的", Head = head, Visible = false };
                    item.MouseClick += (s, E) => {
                        dSkinLabel5.Text = "首页/工具/基础工具";
                        dSkinTabControl1.Controls.Clear();
                        Tables = dSkinTabControl1;
                        hm_siren cr = new hm_siren { Dock = DockStyle.Fill };
                        Tables.TabPages.Add(" ");
                        Tables.TabPages[Tables.TabCount - 1].Controls.Add(cr);
                        cr.Show();
                        Tables.SelectedTab = Tables.TabPages[Tables.TabCount - 1];
                    };
                    dSkinListBox1.Items.Add(item);
                }
                if (j == 3)
                {
                    Image[] head = { Properties.Resources.css_512px_1168967_easyicon_net, Properties.Resources.html_512px_1168981_easyicon_net, Properties.Resources.js_512px_1168983_easyicon_net };
                    string[] addp = { "css[3]-此代码库代码[300]", "html[5]-此代码库代码[300]", "JS-此代码库代码[300]" };
                    string[] idd = { "css[3]","html[5]","JS"};
                    for (int d = 0; d < 3; d++)
                    {
                        UserItem item = new UserItem() { GroupId = j, Order = d, Text = addp[d].Split('-')[0] , Signature = addp[d].Split('-')[1], Head = head[d], Visible = false };
                        item.MouseClick += (s, E) => { //MessageBox.Show(E.ToString()); 
                            core_coor(item.GroupId, item.Order, item.Head,item.Text);
                            dSkinLabel5.Text = "首页/前端[公共库]/" + idd[item.Order];
                        };
                        dSkinListBox1.Items.Add(item);
                    }
                }
                if (j == 2)
                {
                    Image head = Properties.Resources.server_115_71084337349px_1156857_easyicon_net;
                    UserItem item = new UserItem() { GroupId = j, Order = 0, Text = "后端" , Signature = "此库依靠标签分类", Head = head, Visible = false };
                    item.MouseClick += (s, E) => { core_coor(item.GroupId, item.Order, item.Head, item.Text); dSkinLabel5.Text = "首页/后端[公共库]/后端"; };
                    dSkinListBox1.Items.Add(item);
                }
                if (j == 1)
                {
                    Image head = Properties.Resources.Cloud_Signal_Black_256px_1171908_easyicon_net;
                    UserItem item = new UserItem() { GroupId = j, Order = 0, Text = "书签[云备份]", Signature = "依靠标签分类", Head = head, Visible = false };
                    item.MouseClick += (s, E) => { core_coor(item.GroupId, item.Order, item.Head, item.Text); dSkinLabel5.Text = "首页/私人库[登陆]/私人库[云备份]"; };
                    dSkinListBox1.Items.Add(item);
                }
                if (j == 0)
                {
                    Image head = Properties.Resources.about_1100px_1143831_easyicon_net;
                    UserItem item = new UserItem() { GroupId = j, Order = 0, Text = "关于此软件" , Signature = "2017", Head = head, Visible = false };
                    item.MouseClick += (s, E) => { core_coor(item.GroupId, item.Order, item.Head, item.Text); dSkinLabel5.Text = "首页/关于/关于此软件"; };
                    dSkinListBox1.Items.Add(item);
                }
            }



            dSkinListBox1.Items.Sort(new ChatItemSort());
            dSkinListBox1.LayoutContent();
            #endregion
        }

        public void core_coor(int a,int b,Image img,string name)
        {
            if (!urer.urer.login && name.IndexOf("书签")!=-1)
            {
                new message("此功能需要登录操作").ShowDialog();
            }
            else {
                if (name.IndexOf("关于") != -1)
                {
                    dSkinTabControl1.Controls.Clear();
                    Tables = dSkinTabControl1;

                    关于 cr = new 关于() { Dock = DockStyle.Fill };
                    Tables.TabPages.Add(" ");
                    Tables.TabPages[Tables.TabCount - 1].Controls.Add(cr);
                    cr.Show();
                }
                else {
                    dSkinTabControl1.Controls.Clear();
                    Tables = dSkinTabControl1;
                    daima cr = new daima(img, name, dSkinTabControl1) { Dock = DockStyle.Fill };
                    Tables.TabPages.Add(" ");
                    Tables.TabPages[Tables.TabCount - 1].Controls.Add(cr);
                    cr.Show();
                }
                
            }
        }
        public static DSkinTabControl Tables;
        class c : DSkin.Controls.DSkinBrush
        {
            protected override Brush CreateBrush()
            {
                throw new NotImplementedException();
            }
        }

        private void duiPie1_MouseClick(object sender, DuiMouseEventArgs e)
        {
            if (!urer.urer.login)
            {
                new login().ShowDialog();
                dSkinLabel1.Text = urer.urer.name +"-"+ dSkinLabel1.Text;
                DSkin.Controls.DSkinBrush a = new c();
                a.Brush = new TextureBrush(new Bitmap(urer.urer.img, 100, 100));
                duiPie1.EllipseBrush = a;
            }
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            object obj = MySqlHelper.ExecuteScalar(MySqlHelper.Conn, CommandType.Text, "select * from code_library WHERE Label='JS'", null);//select * from code_library WHERE Label='JS'
                                                                                                                                            //int n = Convert.ToInt32(obj);


        }

        private void dSkinLabel6_Click(object sender, EventArgs e)
        {
            urer.urer.login = false;
            DSkin.Controls.DSkinBrush a = new c();
            a.Brush = new TextureBrush(new Bitmap(Properties.Resources.preferences_system_login_256px_572066_easyicon_net, 100, 100));
            duiPie1.EllipseBrush = a;
        }

        private void dSkinButton1_Click_1(object sender, EventArgs e)
        {

        }
        public delegate void mmp();
        public void go()
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
