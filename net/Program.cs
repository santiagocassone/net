
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

var result = tournaments.Where(t => t.StartsAt > today && t.StartsAt < today.AddDays(30)).GroupBy(t => t.Club).Select(t => new { Club = t.Key, TournamentCount = t.Count() }).Where(t => t.TournamentCount >= 2).OrderBy(t => t.TournamentCount).ThenBy(t => t.Club).ToList();

public enum Category { Primera, Segunda, Tercera, Cuarta, Quinta, Sexta, Septima }

public record Tournament(string Club, DateTime StartsAt, decimal Price, Category Category);



