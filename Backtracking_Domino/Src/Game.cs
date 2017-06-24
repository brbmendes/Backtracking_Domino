
// Author:          Bruno Bragança Mendes
// Date:            20/06/2017
// Last edition:    24/06/2017
// E-mail:          bruno.braganca@acad.pucrs.br

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var allPiecesWereUsed = availablePieces.All(piece => piece.hasUsed);

            if (allPiecesWereUsed)
            {
                return true;
            }

            foreach (Piece p in availablePieces)
            {
                if (!p.hasUsed)
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

            List<string[]> inputList = new List<string[]>();

            foreach (string inputFile in args)
            {
                var f = File.ReadAllLines(inputFile).Concat(new String[] { inputFile }).ToArray();
                inputList.Add(f);
            }

            #region Files list for read. DON'T FORGET TO CHANGE THE FILE NAMES.

            //string[] file0 = File.ReadAllLines(args[0]);
            //var file0 = File.ReadAllLines("case04.txt").Concat(new String[] { "case04.txt" }).ToArray();
            //var file1 = File.ReadAllLines("case06.txt").Concat(new String[] { "case06.txt" }).ToArray();
            //var file2 = File.ReadAllLines("case10.txt").Concat(new String[] { "case10.txt" }).ToArray();
            //var file3 = File.ReadAllLines("case11.txt").Concat(new String[] { "case11.txt" }).ToArray();
            //var file4 = File.ReadAllLines("case12.txt").Concat(new String[] { "case12.txt" }).ToArray();
            //var file5 = File.ReadAllLines("case13.txt").Concat(new String[] { "case13.txt" }).ToArray();
            //var file6 = File.ReadAllLines("case14.txt").Concat(new String[] { "case14.txt" }).ToArray();
            //var file7 = File.ReadAllLines("case15.txt").Concat(new String[] { "case15.txt" }).ToArray();
            //var file8 = File.ReadAllLines("case16.txt").Concat(new String[] { "case16.txt" }).ToArray();
            //var file9 = File.ReadAllLines("case18.txt").Concat(new String[] { "case18.txt" }).ToArray();

            //List<string[]> listOfFiles = new List<string[]>();
            //listOfFiles.Add(file0);
            //listOfFiles.Add(file1);
            //listOfFiles.Add(file2);
            //listOfFiles.Add(file3);
            //listOfFiles.Add(file4);
            //listOfFiles.Add(file5);
            //listOfFiles.Add(file6);
            //listOfFiles.Add(file7);
            //listOfFiles.Add(file8);
            //listOfFiles.Add(file9);

            #endregion

            int count = 1;
            //foreach (String[] file in listOfFiles)
            foreach (String[] file in inputList)
            {
                Console.WriteLine("###########################################################################");
                Console.WriteLine("\n\nReading File ==> {0}....\n", file.Last());
                var listPieces = file.Skip(1).TakeWhile(item => !(item.Equals(file.Last())));

                LinkedList<Piece> availablePieces = new LinkedList<Piece>();

                foreach (var line in listPieces)
                {
                    availablePieces.AddLast(new Piece(line));
                }

                LinkedList<Piece> domino = new LinkedList<Piece>();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                startDomino(domino, availablePieces);
                sw.Stop();

                count++;
                Console.WriteLine("Tempo de execução: \t {0}", sw.Elapsed.ToString());
                Console.WriteLine("###########################################################################");
            }
            Console.ReadKey();
        }
    }

}