using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            string userInput = "";
            string[] name = new string[] { "Аркаев Аркадий Артемович", "Беломоров Борис Бентарович" };
            string[] job = new string[] { "Писатель", "Лучник" };

            while (isExit == false)
            {
                Console.WriteLine("\n1. Добавить досье\n2. Вывести все досье\n3. Удалить досье\n4. Поиск по фамилии\n5. Выход");
                Console.Write("\nВведите команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            name = AddArray(name, "ФИО"); job = AddArray(job, "должность");
                            break;
                        }
                    case "2":
                        {
                            DrawArray(name, job);
                            break;
                        }
                    case "3":
                        {
                            deleteCase(ref name, ref job);
                            break;
                        }
                    case "4":
                        {
                            FindName(name, job);
                            break;
                        }
                    case "5":
                        {
                            isExit = true;
                            break;
                        }
                }
            }
        }

        static void deleteCase(ref string[] name, ref string[] job)
        {
            Console.Write("\nВведите номер досье, которое хотите удалить: ");
            int deleteElement = Convert.ToInt32(Console.ReadLine());
            DeleteArray(ref name, deleteElement);
            DeleteArray(ref job, deleteElement);
        }

        static string[] AddArray(string[] array, string input)
        {
            Console.Write($"Введите {input}: ");
            string userInput = Console.ReadLine();
            string[] tempName = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempName[i] = array[i];
            }
            array = tempName;
            array[array.Length - 1] = userInput;
            return array;
        }

        static void DeleteArray(ref string[] array, int numberElement)
        {
            string[] tempArray = new string[array.Length - 1];

            if (numberElement <= array.Length)
            {

                for (int i = 0; i < numberElement - 1; i++)
                {
                    tempArray[i] = array[i];
                }

                for (int i = numberElement; i < array.Length; i++)
                {
                    tempArray[i - 1] = array[i];
                }
                array = tempArray;
            }
            else
            {
                Console.WriteLine("Такого досье нет.");
            }
        }

        static void DrawArray(string[] arrayName, string[] arrayJob)
        {

            for (int i = 0; i < arrayName.Length; i++)
            {
                Console.WriteLine("\n" + (i + 1) + ". " + arrayName[i] + " - " + arrayJob[i]);
            }
        }

        static void FindName(string[] nameArray, string[] jobArray)
        {
            Console.Write("\nВведите фамилию: ");
            string userInputName = Console.ReadLine();

            for (int i = 0; i < nameArray.Length; i++)
            {

                if (nameArray[i].Contains(userInputName) == true)
                {
                    Console.WriteLine($"\n{i + 1}. {nameArray[i]} - {jobArray[i]}");
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
