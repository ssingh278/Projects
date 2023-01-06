//***********************************************************************************
//Program: Balzz
//Description: Game of balzz with struct, enums,delgates,modless dialog,modal dialog and multithreading 
//Date: 10/11/2022
//Author: Sharry Singh
//Course: CMPE1666
//Class: CNT.A01(fall 2022)
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
    public partial class ShowScore_Modelless : Form
    {
        //delagte signature has been already created in main form
        public delvoidvoid _del_ShowScore_formClosing = null;
        public ShowScore_Modelless()
        {
            InitializeComponent();
        }

        //to set total score label value according the number of balls killed in main form
        public int TotalScore
        {
            set
            {
               UI_TotalScore_Label.Text=value.ToString("D4");
            }
        }

        /*
         * if close window directly than instead of killing it we will interfere user response and will hide the 
         * modless dialog instead of killing it
         */
        private void ShowScore_Modelless_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason==CloseReason.UserClosing)
            {
                if(_del_ShowScore_formClosing!=null)
                {
                    _del_ShowScore_formClosing();//invoking method
                }
                e.Cancel = true;
                Hide();
            }
        }
    }
}
