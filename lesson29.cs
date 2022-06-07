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
                            Console.Write("Введите ФИО: ");
                            name = AddArray(name);
                            Console.Write("Введите должность: ");
                            job = AddArray(job);
                            break;
                        }
                    case "2":
                        {
                            DrawArray(name, job);
                            break;
                        }
                    case "3":
                        {
                            Console.Write("\nВведите номер досье, которое хотите удалить: ");
                            int delElement = Convert.ToInt32(Console.ReadLine());
                            DelArray(ref name, delElement);
                            DelArray(ref job, delElement);
                            break;
                        }
                    case "4":
                        {
                            Console.Write("\nВведите фамилию: ");
                            string userInputName = Console.ReadLine();
                            FindName(name, job, userInputName);
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

        static string[] AddArray(string[] array)
        {
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

        static string[] DelArray(ref string[] array, int numberElement)
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
            return array;
        }

        static void DrawArray(string[] arrayName, string[] arrayJob)
        {
            for (int i = 0; i < arrayName.Length; i++)
            {
                Console.WriteLine("\n" + (i + 1) + ". " + arrayName[i] + " - " + arrayJob[i]);
            }
        }

        static void FindName(string[] nameArray, string[] jobArray, string surname)
        {

            for (int i = 0; i < nameArray.Length; i++)
            {
                if (nameArray[i].Contains(surname) == true)
                {
                    Console.WriteLine($"\n{i + 1}. {nameArray[i]} - {jobArray[i]}");
                    break;
                }
                else
                {
                    Console.WriteLine("Такой фамилии нет.");
                    break;
                }
            }
        }
    }
}
