using System.Runtime.InteropServices.JavaScript;

namespace Kovacs_Peter_dolgozat_23_10_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Elso();
            print("\n");
            Masodik();
            print("\n");
            Harmadik();
            print("\n");
            Negyedik();
            print("\n");
            Otodik();
            Console.ReadKey();
        }

        static void Elso()
        {
            print("A hónap sorszáma: ");
            int month_num = Convert.ToInt16(Console.ReadLine());

            if (month_num < 1 || month_num > 12)
            {
                printL("Hibás adatbevitel");
            }
            else
            {
                int[] month_lenght = new int[4];
                month_lenght[0] = 28;
                month_lenght[1] = 29;
                month_lenght[2] = 30;
                month_lenght[3] = 31;

                int requested_month = 0;

                if (month_num == 2)
                {
                    printL($"Napok száma a hónapban: {month_lenght[0]} vagy {month_lenght[1]}");
                }
                else if (month_num < 7 && month_num % 2 == 1)
                {
                    requested_month = 3;
                }
                else
                {
                    requested_month = 2;
                }

                if (requested_month != 0)
                {
                    printL($"Napok száma a hónapban: {month_lenght[requested_month]}");
                }
            }
        }

        static void Masodik()
        {
            int lower_limit, upper_limit;
            do
            {
                print("Alsó határ: ");
                lower_limit = Convert.ToInt16(Console.ReadLine());
                print("Felső határ: ");
                upper_limit = Convert.ToInt16(Console.ReadLine());
            } while (lower_limit < 1 || lower_limit > 12 || upper_limit < 1 || upper_limit > 12 || lower_limit > upper_limit);



            for (int month_num = lower_limit; month_num <= upper_limit; month_num++)
            {
                int[] month_lenght = new int[4];
                month_lenght[0] = 28;
                month_lenght[1] = 29;
                month_lenght[2] = 30;
                month_lenght[3] = 31;

                int requested_month = 0;

                if (month_num == 2)
                {
                    printL($"Napok száma a 2. hónapban: {month_lenght[0]} vagy {month_lenght[1]}");
                }
                else if (month_num < 7 && month_num % 2 == 1)
                {
                    requested_month = 3;
                }
                else
                {
                    requested_month = 2;
                }

                if (requested_month != 0)
                {
                    printL($"Napok száma a(z) {month_num}. hónapban: {month_lenght[requested_month]}");
                }
            }
        }

        static void Harmadik()
        {
            Random r = new Random();
            int low_level = 0;
            for (int i = 0; i < 14; i++)
            {
                int current_measurement = 0;
                for (int x = 0; x < 2; x++)
                {
                    int probability = r.Next(0, 6);
                    switch (probability)
                    {
                        case 0:
                            current_measurement = r.Next(0, 100);
                            break;
                        case 1: case 2: case 3:
                            current_measurement = r.Next(100, 201);
                            break;
                        case 4:
                            current_measurement = r.Next(201, 301);
                            break;
                    }

                    print("A vízállás: ");

                    if (current_measurement < 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        low_level++;
                    }
                    else if (current_measurement < 201 && current_measurement >= 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if ( current_measurement < 301 && current_measurement > 200)
                    {
                        Console.ForegroundColor= ConsoleColor.Green;
                    }
                    print($"{current_measurement} cm\n");
                    Console.ForegroundColor = ConsoleColor.Gray;

                }
            }

            string hajovonta_szabad = "";
            if (low_level >= 5)
            {
                hajovonta_szabad = "tilos";
            }
            else
            {
                hajovonta_szabad = "szabad";
            }

            printL($"A következő héten a hajóvonták találkozása: {hajovonta_szabad}");
        }

        static void Negyedik()
        {
            bool won = false;
            Random r = new Random();
            int score_point = 0;
            for (int i = 0; i < 10; i++)
            {
                int shoot = r.Next(1, 16);
                if (score_point + shoot >= 100)
                {
                    continue;
                }
                else if(score_point == 100)
                {
                    won = true;
                    break;
                }
                score_point += shoot;
                printL($"{shoot} ({score_point})");
            }
            switch(won)
            {
                case true:
                    printL("Nyertél");
                    break;
                case false:
                    printL("Vesztettél");
                    break;
            }
        }

        static void Otodik()
        {
            int accurated_shoot = 0;
            bool won = false, accurate = false;
            Random r = new Random();
            int score_point = 0;

            for (int i = 0; i < 10; i++)
            {
                int shoot;
                if (accurate == false)
                {
                    shoot = r.Next(1, 16);
                }
                else
                {
                    shoot = r.Next(1, 6);
                    accurate = false;
                    accurated_shoot++;
                }

                if (score_point + shoot >= 100)
                {
                    continue;
                }
                else if (score_point == 100)
                {
                    won = true;
                    break;
                }
                score_point += shoot;
                printL($"{shoot} ({score_point})");

                if (accurated_shoot < 2 && i < 9)
                {
                    print("Akarsz pontosított lövést? (y/n): ");
                    char answer = Console.ReadKey().KeyChar;

                    if (answer == 'y')
                    {
                        accurate = true;
                    }
                    print("\n");
                } 
            }
            switch (won)
            {
                case true:
                    printL("Nyertél");
                    break;
                case false:
                    printL("Vesztettél");
                    break;
            }
        }

        static void print(string text)
        {
            Console.Write(text);
        }

        static void printL(string text)
        {
            Console.WriteLine(text);
        }
    }
}