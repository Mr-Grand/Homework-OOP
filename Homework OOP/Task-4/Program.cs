namespace Task_4;

class Program
{
    static void Main(string[] args)
    {
        Deck deck = new();
        Player player = new();
        CurrentDeck currentDeck = new();

        // Заполняем текущую колоду копиями карт
        for (int i = 1; i < deck.GetCount()+1; i++)
        {
            currentDeck.AddCard(deck.GetCardAtNumber(i));
        }


        do
        {
            Random random = new();
            Console.WriteLine($"Здравствуйте! Сейчас в колоде {currentDeck.GetCount()+1} карт!" +
                              $"\nВы можете взять {player.MaxCount}. Какую выберете?");
            
            int CardNumber = Convert.ToInt32(Console.ReadLine());
            if (CardNumber <= currentDeck.GetCount())
            {
                player.TakeCard(currentDeck.GetCardAtNumber(CardNumber));
                currentDeck.RemoveCard(CardNumber);
            }
            else
            {
                Console.WriteLine("Выберите карту из списка!");
                continue;
            }

            player.Count++;
            player.MaxCount--;

        } while (player.Count < 4);
        
        Console.WriteLine("\n** " + new string('-',20) + " **");
        Console.WriteLine("Взятые карты:");
        player.ShowCards();
        Console.Write("\n** " + new string('-',20) + " **");
        
    }

    class Player
    {
        private List<Card> _takenCards = new();
        private int _count = 0;
        private int _maxCount = 4;

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public int MaxCount
        {
            get => _maxCount;
            set => _maxCount = value;
        }
        
        public void TakeCard(Card card)
        {
            _takenCards.Add(card);
        }
        

        public void ShowCards()
        {
            foreach (Card card in _takenCards)
            {
                Console.WriteLine($"{card.Suit} - {card.ValueName}");
            }
        }
        
    }

    class Card
    {
        public string Suit { get; private set; }
        public string ValueName { get; private set; }
        

        public Card(string suit, string value)
        {
            Suit = suit;
            ValueName = value;
        }
        
    }

    class Deck
    {
        private Card[] _cardsDeck =
        {
            new Card("Diamonds", "T"),
            new Card("Diamonds", "K"),
            new Card("Diamonds", "J"),
            new Card("Diamonds", "Q"),
            new Card("Diamonds", "10"),
            new Card("Diamonds", "9"),
            new Card("Diamonds", "8"),
            new Card("Diamonds", "7"),
            new Card("Diamonds", "6"),
            new Card("Hearts", "T"),
            new Card("Hearts", "K"),
            new Card("Hearts", "J"),
            new Card("Hearts", "Q"),
            new Card("Hearts", "10"),
            new Card("Hearts", "9"),
            new Card("Hearts", "8"),
            new Card("Hearts", "7"),
            new Card("Hearts", "6"),
            new Card("Spades", "T"),
            new Card("Spades", "K"),
            new Card("Spades", "J"),
            new Card("Spades", "Q"),
            new Card("Spades", "10"),
            new Card("Spades", "9"),
            new Card("Spades", "8"),
            new Card("Spades", "7"),
            new Card("Spades", "6"),
            new Card("Clubs", "T"),
            new Card("Clubs", "K"),
            new Card("Clubs", "J"),
            new Card("Clubs", "Q"),
            new Card("Clubs", "10"),
            new Card("Clubs", "9"),
            new Card("Clubs", "8"),
            new Card("Clubs", "7"),
            new Card("Clubs", "6")

        };
        
        
        public int GetCount() => _cardsDeck.Length;
        public Card GetCardAtNumber(int number) => _cardsDeck.ElementAt(number - 1);
        
        
    }

    class CurrentDeck
    {
        private List<Card> _deck = new();

        public List<Card> Deck
        {
            get => _deck;
            private set => _deck = value;
        }

        public void AddCard(Card card)
        {
            _deck.Add(card);
        }

        public void RemoveCard(int index)
        {
            _deck.RemoveAt(index-1);
        }
        
        public Card GetCardAtNumber(int number) => _deck.ElementAt(number - 1);

        public void ShowCards()
        {
            foreach (Card card in _deck)
            {
                Console.WriteLine($"{card.Suit} - {card.ValueName}");
            }
        }
        
        public int GetCount() => _deck.Count;
    }
}