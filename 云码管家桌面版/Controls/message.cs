using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 云码管家桌面版.Controls
{
    public partial class message : DSkinForm
    {
        public message(string name)
        {//上传成功请等待审核
            InitializeComponent();
            dSkinLabel1.Text = name;
        }
    }
}
