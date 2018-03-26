using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSkin.DirectUI;
using DSkin.Common;
using DSkin.Controls;

namespace DSkinChatList
{
    /// <summary>
    /// 分组
    /// </summary>
    public class GroupItem : DuiBaseControl
    {
        static Font font = new Font("微软雅黑", 10);
        static Image open = 云码管家桌面版.Properties.Resources.openNode;
        static Image close = 云码管家桌面版.Properties.Resources.closeNode;
        public GroupItem()
        {
            this.Height = 35;
            this.InheritanceSize = new SizeF(1, 0);
            Controls.Add(openClose);
            Controls.Add(text);
            openClose.CheckedChanged += openClose_CheckedChanged;
        }

        void openClose_CheckedChanged(object sender, EventArgs e)
        {
            List<UserItem> tem = GetChildren();
            foreach (UserItem item in tem)
            {
                item.Visible = openClose.Checked;
            }
            DSkinListBox listbox = HostControl as DSkinListBox;
            if (listbox != null)
            {
                listbox.LayoutContent();
            }
        }

        DuiCheckBox openClose = new DuiCheckBox { CheckedNormal = open, UncheckedNormal = close, InnerPaddingWidth = 0, Checked = false, CheckRectWidth = 20, AutoCheck = false, Location = new Point(3, 3) };
        DuiLabel text = new DuiLabel { AutoSize = true, Location = new Point(25,8), Font = font, TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit, ForeColor = Color.White };

        public override string Text
        {
            get
            {
                return text.Text;
            }
            set
            {
                text.Text = value;
            }
        }

        /// <summary>
        /// 获取该分组下的用户项目
        /// </summary>
        /// <returns></returns>
        public List<UserItem> GetChildren()
        {
            List<UserItem> list = new List<UserItem>();
            DuiBaseControl parent = Parent as DuiBaseControl;
            if (parent != null)
            {
                foreach (DuiBaseControl item in parent.Controls)
                {
                    UserItem user = item as UserItem;
                    if (user != null && user.GroupId == Order)
                    {
                        list.Add(user);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 排序值
        /// </summary>
        public int Order
        {
            get;
            set;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(150, 200, 200, 200);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.Transparent;
        }

        protected override void OnMouseClick(DuiMouseEventArgs e)
        {
            base.OnMouseClick(e);
            openClose.Checked = !openClose.Checked;
        }

    }
}
