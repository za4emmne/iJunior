using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            float balanceRub;
            float balanceUsd;
            float balanceEu;
            float rubToUsd = 60;
            float usdToRub = 1/63f;
            float rubToEur = 65;
            float eurToRub = 1/67f;
            float usdToEur = rubToUsd / rubToEur;
            float eurToUsd = rubToEur / rubToUsd;
            string chooseClient;
            float changeMoney;
            bool isExit = false;

            Console.WriteLine("Это конвертер Валют");
            Console.Write("Введите Ваш баланс в рублях: ");
            balanceRub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Ваш баланс в долларах: ");
            balanceUsd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Ваш баланс в евро: ");
            balanceEu = Convert.ToInt32(Console.ReadLine());

            while (isExit == false)
            {
                Console.WriteLine("Если хотите перевести из рублей в доллары введите - 1");
                Console.WriteLine("Если хотите перевести из рублей в евро введите - 2");
                Console.WriteLine("Если хотите перевести из доллары в рубли введите - 3");
                Console.WriteLine("Если хотите перевести из доллары в евро введите - 4");
                Console.WriteLine("Если хотите перевести из евро в рубли введите - 5");
                Console.WriteLine("Если хотите перевести из долларов в евро введите - 6");
                Console.WriteLine("Если хотите выйти введите - exit");
                chooseClient = Console.ReadLine();

                switch (chooseClient)
                {
                    case "1":
                        Console.WriteLine("Курс валюты: " + rubToUsd);
                        Console.Write("Введите сколько хотите обменять рублей на доллары: ");
                        changeMoney = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub > changeMoney)
                        {
                            balanceRub -= changeMoney;
                            balanceUsd += changeMoney / rubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас не хвататет денег.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Курс валюты: " + rubToEur);
                        Console.Write("Введите сколько хотите обменять рублей на евро: ");
                        changeMoney = Convert.ToSingle(Console.ReadLine());

                        if (balanceRub > changeMoney)
                        {
                            balanceRub -= changeMoney;
                            balanceEu += changeMoney / rubToEur;
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас не хвататет денег.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Курс валюты: " + usdToRub);
                        Console.Write("Введите сколько хотите обменять долларов на рубли: ");
                        changeMoney = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd > changeMoney)
                        {
                            balanceUsd -= changeMoney;
                            balanceRub += changeMoney * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас не хвататет денег.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Курс валюты: " + usdToEur);
                        Console.Write("Введите сколько хотите обменять долларов на евро: ");
                        changeMoney = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd > changeMoney)
                        {
                            balanceUsd -= changeMoney;
                            balanceEu += changeMoney * usdToEur;
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас не хвататет денег.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Курс валюты: " + eurToRub);
                        Console.Write("Введите сколько хотите обменять евро на рубли: ");
                        changeMoney = Convert.ToSingle(Console.ReadLine());

                        if (balanceEu > changeMoney)
                        {
                            balanceEu -= changeMoney;
                            balanceRub += changeMoney * eurToRub;
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас не хвататет денег.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Курс валюты: " + usdToEur);
                        Console.Write("Введите сколько хотите обменять долларов на евро: ");
                        changeMoney = Convert.ToSingle(Console.ReadLine());

                        if (balanceUsd > changeMoney)
                        {
                            balanceUsd -= changeMoney;
                            balanceEu += changeMoney * usdToEur;
                        }
                        else
                        {
                            Console.WriteLine("\nУ вас не хвататет денег.");
                        }
                        break;
                    case "exit":
                        isExit = true;
                        break;
                }
                Console.WriteLine("\nВаш баланс в рублях стал: " + balanceRub);
                Console.WriteLine("Ваш баланс в долларах стал: " + balanceUsd);
                Console.WriteLine("Ваш баланс в евро стал: " + balanceEu + "\n");
            }
        }
    }
}
