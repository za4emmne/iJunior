using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            string userInput = "";
            Dictionary<string, string> worker = new Dictionary<string, string>();
            worker.Add("Аркаев Аркадий Артемович", "Писатель");
            worker.Add("Беломоров Борис Бентарович", "Лучник");

            while (isExit == false)
            {
                Console.WriteLine("\n1. Добавить досье\n2. Вывести все досье\n3. Удалить досье\n4. Выход");
                Console.Write("\nВведите команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                            AddWorker(worker);
                            break;
                    case "2":
                            DrawLibrary(worker);
                            break;
                    case "3":
                            DeleteWorker(worker);
                            break;
                    case "4":
                            isExit = true;
                            break;
                }
            }
        }

        static void DrawLibrary(Dictionary<string, string> workers)
        {

            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.Key} - {worker.Value}");
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void AddWorker(Dictionary<string, string> workers)
        {
            Console.Write("Введите фамилию, имя и отчество сотрудника: ");
            string userInputName = Console.ReadLine();

            while (workers.ContainsKey(userInputName) == true)
            {
                Console.Write("Этот сотрудник уже есть в списке,введите другие данные: ");
                userInputName = Console.ReadLine();
            }
            Console.Write("Введите должность сотрудника: ");
            string userInputJob = Console.ReadLine();
            
            workers.Add(userInputName, userInputJob);
            Console.Clear();
        }

        static void DeleteWorker(Dictionary<string, string> workers)
        {
            Console.Write("Введите фамилию, имя и отчество сотрудника, чье досье вы хотите удалить: ");
            string userInput = Console.ReadLine();
            workers.Remove(userInput);
        }
    }
}
