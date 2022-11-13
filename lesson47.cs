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
            fighterClub.Fight();
        }
    }

    class FighterClub
    {
        private List<Fighter> _fighters = new List<Fighter>();

        public void Fight()
        {
            int round = 1;
            AddFighters();
            ChooseFighters(out Fighter leftFighter, out Fighter rightFighter);
            Console.WriteLine(leftFighter.Name + " VS " + rightFighter.Name);

            while (leftFighter.Health > 0 && rightFighter.Health > 0)
            {
                Console.WriteLine("\nРАУНД - " + round);
                leftFighter.TakeDamage(round, rightFighter);
                rightFighter.TakeDamage(round, leftFighter);
                leftFighter.ShowStats();
                rightFighter.ShowStats();
                round++;
            }

            ShowWinner(leftFighter, rightFighter);
        }

        private void ShowWinner(Fighter leftFighter, Fighter rightFighter)
        {
            if (leftFighter.Health > 0)
            {
                Console.WriteLine("\nПобедил боец слева: " + leftFighter.Name);
            }
            else if (rightFighter.Health > 0)
            {
                Console.WriteLine("\nПобедил боец справа " + rightFighter.Name);
            }
            else if (leftFighter.Health < 0 && rightFighter.Health < 0)
            {
                Console.WriteLine("\nНичья - победила дружба");
            }
        }

        public void ChooseFighters(out Fighter leftFighter, out Fighter rightFighter)
        {
            Console.Write("\nДля выбора бойца справа введите его порядковый номер: ");
            rightFighter = ChooseFighter();
            Console.Write("\nДля выбора бойца слева введите его порядковый номер: ");
            leftFighter = ChooseFighter();
        }

        public Fighter ChooseFighter()
        {
            bool fighterIsReady = false;
            Fighter chooseFighter = null;

            while (fighterIsReady == false)
            {
                string playerChoose = Console.ReadLine();
                bool isNumber = int.TryParse(playerChoose, out int fighterNumber);

                if (fighterIsReady == false && isNumber)
                {
                    if (fighterNumber - 1 < _fighters.Count)
                    {
                        fighterIsReady = true;
                        Fighter findFighter = _fighters.ElementAt(fighterNumber - 1);
                        chooseFighter = new Fighter(findFighter.Name, findFighter.Health, findFighter.Damage, findFighter.Armor);
                    }
                    else
                    {
                        Console.Write("Такого бойца нет..");
                        Console.Write("\nВведите порядковый снова: ");
                        return null;
                    }
                }
            }

            return chooseFighter;
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

            for (int i = 0; i < _fighters.Count; i++)
            {
                int fighterNumber = i + 1;
                Console.WriteLine("Порядковый номер бойца: " + fighterNumber);
                _fighters.ElementAt(i).ShowInfo();
                Console.WriteLine();
            }
        }
    }

    class Fighter
    {
        public int Armor { get; protected set; }
        public int Health { get; private set; }
        public string Name { get; private set; }
        public int Damage { get; protected set; }

        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public virtual void TakeDamage(int round, Fighter fighter)
        {
            Health -= fighter.Attack(round) - Armor;
        }

        public virtual int Attack(int round)
        {
            return Damage;
        }

        public virtual void ShowInfo()
        {
            Console.Write($"Имя: {Name}\nЗдоровье: {Health}\nАтака: {Damage}\nБроня: {Armor}\nУникальная способность: ");
        }

        public virtual void ShowStats()
        {
            Console.WriteLine($"\nИмя: {Name}\nЗдоровье: {Health}\nАтака: {Damage}\nБроня: {Armor}");
        }
    }

    class Wizard : Fighter
    {
        private int _manna;
        private int _decreaseManna = 3;

        public Wizard(string name, int health, int damage, int armor, int manna) : base(name, health, damage, armor)
        {
            _manna = manna;
        }

        public override void TakeDamage(int round, Fighter fighter)
        {
            base.TakeDamage(round, fighter);
        }

        public override int Attack(int round)
        {
            UseManna();
            return Damage;
        }

        public void UseManna()
        {
            Damage += _manna;

            if (_manna > 0)
            {
                _manna -= _decreaseManna;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Атака небес - атака с каждым ударом увеличивается на величину равной манны - {_manna} ед., в после раундах, манна будет уменьшаться на {_decreaseManna} ед.");
        }

        public override void ShowStats()
        {
            Console.WriteLine($"\nИмя: {Name}\nЗдоровье: {Health}\nАтака: {Damage}\nБроня: {Armor}\nМанна: {_manna} - добавется к атаке в след раунде");
        }
    }

    class Tank : Fighter
    {
        public Tank(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override void TakeDamage(int round, Fighter fighter)
        {
            base.TakeDamage(round, fighter);
        }

        public override int Attack(int round)
        {
            MegaAttack();
            return Damage;
        }

        public void MegaAttack()
        {
            int quarter = 4;
            int minimumHealth = Health / quarter;

            if (Health < minimumHealth)
            {
                Damage += Damage;
            }
        }
        public override void ShowInfo()
        {
            int quater = 25;
            base.ShowInfo();
            Console.WriteLine($"Из последних сил - если жизней меньше чем " + quater + "%, урон удваивается");
        }
    }

    class Ninja : Fighter
    {
        public Ninja(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override void TakeDamage(int round, Fighter fighter)
        {
            int roundNumber = 3;

            if (round % roundNumber == 0)
            {
                Console.WriteLine("Соперник промахнулся..");
            }
            else
            {
                base.TakeDamage(round, fighter);
            }
        }

        public override int Attack(int round)
        {
            ShurikenAttack(round);
            return Damage;
        }

        public void ShurikenAttack(int round)
        {
            int roundNumber = 4;
            int half = 2;

            if (round % roundNumber == half)
            {
                Damage += Damage / half;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Каждый третий раунд его соперник промахивается, а каждый четвертый раунд атака бойца увеличвается в полтора раза");
        }
    }
    class Archer : Fighter
    {
        public Archer(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override void TakeDamage(int round, Fighter fighter)
        {
            base.TakeDamage(round, fighter);
        }

        public override int Attack(int round)
        {
            ArrowAttack(round);
            return Damage;
        }

        public void ArrowAttack(int round)
        {
            int evenNumber = 2;
            int damageBonus = 1;

            if (round % evenNumber == 0)
            {
                Damage += damageBonus;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Каждый второй раунд атака бойца увеличвается на ед.");
        }
    }

    class Berserk : Fighter
    {
        private int _armorBonus = 30;
        private int _denominator = 10;

        public Berserk(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
        }

        public override void TakeDamage(int round, Fighter fighter)
        {
            DeadCall();
            base.TakeDamage(round, fighter);
        }

        public override int Attack(int round)
        {
            return Damage;
        }

        public void DeadCall()
        {
            int minHealth = Health / _denominator;

            if (Health < minHealth)
            {
                Armor += _armorBonus;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Если у бойца остается " + _denominator + "изней, его броня увеличивается на " + _armorBonus + " ед.");
        }
    }
}
