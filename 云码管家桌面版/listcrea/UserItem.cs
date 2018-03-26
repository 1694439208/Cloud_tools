using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSkin.DirectUI;
using DSkin.Common;

namespace DSkinChatList
{
    public class UserItem : DuiBaseControl
    {
        static Font font = new Font("微软雅黑", 11);
        static Font SignatureFont = new Font("微软雅黑", 8);
        Color selectedColor = Color.FromArgb(100, 219, 174, 76);
        public UserItem()
        {
            this.Height = 50;
            this.InheritanceSize = new SizeF(1, 0);
            this.Controls.Add(head);
            this.Controls.Add(text);
            this.Controls.Add(signature);
        }
        /// <summary>
        /// 头像
        /// </summary>
        DuiPictureBox head = new DuiPictureBox { Size = new Size(25, 25), Location = new Point(13, 13), SizeMode = PictureBoxSizeMode.StretchImage };
        /// <summary>
        /// 用户名
        /// </summary>
        DuiLabel text = new DuiLabel { AutoSize = true, Location = new Point(50, 7), Font = font, TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit,ForeColor=Color.White };
        /// <summary>
        /// 签名
        /// </summary>
        DuiLabel signature = new DuiLabel { AutoSize = true, Location = new Point(50, 28), Font = SignatureFont, TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit, ForeColor = Color.DimGray};

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.BackColor != selectedColor)
            {
                this.BackColor = Color.FromArgb(150, 200, 200, 200);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.BackColor != selectedColor)
            {
                this.BackColor = Color.Transparent;
            }
        }

        protected override void OnMouseClick(DuiMouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.BackColor = selectedColor;
            DuiBaseControl parent = Parent as DuiBaseControl;
            if (parent != null)
            {
                foreach (DuiBaseControl item in parent.Controls)
                {
                    UserItem i = item as UserItem;
                    if (i != null && i != this)
                    {
                        i.BackColor = Color.Transparent;
                    }
                }
            }
        }

        /// <summary>
        /// 分组ID
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// 该分组下的排序ID
        /// </summary>
        public int Order
        {
            get;
            set;
        }

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

        public string Signature
        {
            get { return signature.Text; }
            set { signature.Text = value; }
        }

        public Image Head
        {
            get { return head.Image; }
            set
            {
                head.Image = value;
            }
        }

    }
}
