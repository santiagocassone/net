
//Bloque 1 LINQ
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


public enum Category { Primera, Segunda, Tercera, Cuarta, Quinta, Sexta, Septima }

public record Tournament(string Club, DateTime StartsAt, decimal Price, Category Category);



