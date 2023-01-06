//***********************************************************************************
//Program: Ballzz
//Description: game of balzz with struct, enums,delgates,modless dialog,modal dialog and multithreading 
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
using GDIDrawer;
using System.Threading;
using System.IO;

namespace Balzz
{
    //creating delegate tha return nothing
    //this delegate is to make communication of myh main form with other forms
    public delegate void delvoidvoid();
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //initialising 'show Score' modelless dialog form
       private ShowScore_Modelless ShowScore_dl = null;

        //initialising 'show animation' modelless dialog form
        private ShowAnimation_Modeless ShowAnimation_dl = null;

        //initialising my modal dialog for difficulty level
        private Select_Difficulty SelectDifficulty_ModalDialog=null;

        //initialising my modal dialog for difficulty level
        private HighScore _highScore_dl = null;


        
        /////////////////////////////////////// Declaring all constants//////////////////////////////////////////

        const int Ball_Size = 50;//size of ball
        const int Row_Count = 16;//number of rows
        const int Column_Count = 12;//number of columns

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        ////////////////////////////               Initialising Enums         /////////////////////////////////
        public enum State
        {
            //state of the balls 
            Alive,
            Dead
        };
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////               Creating Struct            /////////////////////////////////
        public struct GameElements
        {
            public Color Ballz_Color;//color of ball
            public State Current_State;

            //no need of constructor for my struct
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        //craeting array of type created struct
        GameElements[,] Ballz_array = new GameElements[Row_Count,Column_Count];

        //for GDI drawer
        CDrawer Ballzz=new CDrawer();

        //initially total score is 0
        int TotalScore = 0;

        //high score
        int HighestScore = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //private void Randomize()
        //Purpose:this method will assign random color to all balls as well as alive state to all balls
        //Parameters:no parameters
        //Returns: nothing
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Randomize()
        {
            //creating array of 5 color
            Color[] Color_Array_ForBallz=new Color[] { Color.Red, Color.Green, Color.Orange, Color.Purple, Color.Yellow };

            //difficulty selected by user
            int difficulty = 0;

            //random number to be generated that will require to assign color value to the balls
            Random Rnumber = new Random();

            //difficulty selected by user ,if difficulty selected by user :
            //if it is 'easy' balls of 3 colors will be drawn on screen
            //if it is 'medium' balls of 4 colors will be drawn on screen
            //if it is 'hard' balls of 5 colors will be drawn on screenS
            difficulty = SelectDifficulty_ModalDialog.Selected_Difficulty_level;
            

            //iterating through array of balls
            for (int i = 0; i < Row_Count; i++)
            {
                for(int j = 0; j < Column_Count; j++)
                {
                    //assigning them random color according to difficulty selected by user
                    Ballz_array[i, j].Ballz_Color = Color_Array_ForBallz[Rnumber.Next(0, difficulty)];

                    //initially all balls are in alive state
                    Ballz_array[i, j].Current_State = State.Alive;
                }

            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //private void Display()
        //Purpose:this method will display all balls on GDI window if they are in alive state
        //Parameters:no parameters
        //Returns: nothing
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display()
        {
            //clearing graphical window first
            Ballzz.Clear();
            
            //then iterating through array of balls
            for (int i = 0; i < Row_Count; i++)
            {
                for (int j = 0; j < Column_Count; j++)
                {
                    //will only display balls if they are alive 
                    //because our array is of 16*12 matrix but our GDI window is of 800*600
                    //thats why we are  multiplying our current location with size of ball
                    //so its fits inside our GDI window
                    if(Ballz_array[i, j].Current_State==State.Alive)
                    {
                        Ballzz.AddEllipse(i * Ball_Size, j * Ball_Size, Ball_Size, Ball_Size, Ballz_array[i, j].Ballz_Color);
                    }
                }

            }

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int BallsAlive()
        //Purpose:this method will return total number of alive balls
        //Parameters:no parameters
        //Returns: int AliveBalls
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private int BallsAlive()
        {
            //initialyy total number of balls are 192
            int AliveBalls = 192;

            //iterating through array 
            for (int i = 0; i < Row_Count; i++)
            {
                for (int j = 0; j < Column_Count; j++)
                {
                    //if current state of ball is dead its mean they have been killed
                    if (Ballz_array[i, j].Current_State == State.Dead)
                    {
                        AliveBalls--;//decrementing total number of balls
                    }
                }
            }

            return AliveBalls;//returning total number of balls Alive
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //public int CheckBalls(int row,int column,Color ToCompareColor)
        //Purpose:This is Recursive method
        //       :this method will check for total number of alive balls that are of same color
        //        and are ajacent to selected ball(the ball which user want to remove by mouse click)
        //Parameters:int row =total number of rows in array
        //          :int column=total number of column in array
        //          :Color ToCompareColor=current color to compare
        //Returns: int sum:total number of ball killed in one click
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public int CheckBalls(int row,int column,Color ToCompareColor)
        {
            int sum=0 ;//initialy zero
            
            /* Base Condition:
            * we want to stay within boundary of array
            * if color we are comparing is not same as current color of ball to be killed
            * and if ball is already killed that is it is in 'Dead State'
            */
            if (row >= 16 || row < 0 || column >= 12 || column < 0 || (Ballz_array[row,column].Ballz_Color!=ToCompareColor)|| (Ballz_array[row, column].Current_State== State.Dead))
            {
                return 0;//return zero
            }
            else
            {
                /*
                 * everytime the ball is killed the sum will increment
                 *   and will returm total number of ball killed in per click
                */
                sum++;
                
                //assigning current state to Dead
                Ballz_array[row, column].Current_State = State.Dead;

                //checking in all four direction for ball of same color
                sum += CheckBalls(row - 1, column, ToCompareColor);//left
                sum += CheckBalls(row + 1, column, ToCompareColor);//right
                sum += CheckBalls(row , column-1, ToCompareColor);//top
                sum += CheckBalls(row, column + 1, ToCompareColor);//bottom

                return sum;//returning total number of balls killed in per pick 
            }
            
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int StepDown()
        //Purpose:This method will help the ball to fall into the the spot which has been already killed
        //Parameters:no parameters
        //Returns: int Num_balls_dropped
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private int StepDown()
        {
            int Num_Balls_Dropped = 0;//number of balls dropped

            //iterrating throught array
            for(int i=0;i<Row_Count;i++)
            {
                for(int j=1;j<Column_Count;j++)
                {
                    //my ball at current location is dead but ball above it is still alive
                    if ((Ballz_array[i,j].Current_State==State.Dead )&&(Ballz_array[i, j - 1].Current_State == State.Alive))
                    {
                       //then changing color of that ball with ball at top
                        Ballz_array[i, j].Ballz_Color = Ballz_array[i,j-1].Ballz_Color;

                        //then ball at top will now be in dead state
                        Ballz_array[i, j - 1].Current_State = State.Dead;

                        //and ball below it is now in  alive state
                        Ballz_array[i, j].Current_State = State.Alive;
                        
                        Num_Balls_Dropped++;//incrementing number of total value
                    }
                }
            }


            //showing animation acording to the animation value selected by user
            Thread.Sleep(ShowAnimation_dl.Animation);

            //now displaying balls
            Display();

            return Num_Balls_Dropped;//returning total number of balls dropped
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int FallDown()
        //Purpose:This method will call the Step down method untill my number of balls are not equal to zero
        //       : so that user next click is not capture untill all balls dropped
        //Parameters:no parameters
        //Returns: int count_Stepdown
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private int FallDown()
        {
            int count_Stepdown = 0;

            //untill all balls fall down
            while(StepDown() != 0)
            {
                StepDown();
                count_Stepdown++;//incrementing count
            }
           
            return count_Stepdown;//returning stepdown
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int Pick()
        //Purpose:This method will get last mouse left click and will call checkballs method to and will kill the balls
        //Parameters:no parameters
        //Returns: int score_fromPick
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private int Pick()
        {
            int score_fromPick = 0;//score from pick
            Point Cordinate;//point where the user click on GDI window

            //because timer is running so it will always capture the mouse click everytime

            //so will check for last click whether it is true click or capture by timer
            //if it is capture by timer it will be false
            //else it will be user click
            if (Ballzz.GetLastMouseLeftClick(out Cordinate))
            {
                //current row and column
                int row; int coloumn;

                //because window is of 800*600
                //we will divide it by size of ball
                row = (Cordinate.X) / Ball_Size;//current row in array
                coloumn = (Cordinate.Y) / Ball_Size;//current column in array

                //we will get score in per pick(passing row,column,current color at that location)
                score_fromPick= CheckBalls(row, coloumn, Ballz_array[row, coloumn].Ballz_Color);

                //if more than one ball is killed then total score will be 
                // (50  per ball kill+'1 bonus per ball')
                //example if: 3 balls are killed=then total score will be => (3*50)+(3*10)
                if(score_fromPick>1)
                {
                    score_fromPick = (score_fromPick * 50) + (score_fromPick*10);
                }

                //if only one ball killed
                else
                {
                    score_fromPick = (score_fromPick * 50);
                }
   
            }

            //for animation we will call fall down method
            FallDown();

            return score_fromPick;//returning total score
        }

        //this event will update UI after every '100 ms'
        private void Timer_for_GDI_Tick(object sender, EventArgs e)
        {

            //if all balls are dead  
            if(BallsAlive()==0)
            {
                //clearing GDI window
                Ballzz.Clear();

                //displaying Message to the user on GDI window
                Ballzz.AddText("Game Over !", 50, Color.AliceBlue);

                //disabling timer 
                Timer_for_GDI.Enabled = false;

                //enabling play button again
                UI_Play_Btn.Enabled = true;

                ///////////////////////////Now if current player has highest score ever in the current game mode/////////////////
                //Then we will open a modal dialo of high score and will get name and current score of user and will store into file

                //for file name
                string file_name =" ";

                //foor reading file
                string sinput;

                //list to store name and score of previous player in that gakme mode
                List<string> Previousplayer = new List<string>();

                //clear list first
                Previousplayer.Clear();


                //if diificulty is 'easy'
                if (SelectDifficulty_ModalDialog.Selected_Difficulty_level==3)
                {
                    file_name = "EasyHighScore.txt";
                }

                //if diificulty is 'Medium'
                if (SelectDifficulty_ModalDialog.Selected_Difficulty_level == 4)
                {
                    file_name = "MediumHighScore.txt";
                }

                //if diificulty is 'Hard'
                if (SelectDifficulty_ModalDialog.Selected_Difficulty_level == 5)
                {
                    file_name = "HardHighScore.txt";
                }

                //first reading file
                try
                {
                    //if file was not exist before then we will create file with lowest score
                    if(!File.Exists(file_name))
                    {
                            StreamWriter srOut = new StreamWriter(file_name);
                            srOut.WriteLine("ABCDF");
                            srOut.WriteLine("1");
                            srOut.Close();
 
                    }
                    //first reading file
                    try
                    {
                        //file reader
                        StreamReader srInFile = new StreamReader(file_name);

                        //reading to the end of file
                        while ((sinput = srInFile.ReadLine()) != null)
                        {
                            //adding to list
                            Previousplayer.Add(sinput);
                        }

                        //closing file reader event
                        srInFile.Close();
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show(s.Message);//catching exception
                    }

                }
                catch (Exception s)
                {
                    MessageBox.Show(s.Message);//catching exception
                }

                
                
                //then writting into file only if user press ok in modal dialog
                try
                {

                   
                        //converting readed score from file to int
                        int.TryParse(Previousplayer[1], out HighestScore);
                        //if total score is greatest than previous player score
                        if (TotalScore > HighestScore)
                        {


                            //dialog will appear 
                            if (_highScore_dl.ShowDialog() == DialogResult.OK)
                            {
                                //stream writer
                                StreamWriter writer = new StreamWriter(file_name);

                                //high score will be equal to toal score
                                HighestScore = TotalScore;

                                //in first line writting name of player
                                writer.WriteLine(_highScore_dl.NameofPlayer);
                                //in second line writting total score
                                writer.WriteLine(HighestScore);
                                writer.Close();
                            }
                            else
                            {
                                MessageBox.Show("You do not wish to enter the name.");
                            }
                        }

                    
                }

                 
                catch (Exception s)
                {
                    MessageBox.Show(s.Message);
                }
            }

            //if balls are still alive
            else
            {
                //getting total score from pick method
                TotalScore += Pick();

                //displaying it in modelless dialog
                ShowScore_dl.TotalScore = TotalScore;
            }
        }
       
        //if user click play button 
        private void UI_Play_Btn_Click(object sender, EventArgs e)
        {
            //if object is no created
            if (SelectDifficulty_ModalDialog==null)
            {
                //object of modal dialog
                SelectDifficulty_ModalDialog = new Select_Difficulty();
            }

            //when play button is clicked we will created and user has not checked for animation we will create 
            //object for show animation dialog other wise we gonna get error for null reference because 
            //our balls in GDI will fall accordingly our selected animation speed
            if (ShowAnimation_dl==null)
            {
                ShowAnimation_dl = new ShowAnimation_Modeless();
            }

            //if it is null than create object for it 
            if (ShowScore_dl == null)
            {
                ShowScore_dl = new ShowScore_Modelless();
            }

            if(_highScore_dl==null)
            {
                _highScore_dl = new HighScore();
 
            }

            //if user selet difficulty level and press ok button
            if (SelectDifficulty_ModalDialog.ShowDialog()==DialogResult.OK)
            {
                //clearing console window
                Ballzz.Clear();

                //randomise balls color and state
                Randomize();

                //displaying ball on GDI window
                Display();

                UI_ShowScore_Cbx.Checked = true;//first time showing score window to user
                Timer_for_GDI.Enabled = true;//enabling timer if user click on play button
                UI_Play_Btn.Enabled = false;//disable play button

                //making total score 0 again
                TotalScore = 0;

                //high score will also be zero because there may be case when user click play
                //buton more than one time in current game
                //so always start from zero 
                HighestScore = 0;
            }

            
        }
        
        //this event will show or hide the 'Show Score' Dialog
        private void UI_ShowScore_Cbx_CheckedChanged(object sender, EventArgs e)
        {
            //if my 'Show Score' checkbox is cheked
            if (UI_ShowScore_Cbx.Checked==true)
            {
                //if it is null than create object for it 
                if (ShowScore_dl == null)
                {
                    ShowScore_dl = new ShowScore_Modelless();
                }
                if (ShowScore_dl != null)
                {
                    //invoking my method 
                    ShowScore_dl._del_ShowScore_formClosing = CallBackFormClosing_ShowScore;

                }
                //show dialog
                ShowScore_dl.Show();
            }
            else
            {
                ShowScore_dl.Hide();//if it is not checked then hide form
            }
        }

        //this event will show or hide the 'Show Animation Speed' Dialog
        private void UI_ShowAnimationSpeed_Cbx_CheckedChanged(object sender, EventArgs e)
        {
            if(UI_ShowAnimationSpeed_Cbx.Checked==true)
            {
                if(ShowAnimation_dl == null)
                {
                    ShowAnimation_dl = new ShowAnimation_Modeless();
                }
                if(ShowAnimation_dl!=null)
                {
                    //invoking my method 
                    ShowAnimation_dl.ShowAnimation_formClosing = CallBackFormClosing_ShowAnimation;   
                }
                ShowAnimation_dl.Show();
            }
            else
            {
                ShowAnimation_dl.Hide();
            }
        }

        //if user close 'Show Animation' checkbox then uncheck the checkbox
        private void CallBackFormClosing_ShowAnimation()
        {
            UI_ShowAnimationSpeed_Cbx.Checked = false;
        }

        //if user close 'Show Score' checkbox then uncheck the checkbox
        private void CallBackFormClosing_ShowScore()
        {
            UI_ShowScore_Cbx.Checked = false;
        }

       
    }
}
