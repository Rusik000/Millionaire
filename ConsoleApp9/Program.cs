using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;


namespace simpleExamProgram
{
    class Program
    {

        public static void PrintPoint(int points)
        {
            Console.Write("Exam ended. Your points : ");

            if (points > 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else if (points > 80)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }

            else if (points > 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }

            else if (points > 60)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            else if (points > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(points);
            Console.ResetColor();

        }

        public static void GetData(out string[] questions, out string[][] answers)
        {
            const int questionsCount = 10;

            questions = new string[questionsCount];
            answers = new string[questionsCount][];

            questions[0] = "Where is the cultural capital of Azerbaijan?  ";
            answers[0] = new string[4];
            answers[0][0] = "Baku    ";
            answers[0][1] = "Shusha  ";
            answers[0][2] = "Ganja   ";

            answers[0][3] = answers[0][1];

            questions[1] = " In what year was the first iPhone released ?  ";
            answers[1] = new string[4];
            answers[1][0] = "2006 ";
            answers[1][1] = "2007 ";
            answers[1][2] = "2005 ";

            answers[1][3] = answers[1][1];

            questions[2] = "What is the golden rule in programming ?  ";
            answers[2] = new string[4];
            answers[2][0] = "Write code carefully";
            answers[2][1] = "Work with Debug";
            answers[2][2] = "If it works, don’t touch it ";
            answers[2][3] = answers[2][2];

            questions[3] = " How many actors have played the role of James Bond?   ";
            answers[3] = new string[4];
            answers[3][0] = "Nine    ";
            answers[3][1] = "Six     ";
            answers[3][2] = "Seven   ";
            answers[3][3] = answers[3][0];

            questions[4] = "What company is also the name of one of the longest rivers in the world? ";
            answers[4] = new string[4];
            answers[4][0] = "Adidas ";
            answers[4][1] = "Burger King ";
            answers[4][2] = "Amazon     ";
            answers[4][3] = answers[4][2];

            questions[5] = "What currency is used in Turkey?   ";
            answers[5] = new string[4];
            answers[5][0] = "Dollar   ";
            answers[5][1] = "Turkish Lira  ";
            answers[5][2] = "Azn   ";
            answers[5][3] = answers[5][1];

            questions[6] = "In the Harry Potter book series, which character is described as having a “wild, tangled beard”?   ";
            answers[6] = new string[4];
            answers[6][0] = "Prisoner of Azkaban ";
            answers[6][1] = "Chamber of Secrets ";
            answers[6][2] = "Hagrid ";
            answers[6][3] = answers[6][2];

            questions[7] = "How many hearts does an octopus have ? ";
            answers[7] = new string[4];
            answers[7][0] = "Three   ";
            answers[7][1] = "Two   ";
            answers[7][2] = "Five  ";
            answers[7][3] = answers[7][0];

            questions[8] = "The tallest building in the world is located in which city?  ";
            answers[8] = new string[4];
            answers[8][0] = "London ";
            answers[8][1] = "New York ";
            answers[8][2] = "Dubai  ";
            answers[8][3] = answers[8][2];

            questions[9] = "When  C programming languange is invented? ";
            answers[9] = new string[4];
            answers[9][0] = "Between 1973 and 1974";
            answers[9][1] = "Between 1972 and 1973  ";
            answers[9][2] = "Between 1971 and 1972  ";
            answers[9][3] = answers[9][1];
        }

        public static sbyte GetAnswerIndex(string answer)
        {
            if (!String.IsNullOrWhiteSpace(answer))
            {
                char variant = (char)(answer.ToUpper().ToCharArray()[0]);
                if (variant.Equals('A') || variant.Equals(('B')) || variant.Equals('C'))
                {
                    return (sbyte)(variant - 65);
                }
            }
            return -1;
        }

        public static void PrintAnswers(string[] answers)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{(char)(65 + i)} {answers[i]} ");
            }
        }

        public static void PrintCorrectAnswer(string[] answers)
        {
            for (int i = 0; i < 3; i++)
            {
                if (answers[i] != answers[3])
                {

                    Console.WriteLine($"{(char)(65 + i)} {answers[i]} ");

                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{(char)(65 + i)} {answers[i]} ");
                Console.ResetColor();
            }
        }

        public static void PrintCorrectAndWrongAnswer(string[] answers, byte wrongAnswer)
        {
            for (int i = 0; i < 3; i++)
            {
                if (answers[i] == answers[3])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{(char)(65 + i)} {answers[i]} ");
                    Console.ResetColor();
                    continue;
                }

                else if (i == wrongAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{(char)(65 + i)} {answers[i]}");
                    Console.ResetColor();
                    continue;
                }
                Console.WriteLine($"{(char)(65 + i)} {answers[i]} ");

            }
        }

        public static string[] GetRandomAnswers(string[] answers)
        {
            var random = new Random();
            var randomAnswers = new string[4];
            var numbers = String.Empty;
            var counter = 0;

            while (counter < 3)
            {
                var index = random.Next(0, 3);
                if (!numbers.Contains(index.ToString()))
                {
                    numbers += index.ToString();
                    randomAnswers[index] = answers[counter];
                    counter++;
                }
            }

            randomAnswers[3] = answers[3]; 
            return randomAnswers;

        }


        public static void Run(byte counter)
        {
            Console.Title = " Do you want to become Millionare ? ";

            GetData(out string[] questions, out string[][] answers);

            var points = 0;

            for (int i = 0; i < questions.GetLength(0); i++)
            {
                counter++;
                var randomAnswers = GetRandomAnswers(answers[i]);

                if (i == 9)
                {

                    Console.WriteLine($"Question {i + 1}");
                    Console.WriteLine($"{questions[i]} ");

                }

                if (i < 9)
                {
                    Console.WriteLine($"Question {i + 1} ");
                    Console.WriteLine($"{questions[i]} ");
                }

                PrintAnswers(randomAnswers);
                sbyte answerIndex;

                while (true)
                {
                    Console.Write("Your answer: ");
                    var answer = Console.ReadLine();
                    answerIndex = GetAnswerIndex(answer);
                    if (answerIndex >= 0)
                        break;
                    Console.WriteLine("Please, input correct answer!");
                }

                if (i == 9)
                {
                    Console.Clear();

                    Console.WriteLine($"Question {i + 1}");
                    Console.WriteLine($"{questions[i]}");



                }

                if (i < 9)
                {
                    Console.Clear();
                    Console.WriteLine($"Question {i + 1}");
                    Console.WriteLine($"{questions[i]}");
                }


                if (randomAnswers[answerIndex] == randomAnswers[3])
                {

                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Correct.Wav";
                    player.Play();

                    PrintCorrectAnswer(randomAnswers);
                    points += 10;
                }

                else
                {
                    SoundPlayer player2 = new SoundPlayer();
                    player2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Wrong.Wav";
                    player2.Play();
                    PrintCorrectAndWrongAnswer(randomAnswers, (byte)answerIndex);
                    if (points != 0)
                        points -= 10;
                }
                if (i == questions.Length - 1)
                    Console.WriteLine("Press enter to continue");
                else
                    Console.WriteLine("Press enter for next question.");
                Console.ReadLine();
                Console.Clear();
            }
            PrintPoint(points);
        }


        static void Main(string[] args)
        {
            Run(0);
        }
    }
}