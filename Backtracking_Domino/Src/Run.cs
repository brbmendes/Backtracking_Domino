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
using System.Text;

namespace Backtracking_Domino.Src
{
    class Run
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
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
                        Game.startDomino(domino, availablePieces);
                        sw.Stop();

                        count++;
                        Console.WriteLine("Tempo de execução: \t {0}", sw.Elapsed.ToString());
                        Console.WriteLine("###########################################################################");
                    }
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
