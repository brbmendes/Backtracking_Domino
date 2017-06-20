
// Authors: Bruno Bragança Mendes e Andressa Fernanda Idalgo de Farias
// Date: 20/06/2017
// E-mail: bruno.braganca@acad.pucrs.br

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking_Domino.Src
{
    class Game
    {
        public static void showDomino(LinkedList<Piece> domino)
        {
            Console.WriteLine("Solution has found. The solution is: \n\n");
            foreach (Piece p in domino)
            {
                Console.Write("[ {0} : {1} ] ", p.leftSide, p.rightSide);
            }
            Console.Write("\n\n");
        }

        public static void showPieces(LinkedList<Piece> availablePieces)
        {
            Console.WriteLine("No solution has found. The pieces were: \n\n");
            foreach (Piece p in availablePieces)
            {
                Console.Write("[ {0} : {1} ] ", p.leftSide, p.rightSide);
            }
            Console.Write("\n\n");
        }

        public static void startDomino(LinkedList<Piece> domino, LinkedList<Piece> availablePieces)
        {
            bool haveHappyEnding = false;

            foreach (Piece p in availablePieces)
            {
                domino.AddLast(p);
                p.hasUsed = true;
                if (fitDominoPiece(domino, availablePieces) == true)
                {
                    haveHappyEnding = true;
                    break;
                }
                else
                {
                    domino.Remove(p);
                    p.hasUsed = false;
                    p.swapSides();
                    domino.AddLast(p);
                    p.hasUsed = true;
                    if (fitDominoPiece(domino, availablePieces) == true)
                    {
                        haveHappyEnding = true;
                        break;
                    }
                    else
                    {
                        if (domino.Count != 0)
                        {
                            domino.RemoveLast();
                            p.hasUsed = false;
                        }
                    }
                }
            }

            if (haveHappyEnding == false)
            {
                showPieces(availablePieces);
            }
            else
            {
                showDomino(domino);
            }
        }

        public static bool fitDominoPiece(LinkedList<Piece> domino, LinkedList<Piece> availablePieces)
        {
            var allPiecesWereUsed = availablePieces.All(piece => piece.hasUsed == true);

            if (allPiecesWereUsed == true)
            {
                return true;
            }

            foreach (Piece p in availablePieces)
            {
                if (p.hasUsed == false)
                {
                    if (domino.Last.Value.rightSide == p.leftSide)
                    {
                        domino.AddLast(p);
                        p.hasUsed = true;
                        if (fitDominoPiece(domino, availablePieces) == true)
                        {
                            return true;
                        }
                        else
                        {
                            domino.RemoveLast();
                            p.hasUsed = false;
                        }
                    }
                    else
                    {
                        p.swapSides();
                        if (domino.Last.Value.rightSide == p.leftSide)
                        {
                            domino.AddLast(p);
                            p.hasUsed = true;
                            if (fitDominoPiece(domino, availablePieces) == true)
                            {
                                return true;
                            }
                            else
                            {
                                domino.RemoveLast();
                                p.hasUsed = false;
                            }
                        }
                    }
                }
            }
            return false;
        }

        static void Main(string[] args)
        {

            #region Files list for read. DON'T FORGET TO CHANGE THE FILE NAMES.

            string[] file1 = File.ReadAllLines("game_1.txt");
            string[] file2 = File.ReadAllLines("game_2.txt");
            string[] file3 = File.ReadAllLines("game_3.txt");
            string[] file4 = File.ReadAllLines("game_4.txt");
            string[] file5 = File.ReadAllLines("game_5.txt");
            string[] file6 = File.ReadAllLines("game_6.txt");
            //string[] file7 = File.ReadAllLines("game_7.txt");
            //string[] file8 = File.ReadAllLines("game_8.txt");
            //string[] file9 = File.ReadAllLines("game_9.txt");
            //string[] file10 = File.ReadAllLines("game_10.txt");

            List<string[]> listOfFiles = new List<string[]>();
            listOfFiles.Add(file1);
            listOfFiles.Add(file2);
            listOfFiles.Add(file3);
            listOfFiles.Add(file4);
            listOfFiles.Add(file5);
            listOfFiles.Add(file6);
            //listOfFiles.Add(file7);
            //listOfFiles.Add(file8);
            //listOfFiles.Add(file9);
            //listOfFiles.Add(file10);

            #endregion

            int count = 1;
            foreach (String[] file in listOfFiles)
            {
                Console.WriteLine("###########################################################################");
                Console.WriteLine("\n\nReading File {0}....\n", count);
                var listPieces = file.Skip(1);
                LinkedList<Piece> availablePieces = new LinkedList<Piece>();

                foreach (var line in listPieces)
                {
                    availablePieces.AddLast(new Piece(line));
                }

                LinkedList<Piece> domino = new LinkedList<Piece>();

                startDomino(domino, availablePieces);
                count++;
                Console.WriteLine("###########################################################################");
            }
            Console.ReadKey();
        }
    }

}
