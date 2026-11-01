using System.Diagnostics;

public static class Collections
{
    public static void Run()
    {
        List<int> intList = new();
        HashSet<int> intHash = new();
        for (int i = 0; i < 100000; i++)
        {
            intHash.Add(i);
            intList.Add(i);
        }

        var chron = Stopwatch.StartNew();
        for (int i = 0; i < 10000; i++)
        {
            intList.Contains(i);
        }
        Console.WriteLine("List Elapsed");
        Console.WriteLine(chron.Elapsed.TotalMilliseconds);

        chron.Restart();
        for (int i = 0; i < 10000; i++)
        {
            intHash.Contains(i);
        }
        Console.WriteLine("HashSet Elapsed");
        Console.WriteLine(chron.Elapsed.TotalMilliseconds);
        // sin herramientas para estimar, diógenes

        HashSet<Club> clubs = new();
        clubs.Add(new Club("A", "Buenos Aires"));
        clubs.Add(new Club("A", "Buenos Aires"));
        Console.WriteLine(clubs.Count);
        //1

        HashSet<ClubClass> clubsByClass = new();
        clubsByClass.Add(new ClubClass() { city = "A", name = "Buenos Aires" });
        clubsByClass.Add(new ClubClass() { city = "A", name = "Buenos Aires" });
        Console.WriteLine(clubsByClass.Count);
        //2

    }

    public record Club(string name, string city);
    public class ClubClass
    {
        public string name = String.Empty;
        public string city = String.Empty;
    }
}
