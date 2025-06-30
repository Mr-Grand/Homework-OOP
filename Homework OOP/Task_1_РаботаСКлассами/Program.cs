namespace Task_1_РаботаСКлассами;

internal class Program
{
    private static void Main(string[] args)
    {
        Player player1 = new Player("Danik", 24, "Archer");
        var player2 = new Player("Khel", 40, "Warrior");
        var player3 = new Player();

        player1.Info();
        player2.Info();
        player3.Info();
    }

    private class Player
    {
        public readonly string ClassName;
        public readonly int Lvl;
        public readonly string Name;

        public Player(string name, int lvl, string className)
        {
            Name = name;
            Lvl = lvl;
            ClassName = className;
        }

        public Player()
        {
            Name = "Unknown";
            Lvl = 0;
            ClassName = "Unknown";
        }

        public void Info()
        {
            Console.WriteLine($"\nPlayer - {Name}\nLevel - {Lvl}\nClass - {ClassName}\n");
        }
    }
}