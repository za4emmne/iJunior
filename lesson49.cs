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
    private List<Soldier> _USASoldiers = new List<Soldier>();
    private List<Soldier> _RusSoldiers = new List<Soldier>();
    private Random _random = new Random();

    public void Battle()
    {
        CreateCommand(_RusSoldiers);
        CreateCommand(_USASoldiers);
        Console.WriteLine("Состав 1 взвода(" + _RusSoldiers.Count + " чел.): ");
        ShowCommand(_RusSoldiers);
        Console.WriteLine("\nСостав 2 взвода(" + _USASoldiers.Count + " чел.): ");
        ShowCommand(_USASoldiers);

        while (_USASoldiers.Count > 0 && _RusSoldiers.Count > 0)
        {
            Fight();
        }

        if (_USASoldiers.Count > 0)
        {
            Console.WriteLine("\nПобедил 2 взвод, из осталось " + _USASoldiers.Count + " человек.");
        }
        else if (_RusSoldiers.Count > 0)
        {
            Console.WriteLine("\nПобедил 1 взвод, из осталось " + _RusSoldiers.Count + " человек.");
        }
    }

    public void CreateCrew(int countSoldiers, List<Soldier> soldiers, string rank)
    {
        for (int i = 0; i < countSoldiers; i++)
        {
            soldiers.Add(Create(rank));
        }
    }

    private void Fight()
    {
        int numberSoldierUSA = _random.Next(0, _USASoldiers.Count);
        int numberSoldierRus = _random.Next(0, _RusSoldiers.Count);
        Soldier usaSoldier = _USASoldiers.ElementAt(numberSoldierUSA);
        Soldier rusSoldier = _RusSoldiers.ElementAt(numberSoldierRus);

        while (usaSoldier.Health > 0 && rusSoldier.Health > 0)
        {
            rusSoldier.TakeDamage(usaSoldier.Damage);
            usaSoldier.TakeDamage(rusSoldier.Damage);
        }

        if (usaSoldier.Health <= 0)
        {
            _USASoldiers.RemoveAt(numberSoldierUSA);
        }
        else if (rusSoldier.Health <= 0)
        {
            _RusSoldiers.RemoveAt(numberSoldierRus);
        }
    }

    private void ShowCommand(List<Soldier> soldiers)
    {
        foreach (var soldier in soldiers)
        {
            soldier.ShowStats();
        }
    }

    private void CreateCommand(List<Soldier> soldiers)
    {
        int minCountOfficer = 1;
        int maxCountOfficer = 4;
        int minCOuntSergeant = 2;
        int maxCountSergeant = 7;
        int minCountSoldiers = 20;
        int maxCountSoldier = 36;
        int countOfficer = _random.Next(minCountOfficer, maxCountOfficer);
        int countSergeant = _random.Next(minCOuntSergeant, maxCountSergeant);
        int countSoldier = _random.Next(minCountSoldiers, maxCountSoldier);

        CreateCrew(countOfficer, soldiers, "офицер");
        CreateCrew(countSergeant, soldiers, "сержант");
        CreateCrew(countSoldier, soldiers, "солдат");
    }


    private Soldier Create(string rank)
    {
        int minHealth = 50;
        int maxHealth = 101;
        int minDamage = 20;
        int maxDamage = 51;
        string soldierRank = "рядовой";
        string sergeantRank = "сержант";
        string officerRank = "офицер";
        int minRankBonus = 1;
        int maxRankBonus = 4;
        int sergeantRankFactor = 2;
        int officerRankBonus = 3;
        int rankBonus = _random.Next(minRankBonus, maxRankBonus);
        int health = _random.Next(minHealth, maxHealth);
        int damage = _random.Next(minDamage, maxDamage);

        if (rank == soldierRank)
        {
            rank = soldierRank;
        }
        else if (rank == sergeantRank)
        {
            rank = sergeantRank;
            health += rankBonus * sergeantRankFactor;
        }
        else if (rank == officerRank)
        {
            rank = officerRank;
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
