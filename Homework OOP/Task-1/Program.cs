namespace Task_1;

internal class Program
{
    private static void Main(string[] args)
    {
        Player player1 = new Player("Danik", 24, "Archer");
        var player2 = new Player("Khel", 40, "Warrior");
        var player3 = new Player();

        player1.ShowInfo();
        player2.ShowInfo();
        player3.ShowInfo();
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

        public void ShowInfo()
        {
            Console.WriteLine($"\nPlayer - {Name}\nLevel - {Lvl}\nClass - {ClassName}\n");
        }
    }
}