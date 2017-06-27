/// <summary>
/// exe             : Backtracking_Domino.exe
/// Description     : Backtracking solution to a Dominoes game
/// Usage           : In command line, run "Backtracking_Domino.exe X Y Z", where X, Y and Z are the test files to verify if exists at least one solution to that pieces. Submit at least one test file.
/// Output          : The Dominoes mounted or the list of pieces.
/// Author          : Bruno Bragança Mendes <bbmendes@gmail.com>
/// Date            : Mon, 2017 Jun 23, 13:44:51 BRT
/// Version         : 1.0
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backtracking_Domino.Src
{
    class Piece
    {
        /// <summary>
        /// Right side of a piece.
        /// </summary>
        public int rightSide { get; set; }

        /// <summary>
        /// Left side of a piece.
        /// </summary>
        public int leftSide { get; set; }

        /// <summary>
        /// Control key to verify if the piece has already used in the game.
        /// </summary>
        public bool hasUsed { get; set; }

        /// <summary>
        /// Single constructor of a piece.
        /// </summary>
        /// <param name="leftSide">The left side value of a piece.</param>
        /// <param name="rightSide">The right side value of a piece.</param>
        public Piece(int leftSide, int rightSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.hasUsed = false;
        }

        /// <summary>
        /// Construct a piece from a String.
        /// </summary>
        /// <param name="line">The string containing the both values (left and right) of a piece.</param>
        public Piece(String line)
        {
            String[] splitted = line.Split(' ');
            this.leftSide = Convert.ToInt32(splitted[0].Trim());
            this.rightSide = Convert.ToInt32(splitted[1].Trim());
            this.hasUsed = false;
        }

        /// <summary>
        /// Change the left and right value of a piece.
        /// </summary>
        public void swapSides()
        {
            int aux = this.leftSide;
            this.leftSide = this.rightSide;
            this.rightSide = aux;
        }
    }
}
