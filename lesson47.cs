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
            FighterClub fighterClub = new FighterClub();
        }
    }

    class FighterClub
    {
        private List<Fighter> _fighters = new List<Fighter>();

        public FighterClub()
        {
            Fighter leftFighter = null;
            Fighter rightFighter = null;
            AddFighters();
            ChooseFighters(out leftFighter, out rightFighter);
            Fight(leftFighter, rightFighter);
        }

        public void Fight(Fighter leftFighter, Fighter rightFighter)
        {
            int round = 1;

            while (leftFighter.Health > 0 && rightFighter.Health > 0)
            {
                Console.WriteLine("\nРАУНД - " + round);
                leftFighter.TakeDamage(rightFighter.Attack(round), round);
                rightFighter.TakeDamage(leftFighter.Attack(round), round);
                leftFighter.ShowStats();
                rightFighter.ShowStats();
                round++;
            }

            if (leftFighter.Health > 0)
            {
                Console.WriteLine("\nПобедил боец слева: " + leftFighter.Name);
            }
            else
            {
                Console.WriteLine("\nПобедил боец справа " + rightFighter.Name);
            }
        }

        public void ChooseFighters(out Fighter leftFighter, out Fighter rightFighter)
        {
            bool fighterLeftIsReady = false;
            bool fighterRightIsReady = false;
            string playerChoose;
            leftFighter = null;
            rightFighter = null;


            while (fighterLeftIsReady == false)
            {
                Console.Write("\nДля выбора бойца слева введите его имя: ");
                playerChoose = Console.ReadLine();

                if (fighterLeftIsReady == false)
                {
                    foreach (var fighter in _fighters)
                    {
                        if (fighter.Name == playerChoose)
                        {
                            leftFighter = fighter;
                            fighterLeftIsReady = true;
                        }
                    }
                }
                else
                {
                    Console.Write("Такого бойца нет..");
                }
            }

            while (fighterRightIsReady == false)
            {
                Console.Write("\nДля выбора бойца справа введите его имя: ");
                playerChoose = Console.ReadLine();

                if (fighterRightIsReady == false)
                {
                    foreach (var fighter in _fighters)
                    {
                        if (fighter.Name == playerChoose)
                        {
                            rightFighter = fighter;
                            fighterRightIsReady = true;
                        }
                    }
                }
                else
                {
                    Console.Write("Такого бойца нет..");
                }
            }
        }

        public void AddFighters()
        {
            int minHealthWizard = 70;
            int maxHealthWizard = 120;
            int minDamageWizard = 20;
            int maxDamageWizard = 50;
            int minArmorWizzard = 5;
            int maxArmorWizzard = 15;
            int minMannaWizzard = 7;
            int maxMannaWizzard = 23;
            int minHealthTank = 150;
            int maxHealthTank = 200;
            int minDamageTank = 50;
            int maxDamageTank = 70;
            int minArmorTank = 15;
            int maxArmorTank = 30;
            int minHealthNinja = 80;
            int maxHealthNinja = 140;
            int minDamageNinja = 30;
            int maxDamageNinja = 60;
            int minArmorNinja = 10;
            int maxArmorNinja = 20;
            int minHealthArcher = 60;
            int maxHealthArcher = 130;
            int minDamageArcher = 40;
            int maxDamageArcher = 70;
            int minArmorArcher = 10;
            int maxArmorArcher = 30;
            int minHealthBerserk = 100;
            int maxHealthBerserk = 160;
            int minDamageBerserk = 70;
            int maxDamageBerserk = 150;
            int minArmorBerserk = 20;
            int maxArmorBerserk = 50;
            Random random = new Random();
            int healthWizard = random.Next(minHealthWizard, maxHealthWizard);
            int damageWizard = random.Next(minDamageWizard, maxDamageWizard);
            int armorWizzard = random.Next(minArmorWizzard, maxArmorWizzard);
            int mannaWizard = random.Next(minMannaWizzard, maxMannaWizzard);
            int damageTank = random.Next(minDamageTank, maxDamageTank);
            int armorTank = random.Next(minArmorTank, maxArmorTank);
            int healthTank = random.Next(minHealthTank, maxHealthTank);
            int healthNinja = random.Next(minHealthNinja, maxHealthNinja);
            int damageNinja = random.Next(minDamageNinja, maxDamageNinja);
            int armorNinja = random.Next(minArmorNinja, maxArmorNinja);
            int healthArcher = random.Next(minHealthArcher, maxHealthArcher);
            int damageArcher = random.Next(minDamageArcher, maxDamageArcher);
            int armorArcher = random.Next(minArmorArcher, maxArmorArcher);
            int healthBerserk = random.Next(minHealthBerserk, maxHealthBerserk);
            int damageBerserk = random.Next(minDamageBerserk, maxDamageBerserk);
            int armorBerserk = random.Next(minArmorBerserk, maxArmorBerserk);
            Berserk berserk = new Berserk("Boun", healthBerserk, damageBerserk, armorBerserk);
            Archer archer = new Archer("Legolas", healthArcher, damageArcher, armorArcher);
            Ninja ninja = new Ninja("Li", healthNinja, damageNinja, armorNinja);
            Wizard wizard = new Wizard("Kras", healthWizard, damageWizard, armorWizzard, mannaWizard);
            Tank tank = new Tank("Azerot", healthTank, damageTank, armorTank);
            _fighters.Add(wizard);
            _fighters.Add(tank);
            _fighters.Add(ninja);
            _fighters.Add(archer);
            _fighters.Add(berserk);

            foreach (var fighter in _fighters)
            {
                fighter.ShowInfo();
            }
        }
    }

    class Fighter
    {
        public int Health { get; private set; }
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        protected int Armor;

        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public virtual int Attack(int round)
        {
           return Damage;
        }

        public virtual void TakeDamage(int damage, int round)
        {
            Health -= damage - Armor;
            Armor -= 2;
        }

        public virtual void ShowInfo()
        {
            Console.Write($"\nИмя: {Name}\nЗдоровье: {Health}\nАтака: {Damage}\nБроня: {Armor}\nУникальная способность: ");
        }

        public virtual void ShowStats()
        {
            Console.WriteLine($"\nИмя: {Name}\nЗдоровье: {Health}\nАтака: {Damage}\nБроня: {Armor}");
        }
    }

    class Wizard : Fighter
    {
        protected int Manna;
        private int decreaseManna = 3;

        public Wizard(string name, int health, int damage, int armor, int manna) : base(name, health, damage, armor)
        {
            Manna = manna;
        }

        public override int Attack(int round)
        { 
            SkyAttack();
            return base.Attack(round);
        }

        public void SkyAttack()
        {
            Damage += Manna;
            Manna -= decreaseManna;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Атака небес - атака с каждым ударом увеличивается на величину равной манны - {Manna} ед., в после раундах, манна будет уменьшаться на {decreaseManna} ед.");
        }

        public override void ShowStats()
        {
            Console.WriteLine($"\nИмя: {Name}\nЗдоровье: {Health}\nАтака: {Damage}\nБроня: {Armor}\nМанна: {Manna} - добавется к атаке в след раунде");
        }
    }

    class Tank : Fighter
    {
        public Tank(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override int Attack(int round)
        {
            MegaAttack();
            return base.Attack(round);
        }

        public void MegaAttack()
        {
            int minimumHealth = Health / 5;

            if (Health < minimumHealth)
            {
                Damage *= 2;
            }
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Из последних сил - если жизней меньше чем 20%, урон удваивается");
        }
    }

    class Ninja : Fighter
    {
        public Ninja(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override int Attack(int round)
        {
            ShurikenAttack(round);
            return base.Attack(round);
        }

        public override void TakeDamage(int damage, int round)
        {
            if (round % 3 == 0)
            {
                damage = 0;
                Console.WriteLine("Соперник промахнулся!");
            }
            else
            {
                base.TakeDamage(damage, round);
            }           
        }

        public void ShurikenAttack(int round)
        {
            if (round % 4 == 0)
            {
                Damage += Damage / 2;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Каждый третий раунд его соперник промахивается, а каждый четвертый раунд атака бойца увеличвается в 1/2 раз");
        }
    }
    class Archer : Fighter
    {
        public Archer(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override int Attack(int round)
        {
            ArrowAttack(round);
            return base.Attack(round);
        }

        public void ArrowAttack(int round)
        {
            if (round % 2 == 0)
            {
                Damage += 1;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Каждый второй раунд атака бойца увеличвается на 1 ед.");
        }
    }

    class Berserk : Fighter
    {
        public Berserk(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override int Attack(int round)
        {
            DeadCall();
            return base.Attack(round);
        }

        public void DeadCall()
        {
            int minHealth = Health / 10;

            if (Health < minHealth)
            {
                Armor += 30;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Если у бойца остается 10% жизней, его броня увеличивается на 30 ед.");
        }
    }
}
