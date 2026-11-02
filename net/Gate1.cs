public static class Gate1
{
    public static void Run()
    {
        var tournament1 = new Tournament("Lolo", 4);
        var tournament2 = new Tournament("Lele", 8);
        var tournament3 = new Tournament("Lulu", 16);
        var repository = new Repository<Tournament>();
        repository.Post(tournament1);
        repository.Post(tournament2);
        repository.Post(tournament3);
        List<Player> players = new();
        players.Add(new Player("Juan", Category.Rookie));
        players.Add(new Player("Pedro", Category.Intermediate));
        players.Add(new Player("Paco", Category.Advanced));
        players.Add(new Player("De la Mar", Category.Intermediate));
        players.Add(new Player("Es mi nombre así", Category.Rookie));
        foreach (var item in players)
        {
            try
            {
                tournament1.AddPlayer(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        try
        {
            tournament2.AddPlayer(new Player("Juan", Category.Rookie));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            tournament2.AddPlayer(new Player("Juan", Category.Rookie));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(repository.GetById(0).Name);

        var tournamentStats = repository.Items.SelectMany(x => x.Players).GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count() }).OrderByDescending(c => c.Count);
        foreach (var item in tournamentStats)
        {
            Console.WriteLine($"Category: {item.Category} - Count: {item.Count}" );
        }
        
    }

    record Player(string Name, Category Category);

    enum Category
    {
        Rookie,
        Intermediate,
        Advanced
    }

    interface IId
    {
        int Id { get; }
    }

    class Tournament : IId
    {
        static int NextId;
        private readonly int _id;
        private readonly string _name;
        private readonly int _spots;
        private readonly HashSet<Player> _players = new();
        public IReadOnlyCollection<Player> Players => _players;
        public int Id => _id;
        public string Name => _name;
        public int Spots => _spots;
        public Tournament(string name, int spots)
        {
            _id = NextId;
            NextId++;
            _name = name;
            _spots = spots;
        }
        public void AddPlayer(Player player)
        {
            if (_players.Count < _spots)
            {
                if (!_players.Add(player))
                    throw new InvalidOperationException("Player already in tournament");
            }
            else
            {
                throw new InvalidOperationException("No more spots");
            }
        }
    }

    class Repository<T> where T : IId
    {
        private readonly Dictionary<int, T> _items = new();
        public T? GetById(int id) => _items.GetValueOrDefault(id);
        public void Post(T item) => _items.Add(item.Id, item);
        public IReadOnlyCollection<T> Items => _items.Values;
    }
}
