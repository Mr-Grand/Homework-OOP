namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        var map = new Map[5, 5];
        map

    }

    class Map
    {
        private int[] _xLimit;
        private int[] _yLimit;
        private const int _mapLimit = 10;
        public char MapIcon = '.';
        

        public int XLimit
        {
            get { return XLimit; }
            set
            {
                if (XLimit <= _mapLimit)
                {
                    _xLimit = new int[XLimit];
                }
                else 
                    Console.WriteLine($"Map size cannot be more than {_mapLimit}");
            }
        }

        public int YLimit
        {
            get { return YLimit; }
            set
            {
                if (YLimit <= _mapLimit)
                {
                    _yLimit = new int[YLimit];
                }
                else 
                    Console.WriteLine($"Map size cannot be more than {_mapLimit}");
            }
        }

        public Map(int XLimit, int YLimit)
        {
            _xLimit = new int[XLimit];
            _yLimit = new int[YLimit];
        }

        public void InitializeMap()
        {
            for (int i = 0; i < YLimit; i++)
            {
                for (int j = 0; j < XLimit; j++)
                {
                    Map[i, j] = MapIcon;
                }
            }
        }

        public void GetMap()
        {
            
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