namespace QuizConsoleProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question("What is the capital of South Africa ?",
                    new string[]{"Berlin", "Tokyo", "Pretoria", "Lagos"},
                    2
                ),
                new Question("Who created C#? ",
                    new string[]{"Elon Musk", "Felix", "Microsoft", "Google"},
                    2
                ),
                new Question("Who is 4+45 ",
                    new string[]{"100", "50", "250", "17"},
                    1
                )
            };

            Quiz quiz = new Quiz(questions);
            quiz.StartQuiz();

            Console.ReadLine();
        }
    }
}
