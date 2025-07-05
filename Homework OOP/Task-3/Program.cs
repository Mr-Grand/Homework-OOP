namespace Task_3;

class Program
{
    static void Main(string[] args)
    {
        var player1 = new Player("Danik", 40);
        
        player1.ShowPlayerInfo();
    }

    class PlayerDataBase
    {
        
        
        
    }

    class Player
    {
        public Guid Id { get; }     //свойство только для чтения
        public string UserName { get; private set; }    //Свойство для изменени только внутри класса
        public int Lvl { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string username, int lvl)
        {
            Id = Guid.NewGuid();
            IsBanned = false;
            UserName = username;
            Lvl = lvl;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine($"\nName - {UserName}\nID - {Id}\nLevel - {Lvl}\nBan status - {IsBanned}");
        }

        
        
        
        
        
        
        
    }
}
