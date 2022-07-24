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
            Player player = new Player("Eric", 100, 50);
            player.ShowInfoPlayer();
        }
    }

    class Player
    {
        string Name;
        int Health;
        int Damage;

        public void ShowInfoPlayer()
        {
            Console.WriteLine($"Имя игрока: {Name}, здоровье: {Health}, атака: {Damage}");
        }

        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
