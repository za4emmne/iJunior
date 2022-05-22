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
            float usdToRub = 63;
            float rubToEu = 65;
            float euRToRub = 67;
            float usdToEu = rubToUsd / rubToEu;
            float euTousd = rubToEu / rubToUsd;
            string chooseClient;
            float changeMoney;
          
            Console.WriteLine("Это конвертер Валют");
            Console.Write("Введите Ваш баланс в рублях: ");
            balanceRub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Ваш баланс в долларах: ");
            balanceUsd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Ваш баланс в евро: ");
            balanceEu = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Если хотите перевести из рублей в доллары введите - 1");
            Console.WriteLine("Если хотите перевести из рублей в евро введите - 2");
            Console.WriteLine("Если хотите перевести из доллары в рубли введите - 3");
            Console.WriteLine("Если хотите перевести из доллары в евро введите - 4");
            Console.WriteLine("Если хотите перевести из евро в рубли введите - 5");
            Console.WriteLine("Если хотите перевести из долларов в евро введите - 6");
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
                        Console.WriteLine("У вас не хвататет денег.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Курс валюты: " + rubToEu);
                    Console.Write("Введите сколько хотите обменять рублей на евро: ");
                    changeMoney = Convert.ToSingle(Console.ReadLine());

                    if (balanceRub > changeMoney)
                    {
                        balanceRub -= changeMoney;
                        balanceEu += changeMoney / rubToEu;
                    }
                    else
                    {
                        Console.WriteLine("У вас не хвататет денег.");
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
                        Console.WriteLine("У вас не хвататет денег.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Курс валюты: " + usdToEu);
                    Console.Write("Введите сколько хотите обменять долларов на евро: ");
                    changeMoney = Convert.ToSingle(Console.ReadLine());
                    
                    if (balanceUsd > changeMoney)
                    {
                        balanceUsd -= changeMoney;
                        balanceEu += changeMoney * usdToEu;
                    }
                    else
                    {
                        Console.WriteLine("У вас не хвататет денег.");
                    }
                    break;
                case "5":
                    Console.WriteLine("Курс валюты: " + euRToRub);
                    Console.Write("Введите сколько хотите обменять евро на рубли: ");
                    changeMoney = Convert.ToSingle(Console.ReadLine());

                    if (balanceEu > changeMoney)
                    {
                        balanceEu -= changeMoney;
                        balanceRub += changeMoney * euRToRub;
                    }
                    else
                    {
                        Console.WriteLine("У вас не хвататет денег.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Курс валюты: " + usdToEu);
                    Console.Write("Введите сколько хотите обменять долларов на евро: ");
                    changeMoney = Convert.ToSingle(Console.ReadLine());

                    if (balanceUsd > changeMoney)
                    {
                        balanceUsd -= changeMoney;
                        balanceEu += changeMoney * usdToEu;
                    }
                    else
                    {
                        Console.WriteLine("У вас не хвататет денег.");
                    }
                    break;
            }
            Console.WriteLine("Ваш баланс в рублях стал: " + balanceRub);
            Console.WriteLine("Ваш баланс в долларах стал: " + balanceUsd);
            Console.WriteLine("Ваш баланс в евро стал: " + balanceEu);
        }
    }
}
