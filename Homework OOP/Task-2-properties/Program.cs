namespace Task_2;

internal class Program
{
    private static void Main(string[] args)
    {
        //Создаем карту
        var map = new Map(10, 10);
        var player = new Player();
        var render = new Render(map, player);
        while (true)
        {
            Console.WriteLine($"Здравствуйте!\nКарта размером {map.XLimit}x{map.YLimit}" +
                              $"\nВведите желаемые координаты игрока:");

            Console.WriteLine("Для Х - ");
            var NewX = int.Parse(Console.ReadLine());
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
            var NewY = int.Parse(Console.ReadLine());
            if (NewY <= 0 || NewY > map.YLimit)
            {
                Console.WriteLine("Вы вышли за пределы!");
                player.Y = -1;
            }
            else
            {
                player.Y = NewY - 1;
            }

            //Выводим на экран карту
            if (player.X < 0 || player.Y < 0)
            {
                Console.WriteLine("Вы вне карты!");
            }
            else
            {
                Console.WriteLine("Спасибо! Вот ваше местоположение:");
                render.ShowMap();
            }

            //Чистим окно вывода
            Console.ReadLine();
            Console.Clear();
        }
    }

    private class Map
    {
        public const int _mapLimit = 10;
        private int _xLimit;
        private int _yLimit;
        public readonly char MapIcon = '.';

        public Map(int XLimit, int YLimit)
        {
            _xLimit = XLimit;
            _yLimit = YLimit;
        }


        public int XLimit
        {
            get => _xLimit;
            set
            {
                if (value <= _mapLimit)
                    _xLimit = value;
                else
                    Console.WriteLine($"Map size cannot be more than {_mapLimit}");
            }
        }

        public int YLimit
        {
            get => _yLimit;
            set
            {
                if (value <= _mapLimit)
                    _yLimit = value;
                else
                    Console.WriteLine($"Map size cannot be more than {_mapLimit}");
            }
        }
        
    }

    private class Player
    {
        private int _x;
        private int _y;
        public readonly char PlayerIcon = '@';

        public int X
        {
            get => _x;
            set
            {
                if (value <= Map._mapLimit)
                    _x = value;
                else Console.WriteLine($"Map size cannot be more than {Map._mapLimit}");
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                if (value <= Map._mapLimit)
                    _y = value;
                else Console.WriteLine($"Map size cannot be more than {Map._mapLimit}");
            }
        }

        public void MovePlayer(int x, int y)
        {
            //возвращаем к свойствам для использования логики
            X = x;
            Y = y;
            
            _x = X;
            _y = Y;
        }
    }

    private class Render
    {
        private readonly Map _map;
        private readonly Player _player;

        public Render(Map map, Player player)
        {
            _map = map;
            _player = player;
        }


        public void ShowMap()
        {
            for (var i = 0; i < _map.YLimit; i++)
            {
                for (var j = 0; j < _map.XLimit; j++)
                    if (j == _player.X && i == _player.Y)
                        Console.Write(_player.PlayerIcon);
                    else Console.Write(_map.MapIcon);

                Console.WriteLine();
            }
        }
    }
}