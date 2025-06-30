namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        //Создаем карту
        Map map = new Map(10, 10);
        Player player = new Player();
        Render render = new Render(map, player);
        while (true)
        {
            Console.WriteLine($"Здравствуйте!\nКарта размером {map.XLimit}x{map.YLimit}" +
                              $"\nВведите желаемые координаты игрока:");
            
            Console.WriteLine("Для Х - ");
            int NewX = int.Parse(Console.ReadLine());
            if (NewX <= 0 || NewX > map.XLimit)
            {
                Console.WriteLine("Вы вышли за пределы!");
                player.X = -1;
            }
            else
            {
                player.X = NewX - 1;
            }
           
            Console.WriteLine("Для Y - ");
            int NewY = int.Parse(Console.ReadLine());
            if (NewY <= 0 || NewY > map.YLimit)
            {
                Console.WriteLine("Вы вышли за пределы!");
                player.Y = -1;
            }
            else
            {
                player.Y = NewY - 1;
                
            }

            if (player.X < 0 || player.Y < 0)
            {
                Console.WriteLine("Вы вне карты!");
            }
            else
            {
                Console.WriteLine("Спасибо! Вот ваше местоположение:");
                            render.ShowMap();
            }
            
            Console.ReadLine();
            Console.Clear();
       
        }
    }

    class Map
    {
        public char[,] Coordinate;
        private int _xLimit;
        private int _yLimit;
        public const int _mapLimit = 10;
        public char MapIcon = '.';
        

        public int XLimit
        {
            get { return _xLimit; }
            set
            {
                if (value <= _mapLimit)
                {
                    _xLimit = value;
                }
                else 
                    Console.WriteLine($"Map size cannot be more than {_mapLimit}");
            }
        }

        public int YLimit
        {
            get { return _yLimit; }
            set
            {
                if (value <= _mapLimit)
                {
                    _yLimit = value;
                }
                else 
                    Console.WriteLine($"Map size cannot be more than {_mapLimit}");
            }
        }

        public Map(int XLimit, int YLimit)
        {
            _xLimit = XLimit;
            _yLimit = YLimit;
            Coordinate = new char[XLimit, YLimit];
        }

        public void InitializeMap()
        {
            for (int i = 0; i < YLimit; i++)
            {
                for (int j = 0; j < XLimit; j++)
                {
                    Coordinate[i, j] = MapIcon;
                }
            }
        }

    }

    class Player
    {
        
        private int _x;
        private int _y;
        public char PlayerIcon = '@';
       
        public int X
        {
            get { return _x; }
            set
            {
                if (value <= Map._mapLimit)
                {
                    _x = value;
                }
                else Console.WriteLine($"Map size cannot be more than {Map._mapLimit}");
            }
            
        }
        public int Y
        {
            get { return _y; }
            set
            {
                if (value <= Map._mapLimit)
                {
                    _y = value;
                }
                else Console.WriteLine($"Map size cannot be more than {Map._mapLimit}");
            }
            
        }

        public void MovePlayer(int x, int y)
        {
            X = x;
            Y = y;

            _x = X;
            _y = Y;
        }
    }

    class Render
    {
        private Map _map;
        private Player _player;
        public Render(Map map, Player player)
        {
            _map = map;
            _player = player;
        }
        
        
        public void ShowMap()
        {
            for (int i = 0; i < _map.YLimit; i++)
            {
                for (int j = 0; j < _map.XLimit; j++)
                {
                    if (j == _player.X && i == _player.Y)
                    {
                        Console.Write(_player.PlayerIcon);
                    }
                    else Console.Write(_map.MapIcon);
                }
                Console.WriteLine();
            }
        }
    }
}