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
    private List<Soldier> _leftSoldiers = new List<Soldier>();
    private List<Soldier> _rightSoldiers = new List<Soldier>();
    private Random _random = new Random();

    public void Battle()
    {
        Detachment detachment = new Detachment();
        _rightSoldiers = detachment.Create();
        _leftSoldiers = detachment.Create();
        Console.WriteLine("Состав 1 взвода(" + _rightSoldiers.Count + " чел.): ");
        ShowCommand(_rightSoldiers);
        Console.WriteLine("\nСостав 2 взвода(" + _leftSoldiers.Count + " чел.): ");
        ShowCommand(_leftSoldiers);

        while (_leftSoldiers.Count > 0 && _rightSoldiers.Count > 0)
        {
            Fight();
        }

        if (_leftSoldiers.Count > 0)
        {
            Console.WriteLine("\nПобедил 2 взвод, из осталось " + _leftSoldiers.Count + " человек.");
        }
        else if (_rightSoldiers.Count > 0)
        {
            Console.WriteLine("\nПобедил 1 взвод, из осталось " + _rightSoldiers.Count + " человек.");
        }
        else if (_rightSoldiers.Count > 0 && _leftSoldiers.Count > 0)
        {
            Console.WriteLine("Ничья, победил дружба, братья");
        }
    }

    private void Fight()
    {
        int numberSoldierUSA = _random.Next(0, _leftSoldiers.Count);
        int numberSoldierRus = _random.Next(0, _rightSoldiers.Count);
        Soldier usaSoldier = _leftSoldiers[numberSoldierUSA];
        Soldier rusSoldier = _rightSoldiers[numberSoldierRus];

        while (usaSoldier.Health > 0 && rusSoldier.Health > 0)
        {
            rusSoldier.TakeDamage(usaSoldier.Damage);
            usaSoldier.TakeDamage(rusSoldier.Damage);
        }

        if (usaSoldier.Health <= 0)
        {
            _leftSoldiers.RemoveAt(numberSoldierUSA);
        }
        else if (rusSoldier.Health <= 0)
        {
            _rightSoldiers.RemoveAt(numberSoldierRus);
        }
    }

    private void ShowCommand(List<Soldier> soldiers)
    {
        foreach (var soldier in soldiers)
        {
            soldier.ShowStats();
        }
    }
}

class Detachment
{
    private Random _random = new Random();

    public List<Soldier> Create()
    {
        List<Soldier> _soldiers = new List<Soldier>();
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
