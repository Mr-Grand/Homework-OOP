namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        var map = new Map(5,5);
        map.InitializeMap();
        map.ShowMap();
        /*Console.Write(map[0, 0]);
        Console.Write(map[1, 1]);
        Console.Write(map[2, 2]);*/

    }

    class Map
    {
        public char[,] _coordinate;
        private int _xLimit;
        private int _yLimit;
        private const int _mapLimit = 10;
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
            _coordinate = new char[XLimit, YLimit];
        }

        public void InitializeMap()
        {
            for (int i = 0; i < YLimit; i++)
            {
                for (int j = 0; j < XLimit; j++)
                {
                    _coordinate[i, j] = MapIcon;
                }
            }
        }

        public void ShowMap()
        {
            for (int i = 0; i < YLimit; i++)
            {
                for (int j = 0; j < XLimit; j++)
                {
                    Console.Write(_coordinate[i, j]);
                }
                Console.WriteLine();
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
            set { _x = value; }
            
        }
    }

    class Render
    {
        
    }
}