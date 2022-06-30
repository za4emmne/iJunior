using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            Dictionary<string, string> wordBook = new Dictionary<string, string>();
            string inputWord = "";
            wordBook.Add("Машина", "Средство передвижения на колесах с двигателем");

            while (isExit == false)
            {
                Console.WriteLine("Выберите действие: \n1. Поиск из словаря\n2. Добавить слово в словарь\n3. Выход");
                int chooseMenu = Convert.ToInt32(Console.ReadLine());

                switch (chooseMenu)
                {
                    case 1:
                        FindWord(inputWord, wordBook);
                        break;
                    case 2:
                        AddWord(ref wordBook);
                        break;
                    case 3:
                        isExit = true;
                        break;
                }
            }
        }

        static void AddWord(ref Dictionary<string, string> wordBook)
        {
            Console.Write("Ввндите слово: ");
            string newWord = Console.ReadLine();

            foreach (var word in wordBook)
            {

                while (newWord == word.Key)
                {
                    Console.Write("Такое слово уже есть в словаре, введите другое: ");
                    newWord = Console.ReadLine();
                }
            }
            Console.Write("Введите значение слова: ");
            string wordValue = Console.ReadLine();
            wordBook.Add(newWord, wordValue);
            Console.Write("Слово добавлено, нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();

        }

        static void FindWord(string input, Dictionary<string, string> wordBook)
        {
            Console.Write("Чтобы получить значение, введите слово из словаря: ");
            input = Console.ReadLine();

            if (wordBook.ContainsKey(input))
            {
                Console.WriteLine($"{input} - {wordBook[input]}");
            }
            else
            {
                Console.WriteLine("Такого слова нет.");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
