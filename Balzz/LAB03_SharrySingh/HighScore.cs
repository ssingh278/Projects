using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balzz
{
    public partial class HighScore : Form
    {
        public HighScore()
        {
            InitializeComponent();
        }

        public string NameofPlayer
        {
            get
            {
                return UI_Name_Tbx.Text;
            }
        }

        private void UI_OK_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void UI_Cancel_btn_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;   
        }
    }
}
