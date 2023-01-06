//***********************************************************************************
//Program: Pic Blender
//Description: Pic Blender 
//Date: 15/10/2022
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PicBlender
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        //this event will basically load picture in picture box
        private void UI_LoadPicture_Btn_Click(object sender, EventArgs e)
        {

            openFileDialog1 = new OpenFileDialog();

            //enabling Restore Directory property
            openFileDialog1.RestoreDirectory = true;

            //filters for jpg,png,bmp, and all files.
            openFileDialog1.Filter = "BMP|*.bmp|JPG|*.jpg;*.jpeg|PNG|*.png|All files (*.*)|*.*";

            //default filter as bmp
            openFileDialog1.FileName = "BMP | *.bmp";

            //if user select image
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //displaying selected image in Picture box
                    pictureBox.Load(openFileDialog1.FileName);

                    //only enable transform button if image is load
                    UI_Transform_Btn.Enabled = true;

                    pictureBox.Image = new Bitmap(openFileDialog1.FileName);// making image into bitmap
                }
                catch
                {
                    //else show error message
                    MessageBox.Show("Could not load file.");
                }
            }
            //if user not select any image then display message
            else
            {
                MessageBox.Show("No Picture was selected");
            }

        }

        private void UI_Transform_Btn_Click(object sender, EventArgs e)
        {
            //creating copy of current image into bitmpay
            Bitmap copybmp = new Bitmap((Bitmap)pictureBox.Image);

            //initialising progress bar value every=time to zero when tranform button is clicked
            PIctureProgress.Value = 0;

            //minimum value of progress bar
            PIctureProgress.Minimum = 0;

            //maximu value of progress bar
            PIctureProgress.Maximum = copybmp.Width;//this is because evertime it is iterating through pixel it gonna stepup

            //step up value of progress bar
            PIctureProgress.Step = 1;

            //if black and white radio button is selected
            if (UI_BlackAndWhite_Rbn.Checked == true)
            {
                //calling black and white method
                BlackAndWhite(ref copybmp);
            }

            //if Contrast button is checked
            if (UI_Contrast_Rbn.Checked == true)
            {
                //calling Contrast method
                Contrast(ref copybmp);

            }

            //if tin button is checked
            if (UI_Tint_Rbn.Checked == true)
            {
                //calling tint method
                Tint(ref copybmp);
            }

            //if noise button is checked
            if (UI_Noise_Rbn.Checked == true)
            {
                //calling noise method
                Noise(ref copybmp);
            }

            //displaying image to pictureBox1
            pictureBox.Image = copybmp;
        }



        //this event will basically change labels under the trackbar  when trackbar value is changed
        private void Trackbar_Scroll(object sender, EventArgs e)
        {
            if (UI_Contrast_Rbn.Checked)
            {
                UI_Left_Lbl.Text = "Less";
                UI_Right_Lbl.Text = "More";
                UI_Center_Lbl.Text = UI_modification_Tbr.Value.ToString();
            }

            if (UI_BlackAndWhite_Rbn.Checked)
            {
                UI_Left_Lbl.Text = "Less";
                UI_Right_Lbl.Text = "More";
                UI_Center_Lbl.Text = UI_modification_Tbr.Value.ToString();
            }
            if (UI_Noise_Rbn.Checked)
            {
                UI_Left_Lbl.Text = "Less";
                UI_Right_Lbl.Text = "More";
                UI_Center_Lbl.Text = UI_modification_Tbr.Value.ToString();
            }
            if (UI_Tint_Rbn.Checked)
            {
                UI_Left_Lbl.Text = "Red";
                UI_Right_Lbl.Text = "Green";
                if (UI_modification_Tbr.Value == 50)
                {

                    UI_Center_Lbl.Text = (50 - UI_modification_Tbr.Value).ToString();
                }
                if (UI_modification_Tbr.Value < 50)
                {
                    UI_Center_Lbl.Text = "To red :" + (50 - UI_modification_Tbr.Value).ToString();
                }
                if (UI_modification_Tbr.Value > 50)
                {
                    UI_Center_Lbl.Text = "To green :" + (UI_modification_Tbr.Value - 50).ToString();
                }

            }
        }

        //this event will also change labels under trackbar but only when they are checked
        private void UI_Rbn_CheckedChange(object sender, EventArgs e)
        {
            if (UI_Contrast_Rbn.Checked)
            {
                UI_modification_Tbr.Value = 0;
                UI_Left_Lbl.Text = "Less";
                UI_Right_Lbl.Text = "More";
                UI_Center_Lbl.Text = UI_modification_Tbr.Value.ToString();
            }

            if (UI_BlackAndWhite_Rbn.Checked)
            {
                UI_modification_Tbr.Value = 0;
                UI_Left_Lbl.Text = "Less";
                UI_Right_Lbl.Text = "More";
                UI_Center_Lbl.Text = UI_modification_Tbr.Value.ToString();
            }
            if (UI_Noise_Rbn.Checked)
            {
                UI_modification_Tbr.Value = 0;
                UI_Left_Lbl.Text = "Less";
                UI_Right_Lbl.Text = "More";
                UI_Center_Lbl.Text = UI_modification_Tbr.Value.ToString();
            }
            if (UI_Tint_Rbn.Checked)
            {
                UI_modification_Tbr.Value = 50;//make sure to set trackbar label to center when clicked on Tin radio button
                UI_Left_Lbl.Text = "Red";
                UI_Right_Lbl.Text = "Green";
                if (UI_modification_Tbr.Value == 50)
                {

                    UI_Center_Lbl.Text = "Biased";
                }
                if (UI_modification_Tbr.Value < 50)
                {
                    UI_Center_Lbl.Text = "To red :" + (50 - UI_modification_Tbr.Value).ToString();
                }
                if (UI_modification_Tbr.Value > 50)
                {
                    UI_Center_Lbl.Text = "To green :" + (UI_modification_Tbr.Value - 50).ToString();
                }

            }

        }

        //****************************************************************************************** **
        //private void BlackAndWhite( ref Bitmap bmp)
        //Purpose: This method will accept picture as bitmap and turn it into black and white
        //Parameters:ref Bitmap bmp- bitmap on which we have to change pixel
        //Returns:nothing
        //****************************************************************************************** ***
        private void BlackAndWhite(ref Bitmap bmp)
        {

            //iterating through each and every pixel of picture
            for (int xpixel = 0; xpixel < bmp.Width; xpixel++)
            {
                for (int ypixel = 0; ypixel < bmp.Height; ypixel++)
                {
                    //getting current RGB color at each location of bitmap
                    Color bmpColor = bmp.GetPixel(xpixel, ypixel);

                    //getting current color value of red at current location in bitmap
                    int red = bmpColor.R;

                    //getting current color value of green at current location in bitmap
                    int green = bmpColor.G;

                    //getting current color value of blue at current location in bitmap
                    int blue = bmpColor.B;

                    //averaging RGB value
                    int avgRGB = (red + green + blue) / 3;

                    //moving color component toward average and finding new value of color component 
                    int Nred = CalculateBlackAndWhite(red, avgRGB);
                    int Ngreen = CalculateBlackAndWhite(green, avgRGB);
                    int Nblue = CalculateBlackAndWhite(blue, avgRGB);

                    //setting pixel 
                    bmp.SetPixel(xpixel, ypixel, Color.FromArgb(Nred, Ngreen, Nblue));

                }
                PIctureProgress.PerformStep();//performing stepup as iterating through pixels for progress bar
            }

        }

        //****************************************************************************************** **
        //private int CalculateBlackAndWhite(int RGB ,int avgRGB)
        //Purpose: This method will  calculate total displacement require to move current RGB value
        //to average 
        //Parameters:int RGB -current color value of either R,B,G
        //           int avgRGB - current average of R+B+G
        //Returns: int calculated value for new color component
        //****************************************************************************************** ***
        private int CalculateBlackAndWhite(int RGB, int avgRGB)
        {
            return (RGB + ((avgRGB - RGB) * UI_modification_Tbr.Value / 100));
        }


        //****************************************************************************************** **
        //private void Contrast(ref Bitmap bmp)
        //Purpose: This method will accept picture as bitmap and increase contrast of it
        //Parameters:ref Bitmap bmp- bitmap on which we have to change pixel
        //Returns:nothing
        //****************************************************************************************** ***
        private void Contrast(ref Bitmap bmp)
        {

            //iterating through each and every pixel of picture
            for (int xpixel = 0; xpixel < bmp.Width; xpixel++)
            {
                for (int ypixel = 0; ypixel < bmp.Height; ypixel++)
                {
                    //getting current RGB color at each location of bitmap
                    Color bmpColor = bmp.GetPixel(xpixel, ypixel);

                    //getting current color value of red at current location in bitmap
                    int red = bmpColor.R;

                    //getting current color value of green at current location in bitmap
                    int green = bmpColor.G;

                    //getting current color value of blue at current location in bitmap
                    int blue = bmpColor.B;


                    int Nred = CalculateContrast(red);
                    int Ngreen = CalculateContrast(green);
                    int Nblue = CalculateContrast(blue);


                    //setting pixel 
                    bmp.SetPixel(xpixel, ypixel, Color.FromArgb(Nred, Ngreen, Nblue));

                }
                PIctureProgress.PerformStep();//performing stepup as iterating through pixels for progress bar
            }
        }

        //****************************************************************************************** **
        //CalculateContrast(int colorValue)
        //Purpose: This method will  calculate total pixel value need to increase or decrease for contrast
        //Parameters:int colorValue-current pixel of RBG value
        //Returns: int calculated value for new color component
        //****************************************************************************************** ***
        private int CalculateContrast(int colorValue)
        {
            int newcolorValue = 0;//new color value of RBG
            int contrast = (UI_modification_Tbr.Value / 5);//dividing trackbar value by 5

            //if color value is less than 128 increase contrast value of RBG component  by (1/5)th value of trackbar
            if (colorValue > 128)
            {
                newcolorValue = colorValue + contrast;
            }

            //if color value is less than 128 decrease contrast value of RBG component by (1/5)th value of trackbar
            if (colorValue < 128)
            {
                newcolorValue = colorValue - contrast;
            }
            //if color value is equal to 128 the RBG component value will remain 128
            if (colorValue == 128)
            {
                newcolorValue = 128;
            }

            //if new color component get more than 255 which is out of range then we will restrict
            //value of newcolorvalue to 255
            if (newcolorValue > 255)
            {
                newcolorValue = 255;
            }

            //if new color component get less than 0 which is out of range then we will restrict
            //value of newcolorvalue to 0
            if (newcolorValue < 0)
            {
                newcolorValue = 0;
            }

            return newcolorValue;//returning  new rbg component value
        }


        //****************************************************************************************** **
        //private void Tint(ref Bitmap bmp)
        //Purpose: This method will accept picture as bitmap and will tint the image
        //Parameters:ref Bitmap bmp- bitmap on which we have to change pixel
        //Returns:nothing
        //****************************************************************************************** ***
        private void Tint(ref Bitmap bmp)
        {

            //iterating through each and every pixel of picture
            for (int xpixel = 0; xpixel < bmp.Width; xpixel++)
            {
                for (int ypixel = 0; ypixel < bmp.Height; ypixel++)
                {
                    //getting current RGB color at each location of bitmap
                    Color bmpColor = bmp.GetPixel(xpixel, ypixel);

                    //getting current color value of red at current location in bitmap
                    int red = bmpColor.R;

                    //getting current color value of green at current location in bitmap
                    int green = bmpColor.G;

                    //getting current color value of blue at current location in bitmap
                    int blue = bmpColor.B;

                    //new value for red component
                    int Nred = CalculateTintforRed(red);

                    //new value for green component
                    int Ngreen = CalculateTintforGreed(green);

                    //setting pixel 
                    bmp.SetPixel(xpixel, ypixel, Color.FromArgb(Nred, Ngreen, blue));

                }
                PIctureProgress.PerformStep();//performing stepup as iterating through pixels for progress bar
            }
        }


        //****************************************************************************************** **
        //private int CalculateTintforRed(int red)
        //Purpose: This method will  calculate total pixel value need to adjust for red  component
        //Parameters:int colorValue-current pixel of R value
        //Returns: int Nred - calculated value for new color component
        //****************************************************************************************** ***
        private int CalculateTintforRed(int red)
        {
            int Nred = 0;//new color value of RBG

            //if value of trackbar is less than 50 that is only we go for red tint
            if (UI_modification_Tbr.Value < 50)
            {
                Nred = (red + (50 - UI_modification_Tbr.Value));

                //make sure not to go out of bound
                if (Nred < 0)
                {
                    Nred = 0;
                }
                //make sure not to go out of bound
                if (Nred > 255)
                {
                    Nred = 255;
                }
            }
            //if value of trackbar is less than 50 that is only we go for green tint
            //than do nothing with red component and return it back as it is
            if (UI_modification_Tbr.Value > 50)
            {
                Nred = red;
            }

            //if new color component get more than 255 which is out of range then we will restrict
            //value of newcolorvalue to 255
            if (Nred > 255)
            {
                Nred = 255;
            }

            //if new color component get less than 0 which is out of range then we will restrict
            //value of newcolorvalue to 0
            if (Nred < 0)
            {
                Nred = 0;
            }
            return Nred;//returning  new rbg component value
        }


        //****************************************************************************************** **
        //private int CalculateTintforGreed(int green)
        //Purpose: This method will  calculate total pixel value need to adjust for green  component
        //Parameters:int colorValue-current pixel of G value
        //Returns: int Ngreen - calculated value for new color component
        //****************************************************************************************** ***
        private int CalculateTintforGreed(int green)
        {
            int Ngreen = 0;//new color value of RBG

            //if value of trackbar is greter than 50 that is only we go for green tint 
            if (UI_modification_Tbr.Value > 50)
            {
                Ngreen = (green + (UI_modification_Tbr.Value - 50));

                //make sure to not go out of bound
                if (Ngreen < 0)
                {
                    Ngreen = 0;
                }
                //make sure not to out of bound
                if (Ngreen > 255)
                {
                    Ngreen = 255;
                }
            }

            //if we only go for red tint that is value of trackbar is less than 50 
            //so we will not make any change to green component
            if (UI_modification_Tbr.Value < 50)
            {
                Ngreen = green;
            }

            //if new color component get more than 255 which is out of range then we will restrict
            //value of newcolorvalue to 255
            if (Ngreen > 255)
            {
                Ngreen = 255;
            }

            //if new color component get less than 0 which is out of range then we will restrict
            //value of newcolorvalue to 0
            if (Ngreen < 0)
            {
                Ngreen = 0;
            }
            return Ngreen;//returning  new rbg component value
        }


        //****************************************************************************************** **
        //private void Noise(ref Bitmap bmp)
        //Purpose: This method will accept picture as bitmap and will apply noise effect to the image
        //Parameters:ref Bitmap bmp- bitmap on which we have to change pixel
        //Returns:nothing
        //****************************************************************************************** ***
        private void Noise(ref Bitmap bmp)
        {
            //object for random number
            Random rNumber = new Random();

            //iterating through each and every pixel of picture
            for (int xpixel = 0; xpixel < bmp.Width; xpixel++)
            {
                for (int ypixel = 0; ypixel < bmp.Height; ypixel++)
                {
                    //getting current RGB color at each location of bitmap
                    Color bmpColor = bmp.GetPixel(xpixel, ypixel);

                    //getting current color value of red at current location in bitmap
                    int red = bmpColor.R;

                    //getting current color value of green at current location in bitmap
                    int green = bmpColor.G;

                    //getting current color value of blue at current location in bitmap
                    int blue = bmpColor.B;

                    //getting new color component
                    int Nred = CalculatedNoise(red, rNumber.Next());
                    int Ngreen = CalculatedNoise(green, rNumber.Next());
                    int Nblue = CalculatedNoise(blue, rNumber.Next());


                    //setting pixel 
                    bmp.SetPixel(xpixel, ypixel, Color.FromArgb(Nred, Ngreen, Nblue));

                }
                PIctureProgress.PerformStep();//performing stepup as iterating through pixels for progress bar
            }
        }

        //****************************************************************************************** **
        //private int CalculatedNoise(int colorvalue,int rNumber)
        //Purpose: This method will  calculate total noise effect need for each effect
        //Parameters:int colorValue-current pixel of RBG
        //int rnumber=randomnumber generated
        //Returns: int newColorvalue- calculated value for new color component
        //****************************************************************************************** ***
        private int CalculatedNoise(int colorvalue, int rNumber)
        {
            //value of trackbar
            int iEffectLevel = UI_modification_Tbr.Value;

            //new color value for noise effect
            int newColorvalue = (colorvalue + (rNumber % ((iEffectLevel + 1) * 2)) - iEffectLevel);

            //if new color component get more than 255 which is out of range then we will restrict
            //value of newcolorvalue to 255
            if (newColorvalue > 255)
            {
                newColorvalue = 255;
            }

            //if new color component get less than 0 which is out of range then we will restrict
            //value of newcolorvalue to 0
            if (newColorvalue < 0)
            {
                newColorvalue = 0;
            }

            return newColorvalue;//returning  new rbg component value
        }


    }
}

