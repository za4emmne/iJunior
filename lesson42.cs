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
            Player player = new Player();
            Deck deck = new Deck();
            Casino casino = new Casino();
            casino.Menu(player, deck);
        }
    }

    class Casino
    {
        public void Menu(Player player, Deck deck)
        {
            bool isGame = true;

            while (isGame)
            {
                const string CommnadTakeCard = "1";
                const string CommandTakeCards = "2";
                const string CommandShowHand = "3";
                const string CommandClearHand = "4";
                const string CommandExit = "ext";
                Console.SetCursorPosition(10, 0);
                Console.WriteLine("Добро пожаловать в POKERDOM");
                Console.WriteLine("\nЧтобы начать играть и вытянуть карту нажмите: " + CommnadTakeCard + "\nЧтобы получить определенное количество карт: " + CommandTakeCards +
                    "\nЧтобы посмотреть свои карты: " + CommandShowHand + "\nЧтобы сбросить карты: " + CommandClearHand + "\nЧтобы выйти - " + CommandExit);
                deck.CoundCards();
                Console.Write("\nВаша команда: ");
                string inputPlayer = Console.ReadLine();

                switch (inputPlayer)
                {
                    case CommnadTakeCard:
                        player.TakeCardHand(deck);
                        break;
                    case CommandTakeCards:
                        player.TakeCardsHand(deck);
                        break;
                    case CommandShowHand:
                        player.ShowCards();
                        break;
                    case CommandClearHand:
                        player.ClearHandCard(deck);
                        break;
                    case CommandExit:
                        isGame = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет, введите другую");
                        break;
                }
            }
        }
    }

    class Card
    {
        public string Number { get; private set; }
        public string Suit { get; private set; }

        public Card(string number, string suit)
        {
            Number = number;
            Suit = suit;
        }

        public void Show()
        {
            Console.WriteLine(Number + " " + Suit);
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public void TakeCardHand(Deck deck)
        {
            deck.FindCard(out Card card);
            _cards.Add(card);
            Console.Clear();
        }

        public void TakeCardsHand(Deck deck)
        {
            Console.Write("Введите сколько карт вы хотите взять: ");
            string inputCountCard = Console.ReadLine();
            int.TryParse(inputCountCard, out int countCard);

            for (int i = 0; i < countCard; i++)
            {
                TakeCardHand(deck);
            }
        }

        public void ClearHandCard(Deck deck)
        {
            if (_cards.Count > 0)
            {
                for (int i = 0; i < _cards.Count; i++)
                {
                    _cards.RemoveAt(i);
                }
                deck.Clear();
                deck.FormDeck();
            }
            else
            {
                Console.WriteLine("\nУ вас еще нет карт, возьмите из колоды");
                Console.ReadKey();
            }

            Console.Clear();
        }

        public void ShowCards()
        {
            if (_cards.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Ваши карты:");

                foreach (var card in _cards)
                {
                    card.Show();
                }
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nУ вас еще нет карт, возьмите из колоды");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            FormDeck();
        }

        public void Clear()
        {
            while (_cards.Count > 0)
            {
                for (int i = 0; i < _cards.Count; i++)
                {
                    _cards.RemoveAt(i);
                }
            }
        }

        public void FormDeck()
        {
            string[] numbers = new string[] { "6", "7", "8", "9", "jack", "queen", "king", "ace" };
            string[] suits = new string[] { "heart", "diamond", "club", "spade" };

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    _cards.Add(new Card(numbers[i], suits[j]));
                }
            }
        }

        public void CoundCards()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("В колоде осталось карт: " + _cards.Count);
        }

        public void FindCard(out Card findCard)
        {
            if (_cards.Count > 0)
            {
                int randomNumber = _random.Next(0, _cards.Count);
                findCard = _cards.ElementAt(randomNumber);
                _cards.Remove(findCard);
            }
            else
            {
                Console.WriteLine("\nКолода пуста");
                Console.ReadKey();
                findCard = null;
            }
        }
    }
}
