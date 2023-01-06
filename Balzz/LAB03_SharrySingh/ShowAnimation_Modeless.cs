//***********************************************************************************
//Program: Balzz
//Description: game balzz with struct, enums,delgates,modless dialog,modal dialog and multithreading 
//Date: 10/11/2022
//Author: Sharry Singh
//***********************************************************************************
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
    
    public partial class ShowAnimation_Modeless : Form
    {
        //for form closing event
        public delvoidvoid ShowAnimation_formClosing = null;
        public ShowAnimation_Modeless()
        {
            InitializeComponent();
        }

        //getting the change in trackbar value and sending it to main form
        public int Animation
        {
            get
            {
                return UI_animation_trackbar.Value;
            }
        }

        /*
         * if close window directly than instead of killing it we will interfere user response and will hide the 
         * modless dialog instead of killing it
         */
        private void ShowAnimation_Modeless_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (ShowAnimation_formClosing != null)
                {
                    ShowAnimation_formClosing();//invoking method
                }
                e.Cancel = true;
                Hide();
            }
        }
    }
}
