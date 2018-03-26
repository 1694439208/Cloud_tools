using DSkin.Controls;
using HtmlAgilityPack;
using JSBeautifyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 云码管家桌面版.Controls
{
    public partial class hm_siren : DSkinUserControl
    {
        public hm_siren()
        {
            InitializeComponent();
            #region MyRegion
            //TextEditorControl1.ShowEOLMarkers = false;
            //TextEditorControl1.ShowHRuler = false;
            //TextEditorControl1.ShowInvalidLines = false;
            //TextEditorControl1.ShowMatchingBracket = false;
            //TextEditorControl1.ShowSpaces = false;
            //TextEditorControl1.ShowTabs = false;
            //TextEditorControl1.ShowVRuler = false;
            //TextEditorControl1.AllowCaretBeyondEOL = false;
            //TextEditorControl1.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.FullRow;
            //TextEditorControl1.BorderStyle = BorderStyle.Fixed3D;//边框样式
            //TextEditorControl1.Font = new Font("微软雅黑", 11);// '设置字体
            //TextEditorControl1.ShowLineNumbers = true;//'显示行号
            //                                          // textEditorControl1.ContextMenuStrip = ContextMenuStrip1;//   '关联菜单
            //TextEditorControl1.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingStrategyFactory.CreateHighlightingStrategy("VBNET");// '设置显示语言
            //TextEditorControl1.Encoding = System.Text.Encoding.Default;// '设置编码
            //TextEditorControl1.Text = System.IO.File.ReadAllText(Application.StartupPath + @"\code.txt", System.Text.Encoding.Default);// '导入VB代码

            #endregion
            //fastColoredTextBox1.Text = System.IO.File.ReadAllText(Application.StartupPath + @"\code.txt", System.Text.Encoding.Default);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

        }

        private void dSkinButton3_Click(object sender, EventArgs e)
        {
            string script = fastColoredTextBox1.Text;// System.IO.File.ReadAllText(.Replace("\"","'"));
            JSBeautify jsb = new JSBeautify(script, new JSBeautifyOptions { preserve_newlines = false });
            string scriptbeautfied = jsb.GetResult();
            fastColoredTextBox1.Text = scriptbeautfied;
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            dSkinTextBox2.Text=urer.urer.jsEval(dSkinTextBox1.Text, fastColoredTextBox1.Text);
        }

        private void dSkinButton1_Click_1(object sender, EventArgs e)
        {
            int a = dSkinTextBox1.Text.Split('(').Length;
            int b = dSkinTextBox1.Text.Split(')').Length;
            if (dSkinTextBox1.Text.Split('(').Length != 2 || dSkinTextBox1.Text.Split(')').Length != 2)
            {
                MessageBox.Show("函数错误-请检查标点符号！！！");
            }
            else
            {
                dSkinTextBox2.Text = urer.urer.V8Method(fastColoredTextBox1.Text, dSkinTextBox1.Text.Split('(')[1].Split(')')[0], dSkinTextBox1.Text.Split('(')[0]);
            }
        }

        private void dSkinButton5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox12.Text = " ";
                if (radioButton3.Checked == true)
                {

                    string j = urer.urer.get_text(textBox11.Text, textBox13.Text);
                    textBox12.Text = j;
                }
                else
                {
                    int d = int.Parse(urer.urer.get_ing(textBox11.Text, textBox13.Text.Split('[')[0]));
                    for (int i = 0; i < d; i++)
                    {
                        textBox12.AppendText(urer.urer.get_text(textBox11.Text, textBox13.Text.Replace("#", i.ToString())) + "\r\n");
                    }
                }
            }
            catch (Exception x)
            {

                textBox12.Text = x.Message;
            }
        }

        private void dSkinButton4_Click_1(object sender, EventArgs e)
        {
            dSkinTextBox5.Text = string.Empty;
            HtmlNodeCollection htm = 解析html多(dSkinTextBox3.Text, dSkinTextBox4.Text);
            bool g = dSkinRadioButton2.Checked;
            if (htm != null)
            {
                foreach (HtmlNode h in htm)
                {
                    if (g)
                    {
                        dSkinTextBox5.AppendText(h.InnerHtml + "\r\n");
                    }
                    else
                    {
                        if (dSkinTextBox6.Text == "")
                        {
                            dSkinTextBox6.Text = "href";
                        }
                        dSkinTextBox5.AppendText(h.Attributes[dSkinTextBox6.Text].Value + "\r\n");
                    }
                }
            }
        }
        /// <summary>
        /// 解析html单
        /// </summary>
        /// <param name="yuan">元文本</param>
        /// <param name="txt">xpath</param>
        /// <returns></returns>
        public string 解析html单(string yuan, string txt, string val)
        {
            string 公司名字 = "";
            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(yuan);
                公司名字 = doc.DocumentNode.SelectSingleNode(txt).Attributes[val].Value;
            }
            catch (Exception)
            {
                return "无";
            }

            return 公司名字;
        }
        /// <summary>
        /// 解析html多
        /// </summary>
        /// <param name="text">元文本</param>
        /// <param name="ur">xpath</param>
        /// <returns></returns>
        public HtmlNodeCollection 解析html多(string text, string ur)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(text);
            HtmlNodeCollection nove = doc.DocumentNode.SelectNodes(ur);
            return nove;
        }
    }
}
