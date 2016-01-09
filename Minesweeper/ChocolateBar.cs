using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

//Brian Tran
//January 2015
//Chocolate Square class
//To manipulate the whole grid of squares in the minesweeper-like game
namespace Culminating
{
    public class ChocolateBar
    {
        //Fields
        private int mSquareSize, mBarLength, mTopLeftPadding, mPeanutsLeft, mSquaresLeft, mSecondsElapsed;
        private ChocolateSquare[,] mChocolateBar;
        private bool mReachedEnd;

        //Constructor
        public ChocolateBar(int BarLength, int SquareSize, int TopLeftPadding)
        {
            this.mBarLength = BarLength;
            this.mSquareSize = SquareSize;
            this.mTopLeftPadding = TopLeftPadding;
            this.mSecondsElapsed = 0;
            this.mReachedEnd = false;
            this.mChocolateBar = new ChocolateSquare[this.mBarLength, this.mBarLength];
            this.mPeanutsLeft = (int)Math.Pow(this.mBarLength, 2) / 10;
            this.mSquaresLeft = (int)Math.Pow(this.mBarLength, 2) - this.mPeanutsLeft;

            //Initialize all squares
            for (int i = 0; i < this.mChocolateBar.GetLength(0); i++)
            {
                for (int j = 0; j < this.mChocolateBar.GetLength(1); j++)
                {
                    this.mChocolateBar[i, j] = new ChocolateSquare();
                }
            }

            //Randomize peanut placement and assign other tiles
            Random rand = new Random();
            int RowIndex, ColIndex;
            //Set the appropriate number of peanut squares
            for (int i = 0; i < this.mPeanutsLeft; i++)
            {
                //Find a random square that has not yet been initialized to place a peanut
                do
                {
                    RowIndex = rand.Next(this.mBarLength);
                    ColIndex = rand.Next(this.mBarLength);

                } while (this.mChocolateBar[RowIndex, ColIndex].ContainsPeanut != false);

                //Set a peanut square and set PeanutsAdjacent to 0 b/c it doesn't matter for a peanut square
                this.mChocolateBar[RowIndex, ColIndex].ContainsPeanut = true;
                //Set the underlying peanut texture
                this.mChocolateBar[RowIndex, ColIndex].UnderTexture = Properties.Resources.AluminumTilePeanut;

                //Increment the adjacent peanut count of adjacent squares
                //Above
                if (RowIndex > 0) this.mChocolateBar[RowIndex - 1, ColIndex].PeanutsAdjacent++;
                //Below
                if (RowIndex + 1 < this.mBarLength) this.mChocolateBar[RowIndex + 1, ColIndex].PeanutsAdjacent++;
                //Left
                if (ColIndex > 0) this.mChocolateBar[RowIndex, ColIndex - 1].PeanutsAdjacent++;
                //Right
                if (ColIndex + 1 < this.mBarLength) this.mChocolateBar[RowIndex, ColIndex + 1].PeanutsAdjacent++;
                //Top Left
                if (RowIndex > 0 && ColIndex > 0) this.mChocolateBar[RowIndex - 1, ColIndex - 1].PeanutsAdjacent++;
                //Top Right
                if (RowIndex > 0 && ColIndex + 1 < this.mBarLength) this.mChocolateBar[RowIndex - 1, ColIndex + 1].PeanutsAdjacent++;
                //Bottom Left
                if (RowIndex + 1 < this.mBarLength && ColIndex > 0) this.mChocolateBar[RowIndex + 1, ColIndex - 1].PeanutsAdjacent++;
                //Bottom Right
                if (RowIndex + 1 < this.mBarLength && ColIndex + 1 < this.mBarLength) this.mChocolateBar[RowIndex + 1, ColIndex + 1].PeanutsAdjacent++;
            }

            //Loop through and set underlying textures based on peanuts adjacent
            for (int i = 0; i < this.mChocolateBar.GetLength(0); i++)
            {
                for (int j = 0; j < this.mChocolateBar.GetLength(1); j++)
                {
                    //Only set if it is not already a peanut square
                    if (this.mChocolateBar[i, j].ContainsPeanut == false)
                    {
                        if (this.mChocolateBar[i, j].PeanutsAdjacent == 0) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile;
                        else if (this.mChocolateBar[i, j].PeanutsAdjacent == 1) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile1;
                        else if (this.mChocolateBar[i, j].PeanutsAdjacent == 2) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile2;
                        else if (this.mChocolateBar[i, j].PeanutsAdjacent == 3) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile3;
                        else if (this.mChocolateBar[i, j].PeanutsAdjacent == 4) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile4;
                        else if (this.mChocolateBar[i, j].PeanutsAdjacent == 5) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile5;
                        else if (this.mChocolateBar[i, j].PeanutsAdjacent == 6) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile6;
                        else if (this.mChocolateBar[i, j].PeanutsAdjacent == 7) this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile7;
                        else this.mChocolateBar[i, j].UnderTexture = Properties.Resources.AluminumTile8;
                    }
                }
            }
        }

        //Properties
        public int SquareSize
        {
            get { return this.mSquareSize; }
            set { this.mSquareSize = value; }
        }
        public int BarLength
        {
            get { return this.mBarLength; }
            set { this.mBarLength = value; }
        }
        public int TopLeftPadding
        {
            get { return this.mTopLeftPadding; }
            set { this.mTopLeftPadding = value; }
        }
        public int PeanutsLeft
        {
            get { return this.mPeanutsLeft; }
            set { this.mPeanutsLeft = value; }
        }
        public int SquaresLeft
        {
            get { return this.mSquaresLeft; }
            set { this.mSquaresLeft = value; }
        }
        public int SecondsElapsed
        {
            get { return this.mSecondsElapsed; }
            set { this.mSecondsElapsed = value; }
        }
        public bool ReachedEnd
        {
            get { return this.mReachedEnd; }
            set { this.mReachedEnd = value; }
        }

        //Methods
        //Draw the whole grid of chocolate squares
        public void Draw(Graphics g, int MenuStripHeight)
        {
            //Loop through each square in the grid
            for (int i = 0; i < this.mChocolateBar.GetLength(0); i++)
            {
                for (int j = 0; j < this.mChocolateBar.GetLength(1); j++)
                {
                    //For X, base it off of the column (j); for Y, base it off of the row (i)
                    this.mChocolateBar[i, j].Draw(g, this.mTopLeftPadding + (j * this.mSquareSize), this.mTopLeftPadding + (i * this.mSquareSize) + MenuStripHeight, this.mSquareSize);
                }
            }
        }

        //Return a certain square in the grid
        public ChocolateSquare GetSquare(int RowIndex, int ColIndex)
        {
            return this.mChocolateBar[RowIndex, ColIndex];
        }
    }
}
