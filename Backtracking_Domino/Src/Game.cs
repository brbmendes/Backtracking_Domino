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
using System.Diagnostics;
using System.IO;
using System.Linq;

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
            try
            {
                if(args.Length == 0)
                {
                    Console.WriteLine("Impossible run Backtracking_Domino without test files.");
                }
                else
                {
                    List<string[]> inputList = new List<string[]>();

                    foreach (string inputFile in args)
                    {
                        var f = File.ReadAllLines(inputFile).Concat(new String[] { inputFile }).ToArray();
                        inputList.Add(f);
                    }

                    int count = 1;
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
                }
                
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}