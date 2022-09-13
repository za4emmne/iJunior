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
            const string CommandShowProducts = "show";
            const string CommandSellProducts = "buy";
            const string CommandShowPlayerProducts = "products";
            const string CommandExit = "ext";
            bool isExit = false;
            Seller seller = new Seller(0);
            Player player = new Player(100);

            while (isExit == false)
            {
                Console.WriteLine("Добро пожаловать в магазин, выберить действие: ");
                Console.WriteLine("\nПоказать весь товар - " + CommandShowProducts + "\nКупить товар - " + CommandSellProducts +
                    "\nПосмотреть свои покупки - " + CommandShowPlayerProducts + "\nВыйти - " + CommandExit + "\n");
                player.ShowMoney();
                Console.Write("\n\nВаш ввод: ");
                string playerInputCommand = Console.ReadLine();

                switch (playerInputCommand)
                {
                    case CommandShowProducts:
                        seller.ShowListGoods();
                        break;
                    case CommandSellProducts:
                        seller.SellProducts(player);
                        break;
                    case CommandShowPlayerProducts:
                        player.ShowListProducts();
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }
    }

    class Human
    {
        protected int Money;

        protected List<Products> _products = new List<Products>();

        public Human(int money)
        {
            Money = money;
        }
    }

    class Seller: Human
    {
        public Seller(int money): base (money)
        {  
            _products.Add(new Products("Молоко", 50));
            _products.Add(new Products("Хлеб", 20));
        }

        public void ShowListGoods()
        {
            Console.Clear();
            Console.WriteLine("Товары в наличии в магазине:\n");

            foreach (var product in _products)
            {
                product.Show();
            }

            Console.WriteLine("Нажмите любую кнопку..");
            Console.ReadKey();
            Console.Clear();
        }

        public void SellProducts(Player player)
        {
            EnterProducts(out Products sellProducts);
            player.TakeProducts(sellProducts);
            Money += sellProducts.Prise;
            Console.ReadKey();
            Console.Clear();
        }

        private void EnterProducts(out Products findProducts)
        {
            findProducts = null;
            bool isFindProducts = false;
            Console.Clear();
            Console.Write("\nВведите название товара, котрый хотите купить: ");

            if (isFindProducts == false)
            {
                string nameProducts = Console.ReadLine();

                foreach (var product in _products)
                {
                    if (product.Name == nameProducts)
                    {
                        findProducts = product;
                        isFindProducts = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого товара нет");
            }
        }
    }

    class Player: Human
    {
        public Player(int money): base (money)
        {}

        public void TakeProducts(Products products)
        {
            _products.Add(products);

            if (Money >= products.Prise)
            {
                Money -= products.Prise;
                Console.WriteLine("Товар куплен");
            }
            else
            {
                Console.WriteLine("У вас не хватает денег, выберите другой товар");
            }
        }

        public void ShowMoney()
        {
            Console.WriteLine("Ваш баланс - " + Money + " руб.");
        }

        public void ShowListProducts()
        {
            Console.Clear();

            if (_products.Count > 0)
            {
                Console.WriteLine("Вы уже купили:");

                foreach (var product in _products)
                {
                    product.Show();
                }
            }
            else
            {
                Console.WriteLine("Вы еще ничего не купили");
            }

            Console.WriteLine("Нажмите любую клавишу..");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Products
    {
        public int Prise { get; private set; }

        public string Name { get; private set; }

        public Products(string name, int prise)
        {
            Name = name;
            Prise = prise;
        }

        public void Show()
        {
            Console.WriteLine(Name + " - " + Prise + " руб.");
        }
    }
}
