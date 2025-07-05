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
        
        
        players.ShowPlayers();
        Console.WriteLine("Нажмите клавишу, чтобы очистить вывод" +
                          " и проверить следующие методы");
        
        Console.ReadKey(true); // true - чтобы нажатая клавиша не отображалась
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        // Дополнительно очищаем буфер (если предыдущие методы не помогли)
        Console.Write("\f\u001bc\x1B[3J"); // Специальные escape-последовательности
        Console.SetCursorPosition(0, 0);
        
        
        
        players.ShowPlayers();
        
        
        players.BanPlayerID(players.GetPlayerId(1)); //Баним первого игрока
        players.RemovePlayer(players.GetPlayerId("Oleg")); //Удаляем игрока по имени
        
        Console.WriteLine("\nИгроки после изменений:");
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
        
        //Информация игрока по индексу
        public void ShowIndexPlayer(int index)
        {
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"Name - {players[index].UserName}\nID - {players[index].Id}" +
                              $"\nLevel - {players[index].Lvl}" +
                              $"\nBan status - {players[index].IsBanned}");
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(Guid playerId) 
        {
            int index = 0; //Сохраняем номер обьекта по индексу и удаляем его потом.
            //т.к. Нельзя удалять обьект во время цикла его перебора
            foreach (var player in players)
            {
                if (player.Id == playerId)
                    index = players.IndexOf(player);
            }
            players.RemoveAt(index);
        }
 
        //Получение Id игрока по имени
        public Guid GetPlayerId(string name) 
        {
            foreach (var player in players)
            {
                if (player.UserName == name)
                    return player.Id;
            }
            return Guid.Empty; //Метод обязан что-то возвращать
        }
        //Получение Id игрока по индексу
        public Guid GetPlayerId(int index)
        {
            if (index <= players.Count)
                return players.ElementAt(index-1).Id;
            else return Guid.Empty; //Метод обязан что-то возвращать
            
            return Guid.Empty; //Метод обязан что-то возвращать
        }

        public void BanPlayerID(Guid playerId)
        {
            foreach (var player in players)
            {
                if (player.Id == playerId)
                    player.Ban();
            }
        }
        public void UnbanPlayerID(Guid playerId)
        {
            foreach (var player in players)
            {
                if (player.Id == playerId)
                    player.Unban();
            }
        }
        
    }

    class Player
    {
        public Guid Id { get; }     //свойство только для чтения
        public string UserName { get; private set; }    //Свойство для изменени только внутри класса
        public int Lvl { get; private set; }
        public bool IsBanned  { get; private set; }

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

        public void Ban()
        {
            IsBanned = true;
        }
        public void Unban()
        {
            IsBanned = false;
        }
    }
}
