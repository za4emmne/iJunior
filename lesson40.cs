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
            Renderer renderer = new Renderer();
            Console.Write("Введите координаты персонажа по Х: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите координаты персонажа по Y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Player player = new Player(x, y);
            Console.Clear();
            renderer.DrawPlayer(player.X, player.Y);
        }
    }

    class Renderer
    {
        public void DrawPlayer(int x, int y, char playerSkin = '!')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(playerSkin);
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
