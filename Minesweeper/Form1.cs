using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//Brian Tran
//January 2015
//CPT: Minesweeper / Chocolate Sweeper
//To create a minesweeper-like game using an array of objects and recursion
namespace Culminating
{
    public partial class Form1 : Form
    {
        string HighScores = "HighScores.txt";

        public Form1()
        {
            InitializeComponent();

            //Create highscore file
            if (File.Exists(HighScores) == false)
            {
                File.CreateText(HighScores);
            }
        }

        //Global grid, padding, square size, and bar length
        ChocolateBar ChocolateGrid;
        int TopLeftPadding = 50;
        int SquareSize = Properties.Resources.ChocolateTile.Height;
        int BarLength;

        //Start a new beginner game
        private void mnuGameNewGameBeginner_Click(object sender, EventArgs e)
        {
            //Change square size and bar length
            BarLength = 10;
            SquareSize = Properties.Resources.ChocolateTile.Height;

            //Resize Form and centre
            this.Width = (TopLeftPadding * 2) + (SquareSize * BarLength) + 7; //The 7 accounts for the window border
            this.Height = this.Width + 20;
            this.CenterToScreen();

            //Create a new beginner game grid and invalidate it to draw as well as remove previous drawings
            ChocolateGrid = new ChocolateBar(BarLength, SquareSize, TopLeftPadding);
            this.Invalidate();

            //Enable hover detection timer, reset time display, and display number of peanuts left
            timer1.Enabled = true;
            lblSecondsElapsed.Text = ChocolateGrid.SecondsElapsed.ToString();
            lblPeanutsLeft.Text = ChocolateGrid.PeanutsLeft.ToString();
        }

        //Start a new intermediate game
        private void mnuGameNewGameIntermediate_Click(object sender, EventArgs e)
        {
            //Change square size and bar length
            BarLength = 20;
            SquareSize = (Screen.PrimaryScreen.WorkingArea.Height - 120) / BarLength;


            //Resize Form and centre
            this.Width = (TopLeftPadding * 2) + (SquareSize * BarLength) + 7; //The 7 accounts for the window border
            this.Height = this.Width + 20;
            this.CenterToScreen();

            //Create a new intermediate game grid and draw it
            ChocolateGrid = new ChocolateBar(BarLength, SquareSize, TopLeftPadding);
            this.Invalidate();

            //Enable hover detection timer, reset time display, and display number of peanuts left
            timer1.Enabled = true;
            lblSecondsElapsed.Text = ChocolateGrid.SecondsElapsed.ToString();
            lblPeanutsLeft.Text = ChocolateGrid.PeanutsLeft.ToString();
        }

        //Start a new expert game
        private void mnuGameNewGameExpert_Click(object sender, EventArgs e)
        {
            //Change square size and bar length
            BarLength = 30;
            SquareSize = (Screen.PrimaryScreen.WorkingArea.Height - 120) / BarLength;

            //Resize Form and centre
            this.Width = (TopLeftPadding * 2) + (SquareSize * BarLength) + 7; //The 7 accounts for the window border
            this.Height = this.Width + 20;
            this.CenterToScreen();

            //Create a new intermediate game grid and draw it
            ChocolateGrid = new ChocolateBar(BarLength, SquareSize, TopLeftPadding);
            this.Invalidate();

            //Enable hover detection timer, reset time display, and display number of peanuts left
            timer1.Enabled = true;
            lblSecondsElapsed.Text = ChocolateGrid.SecondsElapsed.ToString();
            lblPeanutsLeft.Text = ChocolateGrid.PeanutsLeft.ToString();
        }

        private void mnuGameHighscores_Click(object sender, EventArgs e)
        {
            //Display high scores in a form
            Highscores ScoreForm = new Highscores();
            ScoreForm.Show();
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are a person who loves to eat chocolate, but hates the peanuts.\n\n" +
            "Left click on a square to eat it and and all of the non-peanut squares nearby.\n" +
            "A numbered square will tell you how many peanut squares are adjacent to it, including diagonally.\n" +
            "Eat all of the non-peanut squares to win!\nHowever, if you eat a peanut square, you lose!\n\n" +
            "There are some tools you can use to help you:\n" +
            "- Right click a tile to mark it as a hazardous peanut tile\n" +
            "- Right click a tile again to mark it as unknown\n" +
            "- Right click again to remove the markings\n" +
            "Note: You must remove markings to click a square\n\n" +
            "Good luck!", "Chocolate Sweeper");
        }

        private void mnuGameExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Confirm exit
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Chocolate Sweeper", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        //Redraw form if resized or moved
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (ChocolateGrid != null)
            {
                Draw();
            }
        }
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (ChocolateGrid != null)
            {
                Draw();
            }
        }

        //Call the tile draw method when OnPaint runs
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Redraw the chocolate game grid
            if (ChocolateGrid != null)
            {
                Draw();
            }
        }
        
        //Method to draw the game's grid or a single square
        public void Draw()
        {
            Graphics g = this.CreateGraphics();
            ChocolateGrid.Draw(g, menuStrip1.Height);
            g.Dispose();
        }

        //When the user clicks the form, check for a square click
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Make sure the game has begun and has not ended
            if (ChocolateGrid != null && ChocolateGrid.ReachedEnd == false)
            {
                //Get the X and Y position of cursor
                int MouseX = e.X;
                int MouseY = e.Y;

                //Check if the cursor is inside the bounds of the grid
                if (MouseX > TopLeftPadding && MouseY > TopLeftPadding + menuStrip1.Height)
                {
                    int RowIndex = (MouseY - TopLeftPadding - menuStrip1.Height) / SquareSize;
                    int ColIndex = (MouseX - TopLeftPadding) / SquareSize;

                    //Final check for valid click
                    if (RowIndex < ChocolateGrid.BarLength && ColIndex < ChocolateGrid.BarLength)
                    {
                        //Get the square and change the status accordingly
                        ChocolateSquare CursorSquare = ChocolateGrid.GetSquare(RowIndex, ColIndex);

                        //Start the timer if not already started
                        if (timer2.Enabled == false) timer2.Enabled = true;

                        //Actions available for an unclicked square
                        if (CursorSquare.Status == ChocolateSquare.State.Unclicked)
                        {
                            //Check left or right click
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                //Peanut click - lose
                                if (CursorSquare.ContainsPeanut)
                                {
                                    ChocolateGrid.ReachedEnd = true;
                                    timer1.Enabled = false;
                                    timer2.Enabled = false;

                                    //Set all peanut tiles to clicked
                                    for (int i = 0; i < ChocolateGrid.BarLength; i++)
                                    {
                                        for (int j = 0; j < ChocolateGrid.BarLength; j++)
                                        {
                                            ChocolateSquare TempSquare = ChocolateGrid.GetSquare(i, j);
                                            if (TempSquare.ContainsPeanut)
                                            {
                                                TempSquare.Status = ChocolateSquare.State.Clicked;
                                            }
                                        }
                                    }

                                    Draw();
                                    MessageBox.Show("You lose!", "Chocolate Sweeper");
                                }

                                //Number square click
                                else if (CursorSquare.PeanutsAdjacent > 0)
                                {
                                    //Decrement remaining squares by one and check win
                                    CursorSquare.Status = ChocolateSquare.State.Clicked;
                                    ChocolateGrid.SquaresLeft--;

                                    //Check win
                                    if (ChocolateGrid.SquaresLeft == 0)
                                    {
                                        ChocolateGrid.ReachedEnd = true;
                                        timer1.Enabled = false;
                                        timer2.Enabled = false;

                                        //Set all peanut tiles to flagged
                                        for (int i = 0; i < ChocolateGrid.BarLength; i++)
                                        {
                                            for (int j = 0; j < ChocolateGrid.BarLength; j++)
                                            {
                                                ChocolateSquare TempSquare = ChocolateGrid.GetSquare(i, j);
                                                if (TempSquare.ContainsPeanut)
                                                {
                                                    TempSquare.Status = ChocolateSquare.State.Flagged;
                                                    TempSquare.OverTexture = Properties.Resources.ChocolateTileFlag;
                                                }
                                            }
                                        }

                                        Draw();
                                        MessageBox.Show("You win!", "Chocolate Sweeper");

                                        //Record any highscores
                                        ScoreCheck();
                                    }
                                }

                                //Empty square click
                                else
                                {
                                    //Recursively reveal tiles that are connected - more info in the method
                                    NeutralClickReveal(RowIndex, ColIndex);

                                    //Check win
                                    if (ChocolateGrid.SquaresLeft == 0)
                                    {
                                        ChocolateGrid.ReachedEnd = true;
                                        timer1.Enabled = false;
                                        timer2.Enabled = false;

                                        //Set all peanut tiles to flagged
                                        for (int i = 0; i < ChocolateGrid.BarLength; i++)
                                        {
                                            for (int j = 0; j < ChocolateGrid.BarLength; j++)
                                            {
                                                ChocolateSquare TempSquare = ChocolateGrid.GetSquare(i, j);
                                                if (TempSquare.ContainsPeanut)
                                                {
                                                    TempSquare.Status = ChocolateSquare.State.Flagged;
                                                    TempSquare.OverTexture = Properties.Resources.ChocolateTileFlag;
                                                }
                                            }
                                        }

                                        Draw();
                                        MessageBox.Show("You win!", "Chocolate Sweeper");

                                        //Record any highscores
                                        ScoreCheck();
                                    }
                                }
                            }
                            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                            {
                                //Flag tile, change texture
                                CursorSquare.Status = ChocolateSquare.State.Flagged;
                                CursorSquare.OverTexture = Properties.Resources.ChocolateTileFlag;
                                Draw();

                                //Decrement peanuts left
                                ChocolateGrid.PeanutsLeft--;
                                lblPeanutsLeft.Text = ChocolateGrid.PeanutsLeft.ToString();
                            }
                        }
                        //Actions for flagged square
                        else if (CursorSquare.Status == ChocolateSquare.State.Flagged)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                            {
                                //Flag tile as unknown, change texture
                                CursorSquare.Status = ChocolateSquare.State.Unknown;
                                CursorSquare.OverTexture = Properties.Resources.ChocolateTileQuestion;
                                Draw();

                                //Increment peanuts left
                                ChocolateGrid.PeanutsLeft++;
                                lblPeanutsLeft.Text = ChocolateGrid.PeanutsLeft.ToString();
                            }
                        }
                        //Actions for unknown square
                        else if (CursorSquare.Status == ChocolateSquare.State.Unknown)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                            {
                                //Unflag tile, change texture
                                CursorSquare.Status = ChocolateSquare.State.Hover;
                                CursorSquare.OverTexture = Properties.Resources.ChocolateTileHover;
                                Draw();
                            }
                        }
                    }
                }
            }
        }

        //Checking for a left mouse down or up to use the corresponding image when drawing
        bool LeftMouseDown = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) LeftMouseDown = true;        
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            LeftMouseDown = false;
        }
        
        //Check for mouse hovering over a square or mouse down to change the tile image
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Make sure the game has begun
            if (ChocolateGrid != null)
            {
                //Get the X and Y position of cursor
                Point RelativePoint = this.PointToClient(Cursor.Position);
                int MouseX = RelativePoint.X;
                int MouseY = RelativePoint.Y;

                //Check if the cursor is inside the bounds of the grid
                if (MouseX > TopLeftPadding && MouseY > TopLeftPadding + menuStrip1.Height)
                {
                    int RowIndex = (MouseY - TopLeftPadding - menuStrip1.Height) / SquareSize;
                    int ColIndex = (MouseX - TopLeftPadding) / SquareSize;

                    if (RowIndex < ChocolateGrid.BarLength && ColIndex < ChocolateGrid.BarLength)
                    {
                        //Get the square and change the status accordingly
                        ChocolateSquare CursorSquare = ChocolateGrid.GetSquare(RowIndex, ColIndex);

                        if (CursorSquare.Status == ChocolateSquare.State.Unclicked)
                        {
                            if (LeftMouseDown)
                            {
                                CursorSquare.Status = ChocolateSquare.State.BeingClicked;
                                CursorSquare.OverTexture = Properties.Resources.ChocolateTileClick;
                            }
                            else
                            {
                                CursorSquare.Status = ChocolateSquare.State.Hover;
                                CursorSquare.OverTexture = Properties.Resources.ChocolateTileHover;
                            }
                        }
                    }
                }

                Draw();
            }
        }

        //Keep track of seconds elapsed
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Stop at 999,999
            if (ChocolateGrid.SecondsElapsed == 999999) timer2.Enabled = false;
            
            //Increment and output time
            ChocolateGrid.SecondsElapsed++;
            lblSecondsElapsed.Text = ChocolateGrid.SecondsElapsed.ToString();
        }

        //Recursively reveals squares to the left, right, top, and bottom if a neutral square is clicked
        public void NeutralClickReveal(int RowIndex, int ColIndex)
        {
            ChocolateSquare TempSquare = ChocolateGrid.GetSquare(RowIndex, ColIndex);

            //Only reveal if the square is not a peanut, is not flagged, is not question tagged, and is not clicked
            if (TempSquare.ContainsPeanut == false && TempSquare.Status != ChocolateSquare.State.Flagged &&
                TempSquare.Status != ChocolateSquare.State.Unknown && TempSquare.Status != ChocolateSquare.State.Clicked)
            {
                TempSquare.Status = ChocolateSquare.State.Clicked;
                ChocolateGrid.SquaresLeft--;

                //Only check adjacent tiles if the current revealed tile is not a number
                if (TempSquare.PeanutsAdjacent == 0)
                {
                    //Above
                    if (RowIndex > 0)
                    {
                        NeutralClickReveal(RowIndex - 1, ColIndex);
                    }
                    //Below
                    if (RowIndex + 1 < ChocolateGrid.BarLength)
                    {
                        NeutralClickReveal(RowIndex + 1, ColIndex);
                    }
                    //Left
                    if (ColIndex > 0)
                    {
                        NeutralClickReveal(RowIndex, ColIndex - 1);
                    }
                    //Right
                    if (ColIndex + 1 < ChocolateGrid.BarLength)
                    {
                        NeutralClickReveal(RowIndex, ColIndex + 1);
                    }
                    //Top Left
                    if (RowIndex > 0 && ColIndex > 0)
                    {
                        NeutralClickReveal(RowIndex - 1, ColIndex - 1);
                    }
                    //Top Right
                    if (RowIndex > 0 && ColIndex + 1 < ChocolateGrid.BarLength)
                    {
                        NeutralClickReveal(RowIndex - 1, ColIndex + 1);
                    }
                    //Bottom Left
                    if (RowIndex + 1 < ChocolateGrid.BarLength && ColIndex > 0)
                    {
                        NeutralClickReveal(RowIndex + 1, ColIndex - 1);
                    }
                    //Bottom Right
                    if (RowIndex + 1 < ChocolateGrid.BarLength && ColIndex + 1 < ChocolateGrid.BarLength)
                    {
                        NeutralClickReveal(RowIndex + 1, ColIndex + 1);
                    }
                }
            }
        }

        public void ScoreCheck()
        {
            //After a win, check for highscore and record the time
            string TempScoreBeginner;
            string TempScoreIntermediate;
            string TempScoreExpert;

            //Read in all scores to write later
            using (StreamReader ScoreReader = new StreamReader(HighScores))
            {
                TempScoreBeginner = ScoreReader.ReadLine();
                TempScoreIntermediate = ScoreReader.ReadLine();
                TempScoreExpert = ScoreReader.ReadLine();
            }

            if (BarLength == 10) //Beginner
            {
                //Check if no score or less elapsed time
                if (TempScoreBeginner == null || TempScoreBeginner == string.Empty || ChocolateGrid.SecondsElapsed < int.Parse(TempScoreBeginner))
                {
                    //Write new score and other modes' scores
                    using (StreamWriter ScoreWriter = new StreamWriter(HighScores))
                    {
                        ScoreWriter.WriteLine(ChocolateGrid.SecondsElapsed.ToString());
                        ScoreWriter.WriteLine(TempScoreIntermediate);
                        ScoreWriter.WriteLine(TempScoreExpert);
                    }
                }
            }
            else if (BarLength == 20) //Intermediate
            {
                //Check if no score or less elapsed time
                if (TempScoreIntermediate == null || TempScoreIntermediate == string.Empty || ChocolateGrid.SecondsElapsed < int.Parse(TempScoreIntermediate))
                {
                    //Write new score and other modes' scores
                    using (StreamWriter ScoreWriter = new StreamWriter(HighScores))
                    {
                        ScoreWriter.WriteLine(TempScoreBeginner);
                        ScoreWriter.WriteLine(ChocolateGrid.SecondsElapsed.ToString());
                        ScoreWriter.WriteLine(TempScoreExpert);
                    }
                }
            }
            else //Expert
            {
                //Check if no score or less elapsed time
                if (TempScoreExpert == null || TempScoreExpert == string.Empty || ChocolateGrid.SecondsElapsed < int.Parse(TempScoreExpert))
                {
                    //Write new score and other modes' scores
                    using (StreamWriter ScoreWriter = new StreamWriter(HighScores))
                    {
                        ScoreWriter.WriteLine(TempScoreBeginner);
                        ScoreWriter.WriteLine(TempScoreIntermediate);
                        ScoreWriter.WriteLine(ChocolateGrid.SecondsElapsed.ToString());
                    }
                }
            }
        }
    }
}
