namespace Task_4;

internal class Program
{
    private static void Main(string[] args)
    {
        Deck deck = new();
        Player player = new();
        CurrentDeck currentDeck = new();

        // Заполняем текущую колоду копиями карт
        for (int i = 1; i < deck.GetCount() + 1; i++) currentDeck.AddCard(deck.GetCardAtNumber(i));


        // Цикл взятия карт игроком
        string StopWord = null;
        do
        {
            Random random = new();
            Console.WriteLine($"Здравствуйте! Сейчас в колоде {currentDeck.GetCount() + 1} карт!" +
                              $"\nВы можете взять {player.MaxCurrentTakenCount}. Какую выберете?");

            var CardNumber = Console.ReadLine();

            if (CardNumber == "Stop")
            {
                StopWord = CardNumber;
                continue;
            }
            else if (Convert.ToInt32(CardNumber) <= currentDeck.GetCount() && Convert.ToInt32(CardNumber) > 0)
            {
                
                player.TakeCard(currentDeck.GetCardAtNumber(Convert.ToInt32(CardNumber)));
                currentDeck.RemoveCard(Convert.ToInt32(CardNumber));
            }
            else
            {
                Console.WriteLine("Выберите карту из списка!");
                continue;
            }

            player.TakenCount++;
            player.MaxCurrentTakenCount--;
        } while ((player.TakenCount < player.MaxTakenCount) && StopWord != "Stop");

        Console.WriteLine("\n** " + new string('-', 20) + " **");
        Console.WriteLine("Взятые карты:");
        player.ShowCards();
        Console.Write("\n** " + new string('-', 20) + " **");
    }

    private class Player
    {
        private List<Card> _takenCards = new();
        private int _takenCount = 0;
        private int _maxCurrentTakenCount = 4;
        private int _maxTakenCount = 4;

        public int TakenCount
        {
            get => _takenCount;
            set => _takenCount = value;
        }

        public int MaxTakenCount
        {
            get => _maxTakenCount;
            set => _maxTakenCount = value;
        }
        
        public int MaxCurrentTakenCount
        {
            get => _maxCurrentTakenCount;
            set => _maxCurrentTakenCount = value;
        }

        public void TakeCard(Card card)
        {
            _takenCards.Add(card);
        }


        public void ShowCards()
        {
            foreach (Card card in _takenCards) Console.WriteLine($"{card.Suit} - {card.ValueName}");
        }
    }

    private class Card
    {
        public string Suit { get; private set; }
        public string ValueName { get; private set; }


        public Card(string suit, string value)
        {
            Suit = suit;
            ValueName = value;
        }
    }

    private class Deck
    {
        private Card[] _cardsDeck =
        {
            new("Diamonds", "T"),
            new("Diamonds", "K"),
            new("Diamonds", "J"),
            new("Diamonds", "Q"),
            new("Diamonds", "10"),
            new("Diamonds", "9"),
            new("Diamonds", "8"),
            new("Diamonds", "7"),
            new("Diamonds", "6"),
            new("Hearts", "T"),
            new("Hearts", "K"),
            new("Hearts", "J"),
            new("Hearts", "Q"),
            new("Hearts", "10"),
            new("Hearts", "9"),
            new("Hearts", "8"),
            new("Hearts", "7"),
            new("Hearts", "6"),
            new("Spades", "T"),
            new("Spades", "K"),
            new("Spades", "J"),
            new("Spades", "Q"),
            new("Spades", "10"),
            new("Spades", "9"),
            new("Spades", "8"),
            new("Spades", "7"),
            new("Spades", "6"),
            new("Clubs", "T"),
            new("Clubs", "K"),
            new("Clubs", "J"),
            new("Clubs", "Q"),
            new("Clubs", "10"),
            new("Clubs", "9"),
            new("Clubs", "8"),
            new("Clubs", "7"),
            new("Clubs", "6")
        };


        public int GetCount()
        {
            return _cardsDeck.Length;
        }

        public Card GetCardAtNumber(int number)
        {
            return _cardsDeck.ElementAt(number - 1);
        }
    }

    private class CurrentDeck
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
            _deck.RemoveAt(index - 1);
        }

        public Card GetCardAtNumber(int number)
        {
            return _deck.ElementAt(number - 1);
        }

        public void ShowCards()
        {
            foreach (Card card in _deck) Console.WriteLine($"{card.Suit} - {card.ValueName}");
        }

        public int GetCount()
        {
            return _deck.Count;
        }
    }
}