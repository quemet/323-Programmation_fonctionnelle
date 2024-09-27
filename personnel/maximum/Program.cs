using System.Collections.Immutable;

namespace maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            Player.GetElder();
        }
    }

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

        public static void GetElder()
        {
            // 4 players
            ImmutableList<Player> players = [new Player("Joe", 32), new Player("Jack", 30), new Player("William", 37), new Player("Averell", 25)];

            // Initialize search
            Player elder = new("A", -1);

            // Player eld = players.Aggregate((c, n) => c.Age > n.Age ? c : n);

            // int biggestAge = elder.Age;

            // search
            foreach (Player p in players)
            {
                if (p.Age > elder.Age) // memorize new elder
                {
                    elder = new Player(p.Name, p.Age);
                    // biggestAge = p.Age; // for future loops
                }
            }

            Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");

            Console.ReadKey();
        }
    }
}
