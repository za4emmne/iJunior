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
            Battlefield battlefield = new Battlefield();
            battlefield.Battle();
        }
    }
}

class Battlefield
{
    private Detachment _leftDetachment = new Detachment();
    private Detachment _rightDetachment = new Detachment();
    private Random _random = new Random();

    public void Battle()
    {
        Console.WriteLine("Состав 1 взвода(" + _rightDetachment.GetSoldiersCount() + " чел.): ");
        _rightDetachment.ShowCommand();
        Console.WriteLine("\nСостав 2 взвода(" + _leftDetachment.GetSoldiersCount() + " чел.): ");
        _leftDetachment.ShowCommand();

        while (_leftDetachment.GetSoldiersCount() > 0 && _rightDetachment.GetSoldiersCount() > 0)
        {
            Fight();
        }

        if (_leftDetachment.GetSoldiersCount() > 0)
        {
            Console.WriteLine("\nПобедил 2 взвод, их осталось " + _leftDetachment.GetSoldiersCount() + " человек.");
        }
        else if (_rightDetachment.GetSoldiersCount() > 0)
        {
            Console.WriteLine("\nПобедил 1 взвод, их осталось " + _rightDetachment.GetSoldiersCount() + " человек.");
        }
        else if (_rightDetachment.GetSoldiersCount() > 0 && _leftDetachment.GetSoldiersCount() > 0)
        {
            Console.WriteLine("Ничья, победил дружба, братья");
        }
    }

    private void Fight()
    {
        int numberSoldierLeft = _random.Next(0, _leftDetachment.GetSoldiersCount());
        int numberSoldierRight = _random.Next(0, _rightDetachment.GetSoldiersCount());
        Soldier leftSoldier = _leftDetachment.GetRandomSoldier(numberSoldierLeft);
        Soldier rightSoldier = _rightDetachment.GetRandomSoldier(numberSoldierRight);

        while (leftSoldier.Health > 0 && rightSoldier.Health > 0)
        {
            rightSoldier.TakeDamage(leftSoldier.Damage);
            leftSoldier.TakeDamage(rightSoldier.Damage);
        }

        if (leftSoldier.Health <= 0)
        {
            _leftDetachment.RemoveDeadSoldier(numberSoldierLeft);
        }
        else if (rightSoldier.Health <= 0)
        {
            _rightDetachment.RemoveDeadSoldier(numberSoldierRight);
        }
    }
}

class Detachment
{
    private Random _random = new Random();
    private List<Soldier> _soldiers = new List<Soldier>();

    public Detachment()
    {
        Create();
    }

    public void RemoveDeadSoldier(int numberSoldier)
    {
        _soldiers.RemoveAt(numberSoldier);
    }

    public Soldier GetRandomSoldier(int randomNumber)
    {
        return _soldiers[randomNumber];
    }

    public int GetSoldiersCount()
    {
        return _soldiers.Count;
    }

    public void ShowCommand()
    {
        foreach (var soldier in _soldiers)
        {
            soldier.ShowStats();
        }
    }

    private List<Soldier> Create()
    {
        string squaddie = "рядовой";
        string sergeant = "сержант";
        string officer = "офицер";
        int minCountOfficer = 1;
        int maxCountOfficer = 4;
        int minCountSergeant = 2;
        int maxCountSergeant = 7;
        int minCountSoldiers = 20;
        int maxCountSoldier = 36;
        int countOfficer = _random.Next(minCountOfficer, maxCountOfficer);
        int countSergeant = _random.Next(minCountSergeant, maxCountSergeant);
        int countSoldier = _random.Next(minCountSoldiers, maxCountSoldier);
        CompetePlatoon(countOfficer, officer, _soldiers);
        CompetePlatoon(countSergeant, sergeant, _soldiers);
        CompetePlatoon(countSoldier, squaddie, _soldiers);
        return _soldiers;
    }

    private void CompetePlatoon(int countSoldiers, string rank, List<Soldier> _soldiers)
    {
        for (int i = 0; i < countSoldiers; i++)
        {
            _soldiers.Add(Create(rank));
        }
    }

    private Soldier Create(string rank)
    {
        string sergeant = "сержант";
        string officer = "офицер";
        int minHealth = 50;
        int maxHealth = 101;
        int minDamage = 20;
        int maxDamage = 51;
        int minRankBonus = 1;
        int maxRankBonus = 4;
        int sergeantRankFactor = 2;
        int officerRankBonus = 3;
        int rankBonus = _random.Next(minRankBonus, maxRankBonus);
        int health = _random.Next(minHealth, maxHealth);
        int damage = _random.Next(minDamage, maxDamage);

        if (rank == sergeant)
        {
            health += rankBonus * sergeantRankFactor;
        }
        else if (rank == officer)
        {
            health += rankBonus * officerRankBonus;
        }

        Soldier soldier = new Soldier(health, damage, rank);
        return soldier;
    }
}

class Soldier
{
    protected Random _random = new Random();
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public string Rank { get; private set; }

    public Soldier(int health, int damage, string rank)
    {
        Health = health;
        Damage = damage;
        Rank = rank;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void ShowStats()
    {
        Console.WriteLine("Звание - " + Rank + " Здоровье - " + Health + " Атака - " + Damage);
    }
}
