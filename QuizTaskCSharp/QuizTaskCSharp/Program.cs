namespace QuizTaskCSharp
{
    internal class Program
    {

        static void ShowAnswers(string[] answers)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(answers[i]);
            }
        }

        static string[] Mix(string a1, string a2, string a3)
        {
            string[] arr = { a1, a2, a3 };

            int before;
            int after;

            for (int i = 0; i < 10; i++)
            {
                before = Random.Shared.Next(0, 3);
                after = Random.Shared.Next(0, 3);

                string temp;

                temp = arr[before];
                arr[before] = arr[after];
                arr[after] = temp;
            }

            return arr;
        }


        static void Main(string[] args)
        {
            int score = 0;

            string[,] questions = new string[10, 4]
            {
             {"Azerbaycan bayraginda mavi reng neyi bildirir ?", "Demokratiya", "Muasirlik", "Turkchuluk" },
             {"Duzbucaqli uchbucagin neche hipotenuzu olur ?","1","2","3" },
             {"Ashagidakilardan hansi tezyiq vahididir ?","Meyve","Beher","Bar" },
             {"Komputerin neyi olur ?","Mesuliyyet","Yaddash","Insaf" },
             {"Hansi canli qelsemelerle teneffus edir ?","Ayi","Kutum","Horumchek" },
             {"Ingilisler heftenin hansi gunune Sunday deyirler ?","Bazar","Shenbe","Cume" },
             {"90 dereceli bucaq hansidir ?","Duz","Kor","Iti" },
             {"Tennis meydanchasi nece adlanir ?","Kort","Ring","Tatami" },
             {"Gosterilen geyim olchulerinden en kichiyi hansidir ?","S","M","L" },
             {"Futbol oyununda meshqchi kimi deyishhe biler ?","Sherhchi","Oyunchu","Hakim" },
            };


            string[] correctanswer = new string[10]
            {
                "Turkchuluk","1","Bar","Yaddash","Kutum","Bazar","Duz","Kort","S","Oyunchu"
            };

            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine(questions[i, 0]);

                ShowAnswers(Mix(questions[i, 1], questions[i, 2], questions[i, 3]));

                string? yourAnswer = Console.ReadLine();

                if (yourAnswer == correctanswer[i])
                {
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(questions[i, 0]);
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.ForegroundColor = ConsoleColor.Green;
                    ShowAnswers(Mix(questions[i, 1], questions[i, 2], questions[i, 3]));
                    Console.ForegroundColor = ConsoleColor.White;

                    score += 10;

                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(questions[i, 0]);
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.ForegroundColor = ConsoleColor.Red;
                    ShowAnswers(Mix(questions[i, 1], questions[i, 2], questions[i, 3]));
                    Console.ForegroundColor = ConsoleColor.White;

                    if(score <= 0)
                    {
                        score = 0;
                    }
                    else
                    {
                        score -= 10;
                    }

                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Quiz finished");
            Console.WriteLine($"Your score: {score}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}