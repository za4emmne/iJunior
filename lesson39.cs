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
            player.ShowInfo();
        }
    }

    class Player
    {
        private string _name;
        private int _health;
        private int _damage;

        public void ShowInfo()
        {
            Console.WriteLine($"Имя игрока: {_name}, здоровье: {_health}, атака: {_damage}");
        }

        public Player(string name, int health, int damage)
        {
            _name = name;
            _health = health;
            _damage = damage;
        }
    }
}
