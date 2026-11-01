public static class OOP
{
    public static void Run()
    {
        Animal dog = new Dog();
        dog.Speak();
        Animal cat = new Cat();
        cat.Speak();
        // dog -> Wouf, cat -> Animal

        var tournament = new Tournament(3);
        //tournament.Players.Add("Yo");
        // Players does not contains a definition for Add
    }

    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal");
        }
    }

    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Wouf");
        }
    }

    class Cat : Animal
    {
        public new void Speak()
        {
            Console.WriteLine("Miew");
        }
    }

    class Tournament
    {
        public int Spots { get; }
        private readonly List<string> _players = new();
        public IReadOnlyList<string> Players => _players;
        public Tournament(int spots)
        {
            Spots = spots;
        }
        public void AddPlayer(string name)
        {
            if (Spots < _players.Count)
            {
                _players.Add(name);
            } 
            else
            {
                throw new Exception();
            }
        }
    }
}
