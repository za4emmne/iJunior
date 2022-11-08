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
            Supermarket supermarket = new Supermarket();
            supermarket.CreateProductsList();
            supermarket.CreateTurn();
            supermarket.MoveTurn();
        }
    }

    class Supermarket
    {
        public Random random = new Random();
        private Queue<Buyer> _turn = new Queue<Buyer>();
        private List<Product> _products = new List<Product>();

        public void CreateProductsList()
        {
            _products.Add(new Product("Молоко", 50));
            _products.Add(new Product("Хлеб", 30));
            _products.Add(new Product("Мясо", 300));
            _products.Add(new Product("Сметана", 60));
            _products.Add(new Product("Яйца", 70));
            _products.Add(new Product("Кефир", 60));
            _products.Add(new Product("Шоколад", 80));
            _products.Add(new Product("Фрукты", 100));
            _products.Add(new Product("Орехи", 200));
            _products.Add(new Product("Огурцы", 120));
            _products.Add(new Product("Помидоры", 100));
            _products.Add(new Product("Картошка", 60));
            _products.Add(new Product("Сыр", 170));
            _products.Add(new Product("Колбаса", 210));
            _products.Add(new Product("Лук", 40));
            _products.Add(new Product("Пепси Кола (черноголовка)", 80));
            _products.Add(new Product("Чипсики (русская картошка)", 60));
            _products.Add(new Product("Попкорн", 66));
            _products.Add(new Product("Морковь", 40));
            _products.Add(new Product("Гречка", 100));
            _products.Add(new Product("Макароны", 70));
            _products.Add(new Product("Рис", 80));
            _products.Add(new Product("Чай", 100));
            _products.Add(new Product("Кофе", 313));
        }

        public void MoveTurn()
        {
            int buyerNumber = 1;

            foreach (var buyer in _turn)
            {
                Console.WriteLine("Добро пожаловать в ОШАН\n\nВ очереди " + _turn.Count + " покупателей\n");
                Console.WriteLine("На кассе покупатель №" + buyerNumber);
                Console.WriteLine("Нажмите любую клавишу, чтобы пригласить покупателя\n");
                Console.ReadKey();
                buyer.ShowBasket();

                while (buyer.Money < buyer.BasketCoast)
                {
                    Console.WriteLine("У вас не хватает денег, нажмите любую клавишу,чтобы выложить случайный товар..");
                    Console.ReadKey();
                    Console.Clear();
                    buyer.RemoveProduct();
                    buyer.ShowBasket();
                }

                Console.WriteLine("Отлично, покупатель расплатился, нажмите любую клавишу, чтобы пригласить на кассу следующего..\n");
                Console.ReadKey();
                Console.Clear();
                buyerNumber++;
            }

            Console.WriteLine("Покупатели закончились, можно пойти попить кофе");
        }

        public void CreateTurn()
        {
            int countBuyer = random.Next(1, 15);

            while (countBuyer > 0)
            {
                int buyerMoney = random.Next(100, 600);
                int basketCoast = 0;
                _turn.Enqueue(new Buyer(buyerMoney, basketCoast));
                countBuyer--;
            }

            foreach (var buyer in _turn)
            {
                int countProducts = random.Next(1, 9);
                CreateBasket(buyer, countProducts);
            }
        }

        public void CreateBasket(Buyer buyer, int countProducts)
        {
            while (countProducts > 0)
            {
                TakeProduct(out Product product);
                buyer.AddProducts(product);
                countProducts--;
            }
        }

        public void TakeProduct(out Product product)
        {
            int randomNumber = random.Next(0, _products.Count);
            product = _products.ElementAt(randomNumber);
        }
    }
}

class Buyer
{
    public int Money { get; private set; }
    public int BasketCoast { get; private set; }
    public Random random = new Random();
    private List<Product> _products = new List<Product>();

    public Buyer(int money, int basketCoast)
    {
        Money = money;
        BasketCoast = basketCoast;
    }

    public void RemoveProduct()
    {
        int numberProduct = random.Next(0, _products.Count);
        Product product = _products.ElementAt(numberProduct);
        Console.WriteLine("Вы выложили: " + product.Name);
        BasketCoast -= product.Price;
        _products.RemoveAt(numberProduct);
    }

    public void AddProducts(Product product)
    {
        _products.Add(product);
        BasketCoast += product.Price;
    }

    public void ShowBasket()
    {
        foreach (var product in _products)
        {
            product.ShowProduct();
        }

        Console.WriteLine("Стоимость покупки составит: " + BasketCoast);
        Console.WriteLine("У вас денег: " + Money + "\n");
    }
}

class Product
{
    public string Name { get; private set; }
    public int Price { get; private set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public void ShowProduct()
    {
        Console.WriteLine($"Товар - {Name}, цена - {Price}");
    }
}
