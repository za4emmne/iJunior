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
    private List<Soldier> _usaSoldiers = new List<Soldier>();
    private List<Soldier> _rusSoldiers = new List<Soldier>();
    private Random _random = new Random();

    public void Battle()
    {
        Detachment detachment = new Detachment();
        _rusSoldiers = detachment.Create();
        _usaSoldiers = detachment.Create();
        Console.WriteLine("Состав 1 взвода(" + _rusSoldiers.Count + " чел.): ");
        ShowCommand(_rusSoldiers);
        Console.WriteLine("\nСостав 2 взвода(" + _usaSoldiers.Count + " чел.): ");
        ShowCommand(_usaSoldiers);

        while (_usaSoldiers.Count > 0 && _rusSoldiers.Count > 0)
        {
            Fight();
        }

        if (_usaSoldiers.Count > 0)
        {
            Console.WriteLine("\nПобедил 2 взвод, из осталось " + _usaSoldiers.Count + " человек.");
        }
        else if (_rusSoldiers.Count > 0)
        {
            Console.WriteLine("\nПобедил 1 взвод, из осталось " + _rusSoldiers.Count + " человек.");
        }
        else if (_rusSoldiers.Count > 0 && _usaSoldiers.Count > 0)
        {
            Console.WriteLine("Ничья, победил дружба, братья");
        }
    }

    private void Fight()
    {
        int numberSoldierUSA = _random.Next(0, _usaSoldiers.Count);
        int numberSoldierRus = _random.Next(0, _rusSoldiers.Count);
        Soldier usaSoldier = _usaSoldiers[numberSoldierUSA];
        Soldier rusSoldier = _rusSoldiers[numberSoldierRus];

        while (usaSoldier.Health > 0 && rusSoldier.Health > 0)
        {
            rusSoldier.TakeDamage(usaSoldier.Damage);
            usaSoldier.TakeDamage(rusSoldier.Damage);
        }

        if (usaSoldier.Health <= 0)
        {
            _usaSoldiers.RemoveAt(numberSoldierUSA);
        }
        else if (rusSoldier.Health <= 0)
        {
            _rusSoldiers.RemoveAt(numberSoldierRus);
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
    private string _squaddie = "рядовой";
    private string _sergeant = "сержант";
    private string _officer = "офицер";
    private Random _random = new Random();
    
    public List<Soldier> Create()
    {
        List<Soldier> _soldiers = new List<Soldier>();
        int minCountOfficer = 1;
        int maxCountOfficer = 4;
        int minCountSergeant = 2;
        int maxCountSergeant = 7;
        int minCountSoldiers = 20;
        int maxCountSoldier = 36;
        int countOfficer = _random.Next(minCountOfficer, maxCountOfficer);
        int countSergeant = _random.Next(minCountSergeant, maxCountSergeant);
        int countSoldier = _random.Next(minCountSoldiers, maxCountSoldier);
        CompetePlatoon(countOfficer, _officer, _soldiers);
        CompetePlatoon(countSergeant, _sergeant, _soldiers);
        CompetePlatoon(countSoldier, _squaddie, _soldiers);
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

        if (rank == _squaddie)
        {
            rank = _squaddie;
        }
        else if (rank == _sergeant)
        {
            rank = _sergeant;
            health += rankBonus * sergeantRankFactor;
        }
        else if (rank == _officer)
        {
            rank = _officer;
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
