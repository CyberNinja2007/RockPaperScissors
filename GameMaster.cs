using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    /// <summary>
    /// Represents a class that manage the game and compute winners and losers
    /// </summary>
    public class GameMaster
    {
        private string[] _availableMoves { get; }
        public string ComputerMove { get; private set; }
        public string UserMove { get; set; }

        /// <summary>
        /// Represents a constructor for GameMaster
        /// </summary>
        /// <param name="availableMoves">The array of moves that you want to be available</param>
        public GameMaster(string[] availableMoves)
        {
            _availableMoves = availableMoves;
        }

        /// <summary>
        /// Randomly generates computer move
        /// </summary>
        public void GenerateComputerMove()
        {
            ComputerMove = _availableMoves[new Random().Next(0,_availableMoves.Length-1)];
        }

        /// <summary>
        /// Computes who is the winner - computer user
        /// </summary>
        /// <returns>The winners move</returns>
        public string ComputeWinner()
        {
            if (UserMove == ComputerMove)
            {
                return "Draw!";
            }
            //
            int compIndex = Array.IndexOf(_availableMoves, ComputerMove);
            //
            int freeMovesCount = compIndex + _availableMoves.Length / 2 - _availableMoves.Length;
            Console.WriteLine(_availableMoves[compIndex+1]);
            //
            List<string> winnerMoves = new List<string>(_availableMoves.Length/2);

            //
            if (freeMovesCount >= 0)
            {
                for (int i = compIndex + 1; i < _availableMoves.Length  ; i++)
                {
                    winnerMoves.Add(_availableMoves[i]);
                }

                int j = 0;
                
                while (winnerMoves.Count != winnerMoves.Capacity)
                {
                    winnerMoves.Add(_availableMoves[j]);
                }
            }
            else
            {
                for (int i = compIndex + 1; freeMovesCount <= 0  ; freeMovesCount++, i++)
                {
                    winnerMoves.Add(_availableMoves[i]);
                }
            }

            foreach (var mov in winnerMoves)
            {
                Console.WriteLine(mov);
            }
            
            if (winnerMoves.Contains(UserMove))
            {
                return "User Win!";
            }

            return "Computer Win!";
        }
    }
}