using System.Collections.Generic;
using ConsoleTables;

namespace RockPaperScissors
{
    /// <summary>
    /// Represents a class that generates the table with all the results of moves
    /// </summary>
    public static class TableGenerator
    {
        /// <summary>
        /// Generates the table with results of moves
        /// </summary>
        /// <param name="args">The moves you want to be in table</param>
        /// <returns>The table with the results</returns>
        public static string GenerateTable(string[] args)
        {
            ConsoleTable table = new ConsoleTable("USER \\ PC");
            LinkedList<string> resultOfMoves = GenerateMoves(args.Length);

            table.AddColumn(args);

            for(int i = 0;i < args.Length; i++)
            {
                string[] temp = new string[args.Length+1];
                
                int j = 0;
                temp[j] = args[i];
                
                foreach (var move in resultOfMoves)
                {
                    j++;
                    temp[j] = move;
                }
                
                table.AddRow(temp);

                LinkedListNode<string> lastMove = resultOfMoves.Last;
                resultOfMoves.RemoveLast();
                resultOfMoves.AddFirst(lastMove);
            }

            return table.ToStringAlternative();
        }

        /// <summary>
        /// Generates default moves 
        /// </summary>
        /// <param name="length">The length of the moves, you want to generate</param>
        /// <returns>Returns generated moves</returns>
        private static LinkedList<string> GenerateMoves(int length)
        {
            LinkedList<string> resultOfMoves = new LinkedList<string>();
            
            resultOfMoves.AddFirst("DRAW");
            
            for (int i = 1; i <= length/2; i++)
            {
                resultOfMoves.AddLast("WIN");
            }
            
            for (int i = length/2+1; i < length; i++)
            {
                resultOfMoves.AddLast("LOSE");
            }

            return resultOfMoves;
        }
    }
}