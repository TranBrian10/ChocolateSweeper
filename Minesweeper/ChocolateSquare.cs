using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

//Brian Tran
//January 2015
//Chocolate Square class
//To manipulate a single square in the minesweeper-like game
namespace Culminating
{
    public class ChocolateSquare
    {
        //Enums
        public enum State{Unclicked, Hover, BeingClicked, Flagged, Unknown, Clicked};

        //Fields
        private State mStatus;
        private Image mOverTexture;
        private Image mUnderTexture;
        private bool mContainsPeanut;
        private int mPeanutsAdjacent;

        //Constructor
        public ChocolateSquare()
        {
            //Default unclicked, chocolate tile texture, 0 adjacent peanuts, no peanut (last two will be changed when peanuts are placed)
            this.mStatus = State.Unclicked;
            this.mOverTexture = Properties.Resources.ChocolateTile;
            this.mPeanutsAdjacent = 0;
            this.mContainsPeanut = false;
        }

        //Properties
        public State Status
        {
            get { return this.mStatus; }
            set { this.mStatus = value; }
        }
        public Image OverTexture
        {
            get { return this.mOverTexture; }
            set { this.mOverTexture = value; }
        }
        public Image UnderTexture
        {
            get { return this.mUnderTexture; }
            set { this.mUnderTexture = value; }
        }
        public bool ContainsPeanut
        {
            get { return this.mContainsPeanut; }
            set { this.mContainsPeanut = value; }
        }
        public int PeanutsAdjacent
        {
            get { return this.mPeanutsAdjacent; }
            set { this.mPeanutsAdjacent = value; }
        }

        //Methods
        //Draw the square based on the status and peanuts adjacent, using given coordinates
        public void Draw(Graphics g, int X, int Y, int SquareSize)
        {
            //Check the status of the square to draw the appropriate image
            if (this.mStatus != State.Clicked)
            {
                g.DrawImage(this.mOverTexture, X, Y, SquareSize, SquareSize);

                //Change any Hover or BeingClicked tiles back into regular tiles
                //If it is still supposed to be Hover or BeingClicked, the events/timer will change it back
                if (this.mStatus == State.Hover)
                {
                    this.mStatus = State.Unclicked;
                    this.mOverTexture = Properties.Resources.ChocolateTile;
                }
                else if (this.mStatus == State.BeingClicked)
                {
                    this.mStatus = State.Unclicked;
                    this.mOverTexture = Properties.Resources.ChocolateTile;
                }
            }
            else g.DrawImage(this.mUnderTexture, X, Y, SquareSize, SquareSize);
        }
    }
}
