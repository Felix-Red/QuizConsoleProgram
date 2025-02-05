using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizConsoleProgram
{
    internal class Quiz
    {
        private Question[] questions;
        private int score;

        public Quiz(Question[] questions)
        {
            this.questions = questions;
            score = 0;
        }

        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int questionNumber = 1;
            foreach (Question question in questions)
            {
                Console.WriteLine($"Question {questionNumber++}: ");
                DisplayQuestions(question);
                int userChoice = GetUserChoice();
                if (question.IsCorrect(userChoice))
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect! correct answer is {question.Answers[question.CorrectAnswerIndex]}");
                }
            }

            DisplayResults();

        }
        private void DisplayResults()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                                 Results                                                ");
            Console.WriteLine("===============================================================================");
            Console.ResetColor();

            Console.WriteLine($"Quiz is completed your score is {score} out of {questions.Length}");

            double pecentage = (double)score / questions.Length;

            if (pecentage > 0.7) 
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Excellent work");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep trying you will get it");
                Console.ResetColor();
            }
        }

        private void DisplayQuestions(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                                 Question                                                ");
            Console.WriteLine("===============================================================================");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);
            for (int i = 0; i < question.Answers.Length; i++) 
            {
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" ");
                Console.Write(i + 1);
                Console.ResetColor();
                Console.WriteLine($". {question.Answers[i]}");
            }

        }

        private int GetUserChoice()
        {
            Console.Write("Your answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)  
            {
                Console.WriteLine("Invalid choice please enter a number");
                input = Console.ReadLine();
            }
            return choice - 1; //Adjusing to 0-index
        }
    }
}
