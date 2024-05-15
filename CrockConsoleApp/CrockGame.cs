using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrockConsoleApp
{
    internal class CrockGame
    {
        private int _gameScore = 0;

        public void StartGame()
        {
            bool isGameRunning = true;

            while (isGameRunning)
            {
                Random rand = new Random();
                (int firstNumber, int secondNumber) = CreateRandomNumbers(rand);
                Console.WriteLine("Welcome to Crock Game! To terminate the app, type 'end'.");
                Console.WriteLine($"Player Score: {_gameScore}");
                Console.WriteLine($"{firstNumber} ? {secondNumber}");
                Console.WriteLine("Please use >, <, =");

                string userReply = Console.ReadLine().Trim().ToLower();

                if (userReply == "end")
                {
                    isGameRunning = false;
                }
                else
                {
                    CheckIfReplyIsCorrect(firstNumber, secondNumber, userReply);
                }
            }

            Console.WriteLine("Thank you for playing!");
        }


        private (int, int) CreateRandomNumbers(Random rand)
        {
            int firstNumber = rand.Next(1, 100);
            int secondNumber = rand.Next(1, 100);
            return (firstNumber, secondNumber);
        }

        internal void CheckIfReplyIsCorrect(int firstNumber, int secondNumber, string userReply)
        {
            char correctAnswer = firstNumber > secondNumber ? '>' : (firstNumber < secondNumber ? '<' : '=');

            if (!string.IsNullOrEmpty(userReply) && userReply.Trim() == correctAnswer.ToString())
            {
                Console.WriteLine("Correct! Amazing job.");
                _gameScore++;
            }
            else
            {
                Console.WriteLine($"Incorrect. The right answer was '{correctAnswer}'.");
            }
        }
    }
}
