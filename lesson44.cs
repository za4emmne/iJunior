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
            const string commandShowGoods = "show";
            const string commandSellGoods = "buy";
            const string commandShowPlayerGoods = "goods";
            const string commandExit = "ext";
            bool isExit = false;
            Seller seller = new Seller(0);
            Player player = new Player(100);

            while (isExit == false)
            {
                Console.WriteLine("Добро пожаловать в магазин, выберить действие: ");
                Console.WriteLine("\nПоказать весь товар - " + commandShowGoods + "\nКупить товар - " + commandSellGoods +
                    "\nПосмотреть свои покупки - " + commandShowPlayerGoods + "\nВыйти - " + commandExit + "\n");
                player.ShowMoney();
                Console.Write("\n\nВаш ввод: ");
                string playerInputCommand = Console.ReadLine();

                switch (playerInputCommand)
                {
                    case commandShowGoods:
                        seller.ShowListGoods();
                        break;
                    case commandSellGoods:
                        seller.SellGoods(player);
                        break;
                    case commandShowPlayerGoods:
                        player.ShowListGoods();
                        break;
                    case commandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }
    }

    class Seller
    {
        public int Money { get; private set; }

        private List<Goods> _goods = new List<Goods>();

        public Seller(int money)
        {
            Money = money;
            _goods.Add(new Goods("Молоко", 50));
            _goods.Add(new Goods("Хлеб", 20));
        }

        public void ShowListGoods()
        {
            Console.Clear();
            Console.WriteLine("Товары в наличии в магазине:\n");

            foreach (var goods in _goods)
            {
                goods.Show();
            }

            Console.WriteLine("Нажмите любую кнопку..");
            Console.ReadKey();
            Console.Clear();
        }

        public void SellGoods(Player player)
        {
            EnterGoods(out Goods sellGoods);
            player.TakeGoods(sellGoods);
            Money += sellGoods.Prise;
            Console.ReadKey();
            Console.Clear();
        }

        private void EnterGoods(out Goods findGoods)
        {            
            findGoods = null;
            bool isFindGoods = false;
            Console.Clear();
            Console.Write("\nВведите название товара, котрый хотите купить: ");

            if (isFindGoods == false)
            {
                string nameGoods = Console.ReadLine();

                foreach (var goods in _goods)
                {
                    if (goods.Name == nameGoods)
                    {
                        findGoods = goods;
                        isFindGoods = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого товара нет");
            }
        }
    }

    class Player
    {
        public int Money { get; private set; }

        private List<Goods> _goods = new List<Goods>();

        public Player(int money)
        {
            Money = money;
        }

        public void TakeGoods(Goods goods)
        {
            _goods.Add(goods);

            if (Money >= goods.Prise)
            {
                Money -= goods.Prise;
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

        public void ShowListGoods()
        {
            Console.Clear();

            if (_goods.Count > 0)
            {
                Console.WriteLine("Вы уже купили:");

                foreach (var goods in _goods)
                {
                    goods.Show();
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

    class Goods
    {
        public int Prise { get; private set; }
        public string Name { get; private set; }

        public Goods(string name, int prise)
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
