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
            Casino casino = new Casino(player, deck);
        }
    }

    class Casino
    {
        public Casino(Player player, Deck deck)
        {
            bool isGame = true;

            while (isGame)
            {
                Console.SetCursorPosition(10, 0);
                Console.WriteLine("Добро пожаловать в POKERDOM");
                Console.WriteLine("\nЧтобы начать играть и вытянуть карту нажмите: 1\nЧтобы получить определенное количество карт: 2\nЧтобы посмотреть свои карты: 3\nЧтобы сбросить" +
                    " карты: 4\nЧтобы выйти - ext");
                Console.Write("\nВаша команда: ");
                const string CommnadTakeCard = "1";
                const string CommandTakeCountCard = "2";
                const string CommandShowHand = "3";
                const string CommandClearHand = "4";
                const string CommandExit = "ext";
                string inputPlayer = Console.ReadLine();

                switch (inputPlayer)
                {
                    case CommnadTakeCard:
                        player.TakeCardHand(deck);
                        break;
                    case CommandTakeCountCard:
                        player.TakeCoundCardHand(deck);
                        break;
                    case CommandShowHand:
                        player.ShowPlayerCards();
                        break;
                    case CommandClearHand:
                        player.ClearPlayerCard();
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

        public void ShowCard()
        {
            Console.WriteLine(Number + " " + Suit);
        }
    }

    class Player
    {
        private List<Card> _playerCards = new List<Card>();

        public void TakeCardHand(Deck deck)
        {
            deck.FindCard(out Card card);
            _playerCards.Add(card);
            Console.Clear();
        }

        public void TakeCoundCardHand(Deck deck)
        {
            Console.Write("Введите сколько карт вы хотите взять: ");
            string inputCountCard = Console.ReadLine();
            int.TryParse(inputCountCard, out int countCard);

            for (int i = 0; i < countCard; i++)
            {
                TakeCardHand(deck);
            }
        }

        public void ClearPlayerCard()
        {
            if (_playerCards.Count > 0)
            {
                for (int i = 0; i < _playerCards.Count; i++)
                {
                    _playerCards.RemoveAt(i);
                }
            }
            else
            {
                Console.WriteLine("\nУ вас еще нет карт, возьмите из колоды");
                Console.ReadKey();
            }

            Console.Clear();
        }

        public void ShowPlayerCards()
        {
            if (_playerCards.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Ваши карты:");

                foreach (var card in _playerCards)
                {
                    card.ShowCard();
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
        private List<Card> _deck = new List<Card>();

        public Deck()
        {
            FormDeck();
        }

        public void FormDeck()
        {
            string[] numbers = new string[] { "6", "7", "8", "9", "jack", "queen", "king", "ace" };
            string[] suits = new string[] { "heart", "diamond", "club", "spade" };

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    _deck.Add(new Card(numbers[i], suits[j]));
                }
            }
        }

        public void FindCard(out Card findCard)
        {
            findCard = null;
            int randomNumber = _random.Next(0, _deck.Count);

            foreach (var card in _deck)
            {
                findCard = _deck.ElementAt(randomNumber);
            }

            return;
        }
    }
}
