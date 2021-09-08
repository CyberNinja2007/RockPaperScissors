using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length % 2 == 0 || args.Length < 3)
            {
                Console.WriteLine(
                    "Error! You need to input an odd number of args and 3 or more.\nLike this: RockPaperScissors.exe rock paper scissors");
            }
            
        }
    }
}