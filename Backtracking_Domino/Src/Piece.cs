
// Authors: Bruno Bragança Mendes e Andressa Fernanda Idalgo de Farias
// Date: 20/06/2017
// E-mail: bruno.braganca@acad.pucrs.br

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
