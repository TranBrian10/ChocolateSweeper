using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//Displays high scores
namespace Culminating
{
    public partial class Highscores : Form
    {
        string HighScores = "HighScores.txt";

        public Highscores()
        {
            InitializeComponent();

            //Write the scores
            OutputScores();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Closes the form
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Empty the file
            using (System.IO.StreamWriter ScoreWriter = new StreamWriter(HighScores))
            {
                ScoreWriter.Write(string.Empty);
                ScoreWriter.Close();
            }

            //Write the reset scores
            OutputScores();
        }

        public void OutputScores()
        {
            using (System.IO.StreamReader ScoreReader = new StreamReader(HighScores))
            {
                //If the line is empty, high score is 999
                string BeginnerScore = "9999";
                string IntermediateScore = "9999";
                string ExpertScore = "9999";
                string TempLine;

                //Read each line and if it isnt null or empty, then set the score variable
                TempLine = ScoreReader.ReadLine();
                if (TempLine != null && TempLine != string.Empty)
                {
                    BeginnerScore = TempLine;
                }
                TempLine = ScoreReader.ReadLine();
                if (TempLine != null && TempLine != string.Empty)
                {
                    IntermediateScore = TempLine;
                }
                TempLine = ScoreReader.ReadLine();
                if (TempLine != null && TempLine != string.Empty)
                {
                    ExpertScore = TempLine;
                }

                //Output the scores in a label
                lblHighscores.Text = "Best times:\n\n"
                    + "\nBeginner:        " + BeginnerScore + " seconds"
                    + "\nIntermediate:    " + IntermediateScore + " seconds"
                    + "\nExpert:          " + ExpertScore + " seconds";
            }
        }
    }
}
