
//Bloque 1 LINQ
using System.Data;
using System.Security.Cryptography.X509Certificates;

var today = DateTime.Today;

var tournaments = new List<Tournament>
{
    // Club Norte: 3 futuros, 1 pasado
    new("Club Norte", today.AddDays(2),   15000m, Category.Cuarta),
    new("Club Norte", today.AddDays(10),  18000m, Category.Quinta),
    new("Club Norte", today.AddDays(25),  16000m, Category.Sexta),
    new("Club Norte", today.AddDays(-5),  14000m, Category.Cuarta),

    // Padel Sur: 2 futuros (empata con Arena Oeste)
    new("Padel Sur",  today.AddDays(1),   20000m, Category.Tercera),
    new("Padel Sur",  today.AddDays(30),  22000m, Category.Cuarta),   // límite exacto
    new("Padel Sur",  today.AddDays(45),  21000m, Category.Quinta),   // fuera del rango

    // Arena Oeste: 2 futuros (empata con Padel Sur)
    new("Arena Oeste", today.AddDays(7),  12000m, Category.Sexta),
    new("Arena Oeste", today.AddDays(14), 13000m, Category.Septima),

    // Centro Padel: 1 futuro (no debería aparecer)
    new("Centro Padel", today.AddDays(3), 17000m, Category.Segunda),
    new("Centro Padel", today.AddDays(-20), 17000m, Category.Segunda),

    // Club Este: solo pasados (no debería aparecer)
    new("Club Este",  today.AddDays(-1),  19000m, Category.Primera),
    new("Club Este",  today.AddDays(-15), 19000m, Category.Primera),
};

var result = tournaments
    .Where(t => t.StartsAt > today && t.StartsAt < today.AddDays(30))
    .GroupBy(t => t.Club)
    .Select(g => new { Club = g.Key, TournamentCount = g.Count(), AveragePrice = g.Average(x => x.Price) })
    .Where(g => g.TournamentCount >= 2)
    .OrderByDescending(g => g.TournamentCount)
    .ThenBy(g => g.Club)
    .ToList();

// Cuenta uno mas luego de agregar el torneo.
var futureTournaments = tournaments.Where(t => t.StartsAt > today);
Console.WriteLine(futureTournaments.Count());
tournaments.Add(new Tournament("Club Norte", today.AddDays(5), 15500m, Category.Cuarta));
Console.WriteLine(futureTournaments.Count());

// se incrementa cada vez que se ejecuta la consulta
int counter = 0;
var futureTournaments2 = tournaments.Where(x => { counter++; return x.StartsAt > today; });
futureTournaments2.Count();
futureTournaments2.ToList();
Console.WriteLine(counter);

// el primero ejecuta el where en el operador de DB y el segundo en memoria.

static List<T> Filter<T>(List<T> items, Func<T, bool> condition)
{
    var result = new List<T>();
    foreach (var item in items)
    {
        if (condition(item))
        {
            result.Add(item);
        }
    }
    return result;
}

var tournaments3 = Filter(tournaments, x => x.Price > 15000m);
var tournaments4 = Filter(tournaments, x => x.Club == "Club Norte");


static void Print(Action<string> voidFunc)
{
    voidFunc("Hola mundo");
}

Print(message => Console.WriteLine(message));
Print(message => { List<string> list = new List<string> { message }; });

var functions = new List<Func<int>>();

for (int i = 0; i < 3; i++)
{
    functions.Add(() => i);
}

foreach (var func in functions)
{
    Console.WriteLine(func());
}

var functions2 = new List<Func<int>>();

foreach (var item in new[] { 0, 1, 2 })
{
    functions2.Add(() => item);
}

foreach (var func in functions2)
{
    Console.WriteLine(func());
}

Bule first = new Bule { x = 1 };
Bule second = first;
second.x = 99;
// imprime 1
Console.WriteLine(first.x);


Bule2 first2 = new Bule2 { x = 1 };
Bule2 second2 = first2;
second2.x = 99;
// imprime 99
Console.WriteLine(first2.x);

List<int> numbers = new List<int> { 1, 2 };

AddNumber(numbers);

// imprime 1, 2, 3
Console.WriteLine(string.Join(", ", numbers));

AddNumber2(numbers);
// imprime 1, 2, 3
Console.WriteLine(string.Join(", ", numbers));

AddNumber3(ref numbers);
// imprime 99
Console.WriteLine(string.Join(", ", numbers));

static void AddNumber(List<int> numbers)
{
    numbers.Add(3);
}

static void AddNumber2(List<int> numbers)
{
    numbers = new List<int> { 99 };
}

static void AddNumber3(ref List<int> numbers)
{
    numbers = new List<int> { 99 };
}

string asdf = "a";
string qwer = asdf;
qwer += "b";
// imprime a
Console.WriteLine(asdf);



Datas data1 = new("Juan", "Madrid");
Datas data2 = new("Juan", "Madrid");

Console.WriteLine(data1 == data2); // true


Datas2 datas1 = new("Juan", "Madrid");
Datas2 datas2 = new("Juan", "Madrid");
Console.WriteLine(datas1 == datas2); // false

Datas data3 = data1 with { City = "Barcelona" };

Console.WriteLine(data1.ToString());
Console.WriteLine(data3.ToString());

Console.WriteLine(Counter(null));
Console.WriteLine(Counter("asdf"));



// un entero nullable es un nuevo tipo struct con dos propiedades: HasValue y Value, un string nullable simplemente emite warnings cuando no se comprueba si es null antes de usarlo.
static int Counter(string? name)
{
    return name?.Length ?? 0;
}


//using (var fakeConnection = new FakeConnection())
//{
//    fakeConnection.Query();
//}

//Console.WriteLine("Fin del bloque");

// Conexión abierta -> Consultando -> Conexión cerrada -> Fin del bloque


    try
    {
    using (var fakeConnection = new FakeConnection())
    {
        fakeConnection.Query();

    }
}
    catch (Exception)
    {
        Console.WriteLine("Error capturado");
    }

// Conexión abierta -> Conexión cerrada -> Error capturado


// porque httpclient se reutiliza y si cerramos todos los request cuando finalizan se agotan los sockets.

Level1();
// el origen del error es el método Level3

static void Level3()
{
    throw new InvalidOperationException();
}

static void Level2()
{
    try
    {
        Level3();
    }
    catch (Exception)
    {

        throw;
    }
}

static void Level1()
{
    try
    {
        Level2();
    }
    catch (Exception ex)
    {
        Console.Write(ex.ToString());
    }
}


class FakeConnection : IDisposable
{
    public FakeConnection()
    {
        Console.WriteLine("Conexión abierta");
    }

    public void Dispose()
    {
        Console.WriteLine("Conexión cerrada");
    }

    public void Query()
    {
        throw new Exception();
    }
}



class Datas2
{
    public string Name { get; set; }
    public string City { get; set; }
    public Datas2(string name, string city)
    {
        Name = name;
        City = city;
    }
}


record Datas(string Name, string City);

struct Bule
{
    public int x { get; set; }
};

class Bule2
{
    public int x { get; set; }
}



public enum Category { Primera, Segunda, Tercera, Cuarta, Quinta, Sexta, Septima }

public record Tournament(string Club, DateTime StartsAt, decimal Price, Category Category);



