namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        var map1 = new Map(5,5);
        map1.InitializeMap();
        

        Render rend = new Render(map1);
        rend.ShowMap();

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

        /*public void ShowMap()
        {
            for (int i = 0; i < YLimit; i++)
            {
                for (int j = 0; j < XLimit; j++)
                {
                    Console.Write(Coordinate[i, j]);
                }
                Console.WriteLine();
            }
        }*/

        public char GetPoint(int x, int y)
        {
            return Coordinate[x, y];
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
            
        }
    }

    class Render
    {
        private Map _map;

        public Render(Map map)
        {
            _map = map;
        }

        public void ShowMap()
        {
            for (int i = 0; i < _map.YLimit; i++)
            {
                for (int j = 0; j < _map.XLimit; j++)
                {
                    Console.Write(_map.Coordinate[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}