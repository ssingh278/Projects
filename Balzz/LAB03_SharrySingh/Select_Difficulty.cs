//***********************************************************************************
//Program: Balzz
//Description: game of balzz with struct, enums,delgates,modless dialog,modal dialog and multithreading 
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
    
    public partial class Select_Difficulty : Form
    {
       
        public Select_Difficulty()
        {
            InitializeComponent();
        }

        //selected difficulty level by user
        public int Selected_Difficulty_level
        {
            //returning difficulty level to user as string
            get
            { 
                //if difficulty level is easy
                if(UI_Easy_Rbn.Checked==true)
                {
                    return 3;
                }
                //if difficulty level is medium
                if (UI_Medium_Rbn.Checked==true)
                {
                    return 4;
                }
                //if difficulty level is Hard
                else
                {
                    return 5;
                }
            }
        }


        //if ok button is clicked
        private void UI_OK_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //if cancel button is clicked
        private void UI_Cancel_btn_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
        }
    }
}
