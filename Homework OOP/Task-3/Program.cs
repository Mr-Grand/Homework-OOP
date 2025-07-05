namespace Task_3;

class Program
{
    static void Main(string[] args)
    {
        PlayerDataBase players = new PlayerDataBase(); //Создаем пустую БД
        
        var player1 = new Player("Danik", 11);
        players.AddPlayer(player1);
        var player2 = new Player("Oleg", 99);
        players.AddPlayer(player2);
        var player3 = new Player("Alex", 30);
        players.AddPlayer(player3);
        
        /*player2.ShowPlayerInfo();
        Console.WriteLine("_____________________________");
        Console.WriteLine(players.GetPlayerId("Oleg"));*/
        
        players.ShowPlayers();
        players.RemovePlayer(players.GetPlayerId("Oleg"));
        players.ShowPlayers();





    }

    class PlayerDataBase
    {
        private List<Player> players = new List<Player>();

        public void ShowPlayers()
        {
            foreach (var player in players)
            {
                Console.WriteLine("___________________________________");
                Console.WriteLine($"Name - {player.UserName}\nID - {player.Id}" +
                                  $"\nLevel - {player.Lvl}\nBan status - {player.IsBanned}");
                
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public Guid GetPlayerId(string name)
        {
            foreach (var player in players)
            {
                if (player.UserName == name)
                    return player.Id;
            }
            return Guid.Empty; //Метод обязан что-то возвращать
        }

        public void RemovePlayer(Guid playerId)
        {
            int index = 0;
            foreach (var player in players)
            {
                if (player.Id == playerId)
                    index = players.IndexOf(player);
            }
            players.RemoveAt(index);
        }
        
        
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
