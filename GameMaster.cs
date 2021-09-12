using System;
using System.Collections.Generic;

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
            //Searches for a index of a computer move
            int compIndex = Array.IndexOf(_availableMoves, ComputerMove);
            //Calc are there any win moves are in the head of the array
            int freeMovesCount = compIndex + _availableMoves.Length / 2 - _availableMoves.Length;
            
            List<string> winnerMoves = new List<string>(_availableMoves.Length/2);
            
            if (freeMovesCount >= 0)
            {
                //get all the win moves from the computer move to the tail
                for (int i = compIndex + 1; i < _availableMoves.Length  ; i++)
                {
                    winnerMoves.Add(_availableMoves[i]);
                }

                //get the rest win moves
                int j = 0;
                while (winnerMoves.Count != winnerMoves.Capacity)
                {
                    winnerMoves.Add(_availableMoves[j]);
                    j++;
                }
            }
            else
            {
                for (int i = compIndex + 1; freeMovesCount < 0  ; freeMovesCount++, i++)
                {
                    winnerMoves.Add(_availableMoves[i]);
                }
            }
            
            if (winnerMoves.Contains(UserMove))
            {
                return "User Win!";
            }

            return "Computer Win!";
        }
    }
}