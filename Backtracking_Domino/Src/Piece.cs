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
        public int rightSide { get; set; }
        public int leftSide { get; set; }
        public bool hasUsed { get; set; }

        public Piece(int leftSide, int rightSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.hasUsed = false;
        }

        public Piece(String line)
        {
            String[] splitted = line.Split(' ');
            this.leftSide = Convert.ToInt32(splitted[0].Trim());
            this.rightSide = Convert.ToInt32(splitted[1].Trim());
            this.hasUsed = false;
        }

        public void swapSides()
        {
            int aux = this.leftSide;
            this.leftSide = this.rightSide;
            this.rightSide = aux;
        }
    }
}
