
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
            supermarket.ServeCustomers();
        }
    }

    class Supermarket
    {
        private Random _random = new Random();
        private Queue<Customer> _customers = new Queue<Customer>();
        private List<Product> _products = new List<Product>();

        public Supermarket()
        {
            CreateProductsList();
            CreateCustomers();
        }

        public void ServeCustomers()
        {
            while (_customers.Count > 0)
            {
                Console.WriteLine("Добро пожаловать в ОШАН\n\nВ очереди " + _customers.Count + " покупателей\n");
                Console.WriteLine("Нажмите любую клавишу, чтобы пригласить покупателя\n");
                Console.ReadKey();
                Customer customer = _customers.Peek();
                customer.ShowBasket();

                while (_customers.Peek().Money < _customers.Peek().BasketCost)
                {
                    Console.WriteLine("У вас не хватает денег, нажмите любую клавишу,чтобы выложить случайный товар..");
                    Console.ReadKey();
                    Console.Clear();
                    customer.RemoveProduct();
                    customer.ShowBasket();
                }

                _customers.Dequeue();
                Console.WriteLine("Отлично, покупатель расплатился, нажмите любую клавишу, чтобы пригласить на кассу следующего..\n");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Покупатели закончились, можно пойти попить кофе");
        }

        public void CreateCustomers()
        {
            int minCountCustomers = 1;
            int maxCountCustomers = 15;
            int minCustomerMoney = 100;
            int maxCustomerMoney = 600;
            int minCountProduct = 1;
            int maxCountProduct = 1;
            int countCustomers = _random.Next(minCountCustomers, maxCountCustomers);

            for (int i = 0; i < countCustomers; i++)
            {
                int customersMoney = _random.Next(minCustomerMoney, maxCustomerMoney);
                _customers.Enqueue(new Customer(customersMoney));
                countCustomers--;
            }

            foreach (var buyer in _customers)
            {
                int countProducts = _random.Next(minCountProduct, maxCountProduct);

                for (int i = 0; i < countProducts; i++)
                {
                    Product product = _products[_random.Next(0, countProducts)];
                    buyer.AddProduct(product);
                    countProducts--;
                }
            }
        }

        private void CreateProductsList()
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
    }
}

class Customer
{
    private Random _random = new Random();
    private List<Product> _products = new List<Product>();
    public int Money { get; private set; }
    public int BasketCost { get; private set; }

    public Customer(int money)
    {
        Money = money;
    }

    public void RemoveProduct()
    {
        int numberProduct = _random.Next(0, _products.Count);
        Product product = _products.ElementAt(numberProduct);
        Console.WriteLine("Вы выложили: " + product.Name);
        BasketCost -= product.Price;
        _products.RemoveAt(numberProduct);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
        BasketCost += product.Price;
    }

    public void ShowBasket()
    {
        foreach (var product in _products)
        {
            product.Show();
        }

        Console.WriteLine("Стоимость покупки составит: " + BasketCost);
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

    public void Show()
    {
        Console.WriteLine($"Товар - {Name}, цена - {Price}");
    }
}
