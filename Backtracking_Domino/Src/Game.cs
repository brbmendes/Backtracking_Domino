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
    class Game
    {
        /// <summary>
        /// Show the Dominoes after finding a solution.
        /// </summary>
        /// <param name="domino">The solution found.</param>
        public static void showDomino(LinkedList<Piece> domino)
        {
            Console.WriteLine("Solution has found. The solution is: \n\n");
            foreach (Piece p in domino)
            {
                Console.Write("[ {0} : {1} ] ", p.leftSide, p.rightSide);
            }
            Console.Write("\n\n");
        }

        /// <summary>
        /// Show the Dominoes pieces after run all possibilities and not finding a solution.
        /// </summary>
        /// <param name="availablePieces">All pieces of Domino.</param>
        public static void showPieces(LinkedList<Piece> availablePieces)
        {
            Console.WriteLine("No solution has found. The pieces were: \n\n");
            foreach (Piece p in availablePieces)
            {
                Console.Write("[ {0} : {1} ] ", p.leftSide, p.rightSide);
            }
            Console.Write("\n\n");
        }

        /// <summary>
        /// Start the game.
        /// </summary>
        /// <param name="domino">The Domino will be mounted.</param>
        /// <param name="availablePieces">All pieces of Domino.</param>
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

        /// <summary>
        /// Verify if a piece can fit in the Domino.
        /// </summary>
        /// <param name="domino">The Domino will be mounted.</param>
        /// <param name="availablePieces">All pieces of Domino.</param>
        /// <returns>True if a piece fit, false otherwise.</returns>
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
    }
}