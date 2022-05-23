using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int bossHealthFirst = 1000;
            int bossHealthLast = 1500;
            int bossHealth = random.Next(bossHealthFirst, bossHealthLast);
            int bossDamageFirst = 100;
            int bossDamageLast = 200;
            int bossDamage = random.Next(bossDamageFirst, bossDamageLast);
            int playerHealthFirst = 500;
            int playerHealthLast = 800;
            int playerHealth = random.Next(playerHealthFirst, playerHealthLast);
            int playerDamageFirst = 100;
            int playerDamageLast = 150;
            int playerDamage = random.Next(playerDamageFirst, playerDamageLast);
            int playerDamageExalibur = 2;
            int playerUltraFirst = 5;
            int playerUltraLast = 25;
            int playerUltaVasilisk = (random.Next(playerUltraFirst, playerUltraLast))/100;
            int playerFirstHealth = 100;
            int playerLastHealth = 300;
            int playerHealthPlus = random.Next(playerFirstHealth, playerLastHealth);
            int snakeAttak = 2;
            bool isVasilisk = false;
            string playerChoose;
            int round = 0;

            Console.WriteLine("ДА НАЧНЕТСЯ БОЙ ПРОТИВ БОССА!");

            while (bossHealth > 0 && playerHealth > 0)
            {
                round++;
                Console.WriteLine("\nРАУНД " + round);
                Console.WriteLine("\nЖизни босса: " + bossHealth + "\nЖизни игрока: " + playerHealth);
                Console.WriteLine("Атака босса: " + bossDamage + " dmg\nАтака игрока: " + playerDamage + " dmg");
                Console.WriteLine("\n УДАР ИГРОКА");
                Console.WriteLine("\nНажмите кнопку для удара:\n 1 - Удар экскалибуром (атака увеличивается вдвое)");
                Console.WriteLine(" 2 - Призыв Василиска: отнимает " + playerUltaVasilisk + " % хп, открывает одну суператаку - НАШЕСТВИЕ ЗМЕЙ");
                Console.WriteLine(" 3 - НАШЕСТВИЕ ЗМЕЙ: Босс теряет половину своих жизней");
                Console.WriteLine(" 4 - Выпить лечебного зелья: восстанавливает от " + playerFirstHealth + " до " + playerLastHealth + " хп");
                playerChoose = Console.ReadLine();

                switch (playerChoose)
                {
                    case "1":
                        bossHealth -= playerDamage * playerDamageExalibur;
                        isVasilisk = true;
                        Console.WriteLine("\nВы нанесли удар!!!\nЖизни босса: " + bossHealth);
                        break;
                    case "2":
                        isVasilisk = true;
                        playerHealth = playerHealth - playerHealth * playerUltaVasilisk;
                        Console.WriteLine("\nВасилиск призван!\nЖизни игрока: " + playerHealth);
                        break;
                    case "3":

                        if (isVasilisk == true)
                        {
                            bossHealth /= snakeAttak;
                            isVasilisk = false;
                            Console.WriteLine("\nУдар змей обрушился на Босса!!!\nЖизни босса: " + bossHealth);
                        }
                        else
                        {
                            Console.WriteLine("Вы теряете удар!\nПризовите Василиска!");
                        }
                        break;
                    case "4":
                        playerHealth += playerHealthPlus;
                        Console.WriteLine("Жизни игрока: " + playerHealth);
                        break;
                    default:
                        Console.WriteLine("Вы теряете ход...");
                        break;
                }
                Console.WriteLine("\n УДАР БОССА");
                playerHealth -= bossDamage;
                Console.WriteLine("\nБосс нанес удар!\nЖизни игрока: " + playerHealth);
                Console.WriteLine("\nНажмите любую клавишу..");
                Console.ReadKey();
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine("\nБосс победил");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("\nИгрок победил");
            }
        }
    }
}
