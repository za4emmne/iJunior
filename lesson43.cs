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
            Library library = new Library();
            library.Menu();
        }
    }

    class Book
    {
        public string Name { get; private set; }
        public string Autor { get; private set; }
        public int Year { get; private set; }
        public string Genre { get; private set; }

        public Book(string name, string autor, int year, string genre)
        {
            Name = name;
            Autor = autor;
            Year = year;
            Genre = genre;
        }

        public void ShowBook()
        {
            Console.WriteLine("Книга: [" + Name + "] автор: [" + Autor + "] год выпуска: [" + Year + "] жанр: [" + Genre + "]");
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public Library()
        {
            _books.Add(new Book("Капитал", "Карл Маркс", 1867, "Финансы"));
        }

        public void Menu()
        {
            bool isExit = false;

            while (isExit == false)
            {
                const string CommandShowAllBooks = "1";
                const string CommandAddBook = "2";
                const string CommandFindBook = "3";
                const string CommandRemoveBook = "4";
                const string CommandExit = "ext";
                Console.SetCursorPosition(15, 0);
                Console.WriteLine("Добро пожаловать в БИБЛИОТЕКУ!\n\nЗдесь вы можете:");
                Console.WriteLine("\nПосмотреть все книги        - НАЖАВ НА " + CommandShowAllBooks);
                Console.WriteLine("Добавить книгу в библиотеку - НАЖАВ НА " + CommandAddBook);
                Console.WriteLine("Найти книгу                 - НАЖАВ НА " + CommandFindBook);
                Console.WriteLine("Убрать книгу                - НАЖАВ НА " + CommandRemoveBook);
                Console.WriteLine("Выйти                       - ВВЕСТИ " + CommandExit);
                Console.Write("\n\n\nВыбери команду: ");
                string inputCommand = Console.ReadLine();

                switch (inputCommand)
                {
                    case CommandShowAllBooks:
                        ShowAllBooks();
                        break;
                    case CommandAddBook:
                        AddBook();
                        break;
                    case CommandFindBook:
                        FindBook();
                        break;
                    case CommandRemoveBook:
                        RemoveBook();
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("\nТакой команды нет");
                        break;
                }
            }
        }

        public void ShowAllBooks()
        {
            Console.WriteLine();

            if (_books.Count > 0)
            {
                foreach (var book in _books)
                {
                    Console.Write(_books.IndexOf(book) + 1 + ". ");
                    book.ShowBook();
                }
            }
            else
            {
                Console.WriteLine("Библиотека пуста");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void EnterNewBook(out Book book)
        {
            Console.WriteLine("\nВы решили добавить книгу.");
            Console.Write("Введите ее название: ");
            string inputNameBook = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string inputAutorBook = Console.ReadLine();
            Console.Write("Введите год написания книги: ");
            string inputYearBook = Console.ReadLine();
            bool isNumber = int.TryParse(inputYearBook, out int yearBook);

            while (isNumber == false)
            {
                Console.Write("Год должен быть числом, введите снова: ");
                inputYearBook = Console.ReadLine();
                isNumber = int.TryParse(inputYearBook, out yearBook);
            }

            Console.Write("Введите ее жанр: ");
            string inputGenreBook = Console.ReadLine();
            book = new Book(inputNameBook, inputAutorBook, yearBook, inputGenreBook);
        }

        public void FindBook()
        {
            const string CommandFindBookName = "1";
            const string CommandFindBookAutor = "2";
            const string CommandFindBookGenre = "3";
            const string CommandFindBookYear = "4";
            Console.Clear();
            Console.WriteLine("Вы хотите найти книгу.");
            Console.WriteLine("\nВыберите по какому параметру хотите ее найти: ");
            Console.WriteLine(" - По названию - НАЖМИТЕ " + CommandFindBookName);
            Console.WriteLine(" - По автору   - НАЖМИТЕ " + CommandFindBookAutor);
            Console.WriteLine(" - По жанру    - НАЖМИТЕ " + CommandFindBookGenre);
            Console.WriteLine(" - По году     - НАЖМИТЕ " + CommandFindBookYear);
            Console.Write("\nВведите команду: ");
            string inputCommand = Console.ReadLine();

            switch (inputCommand)
            {
                case CommandFindBookName:
                    FindBookName(out Book book);
                    break;
                case CommandFindBookAutor:
                    FindBookAutor(out book);
                    break;
                case CommandFindBookGenre:
                    FindBookGenre(out book);
                    break;
                case CommandFindBookYear:
                    FindBookYear(out book);
                    break;
                default:
                    Console.WriteLine("Такой команды нет");
                    break;
            }
        }

        public void FindBookYear(out Book findBook)
        {
            findBook = null;
            bool isFindYearBook = false;
            Console.Write("\nВведите год написания книги: ");
            string inputFindYear = Console.ReadLine();
            bool isString = int.TryParse(inputFindYear, out int findYear);

            while (isString == false)
            {
                Console.Write("Введите число: ");
                inputFindYear = Console.ReadLine();
                isString = int.TryParse(inputFindYear, out findYear);
            }

            if (isFindYearBook == false)
            {
                foreach (var book in _books)
                {
                    if (book.Year == findYear)
                    {
                        book.ShowBook();
                        findBook = book;
                        isFindYearBook = true;
                    }
                }
            }

            if (isFindYearBook == false)
            {
                Console.WriteLine("Такой книги нет.");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void FindBookName(out Book findBook)
        {
            findBook = null;
            bool isFindNameBook = false;
            Console.Write("\nВведите название книги: ");
            string inputFindName = Console.ReadLine();

            if (isFindNameBook == false)
            {
                foreach (var book in _books)
                {
                    if (book.Name == inputFindName)
                    {
                        book.ShowBook();
                        findBook = book;
                        isFindNameBook = true;
                    }
                }
            }

            if (isFindNameBook == false)
            {
                Console.WriteLine("Такой книги нет.");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void FindBookGenre(out Book findBook)
        {
            findBook = null;
            bool isFindGenreBook = false;
            Console.Write("\nВведите жанр книги: ");
            string inputFindGenre = Console.ReadLine();

            if (isFindGenreBook == false)
            {
                foreach (var book in _books)
                {
                    if (book.Genre == inputFindGenre)
                    {
                        book.ShowBook();
                        findBook = book;
                        isFindGenreBook = true;
                    }
                }
            }

            if (isFindGenreBook == false)
            {
                Console.WriteLine("Такой книги нет.");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void FindBookAutor(out Book findBook)
        {
            findBook = null;
            bool isFindAutorBook = false;
            Console.Write("\nВведите автора книги: ");
            string inputFindAutor = Console.ReadLine();

            if (isFindAutorBook == false)
            {
                foreach (var book in _books)
                {
                    if (book.Autor == inputFindAutor)
                    {
                        book.ShowBook();
                        findBook = book;
                        isFindAutorBook = true;
                    }
                }

                if (isFindAutorBook == false)
                {
                    Console.WriteLine("Такой книги нет.");
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void AddBook()
        {
            EnterNewBook(out Book book);
            _books.Add(book);
            Console.WriteLine("Книга добавлена, нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
        }

        public void RemoveBook()
        {
            Console.Write("\nВведите номер книги которую необходимо убрать: ");
            string inputNumberBook = Console.ReadLine();
            bool isFindBook = int.TryParse(inputNumberBook, out int numberBook);

            if (isFindBook)
            {
                _books.RemoveAt(numberBook - 1);
            }

            Console.WriteLine("Книга убрана, нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
