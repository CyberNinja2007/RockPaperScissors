using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!CheckArgs(args))
            {
                Console.WriteLine(
                    "Error! You need to input an odd number of args and 3 or more.\nLike this: RockPaperScissors.exe rock paper scissors");
            }
            else
            {
                KeyGenerator generator = new KeyGenerator();
                byte[] secureKey = generator.GenerateKey();
                Encryptor encryptor = new Encryptor(secureKey);
                GameMaster gameMaster = new GameMaster(args);
                
                gameMaster.GenerateComputerMove();

                ProcessHash(encryptor, gameMaster.ComputerMove);
                
                PrintMoves(args);
                
                Console.WriteLine("Enter your move:");

                string userMove = Console.ReadLine();
                
                if (userMove == "0")
                {
                    Environment.Exit(0);
                }
                else if(userMove == "?")
                {
                    TableGenerator.GenerateTable(args);
                }
                else
                {
                    gameMaster.UserMove = args[Convert.ToInt32(userMove)-1];
                }
                
                Console.WriteLine("Your move: {0}",gameMaster.UserMove);
                Console.WriteLine("Computer move: {0}",gameMaster.ComputerMove);
                Console.WriteLine(gameMaster.ComputeWinner());
                Console.WriteLine("HMAC key: {0}",BitConverter.ToString(secureKey).Replace("-", string.Empty));
            }
        }

        
        /// <summary>
        /// Checks if the arguments match the rules
        /// </summary>
        /// <param name="args">The argumens you want to check</param>
        /// <returns>Bool statement of the validation</returns>
        private static bool CheckArgs(string[] args)
        {
            bool isArgsValid = true;
            
            if(args.Length % 2 == 0 || args.Length < 3)
                isArgsValid = false;

            var set = new HashSet<string>();
            foreach(string item in args)
                if (!set.Add(item))
                    isArgsValid = false;
            
            return isArgsValid;
        }

        /// <summary>
        /// Processing hash of the move you want to crypt
        /// </summary>
        /// <param name="encryptor">The encryptor</param>
        /// <param name="move">The move you want to crypt</param>
        private static void ProcessHash(Encryptor encryptor,string move)
        {
            string hash = encryptor.GenerateHash(move);
            Console.WriteLine("HMAС: {0}",hash);
        }

        /// <summary>
        /// Prints all available moves
        /// </summary>
        /// <param name="moves">The moves you want to print</param>
        private static void PrintMoves(string[] moves)
        {
            Console.WriteLine("Available moves:");
                
            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine("{0} - {1}",i+1,moves[i]);
            }
            Console.WriteLine("0 - exit\n? - help");
        }
    }
}