namespace 云码管家桌面版.Controls
{
    partial class 关于
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel2 = new DSkin.Controls.DSkinLabel();
            this.SuspendLayout();
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.Font = new System.Drawing.Font("微软雅黑", 19.25F);
            this.dSkinLabel1.Location = new System.Drawing.Point(310, 19);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(115, 38);
            this.dSkinLabel1.TabIndex = 0;
            this.dSkinLabel1.Text = "关于软件";
            // 
            // dSkinLabel2
            // 
            this.dSkinLabel2.Font = new System.Drawing.Font("宋体", 20F);
            this.dSkinLabel2.Location = new System.Drawing.Point(35, 63);
            this.dSkinLabel2.Name = "dSkinLabel2";
            this.dSkinLabel2.Size = new System.Drawing.Size(710, 308);
            this.dSkinLabel2.TabIndex = 1;
            this.dSkinLabel2.Text = "此管家由我海绵宝宝独立开发（qq1694439208）\r\n定为1.0版本\r\n未完成功能有-网络书签\r\n代码高亮控件暂时有bug中文之间需要加一个空格\r\n语法高亮支" +
    "持不多\r\n暂强制为c#高亮-如果大家有什么更好的高亮方案请联系我\r\n欢迎大家反馈bug\r\n游客也就是没有账号的只有查询功能\r\n注册账号就可以发布代码片段-需要审" +
    "核\r\n账号注册地址http://pituber.com/";
            // 
            // 关于
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dSkinLabel2);
            this.Controls.Add(this.dSkinLabel1);
            this.Name = "关于";
            this.Size = new System.Drawing.Size(775, 394);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinLabel dSkinLabel2;
    }
}
