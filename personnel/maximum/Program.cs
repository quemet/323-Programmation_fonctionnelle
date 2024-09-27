// 4 players
List<Player> players = new List<Player>()
{
    new Player("Joe", 32),
    new Player("Jack", 30),
    new Player("William", 37),
    new Player("Averell", 25)
};

// Initialize search
Player elder = players.First();
int biggestAge = elder.Age;

// search
foreach (Player p in players)
{
    if (p.Age > biggestAge) // memorize new elder
    {
        elder = p;
        biggestAge = p.Age; // for future loops
    }
}

Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");

Console.ReadKey();

public class Player
{
    private readonly string _name;
    private readonly int _age;

    public Player(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public string Name => _name;

    public int Age => _age;
}
