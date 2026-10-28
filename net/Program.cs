using net;
using System.Xml.Linq;

// Bloque 1
var orders = new List<Order>
{
    new Order(1, 100.0, DateTime.Today - TimeSpan.FromDays(40), State.Completed),
    new Order(2, 200.0, DateTime.Now, State.Processing),
    new Order(3, 150.0, DateTime.Now, State.Pending),
    new Order(1, 200.0, DateTime.Now, State.Completed),
    new Order(1, 300.0, DateTime.Now, State.Completed),
    new Order(1, 400.0, DateTime.Now, State.Completed)
};

var result = orders.Where(o => o.CreatedAt < DateTime.Today - TimeSpan.FromDays(30) && o.State == State.Completed).OrderByDescending(o => o.Amount).ToList();


//Bloque 2

var task1 = Task.Delay(1000);
var task2 = Task.Delay(1500);
var task3 = Task.Delay(3000);
var task4 = Task.Delay(4000);
var task5 = Task.Delay(5000);

var cancellationTokenSource = new CancellationTokenSource();

cancellationTokenSource.CancelAfter(2000);

await WaitForAllTasksAsync(cancellationTokenSource.Token);

async Task<bool> WaitForAllTasksAsync(CancellationToken cancellationToken)
{
    var tasks = new List<Task> { task1, task2, task3, task4, task5 };
    await Task.WhenAll(tasks);
    return true;
}

//Bloque 4

SELECT cl.Name, SUM(tr.Id) AS TournamentsCount
    FROM Clubs cl
        LEFT JOIN Tournaments tr
    ON cl.Id = tr.ClubId
    GROUP BY cl.Name
    HAVING tr.StartsAt >= GETDATE() AND tr.StartsAt <= DATEADD(DAY, 30, GETDATE());

SELECT cl.Name, AVG(tr.Price) AS AveragePrice
    FROM Clubs cl
        LEFT JOIN Tournaments tr
    ON cl.Id = tr.ClubId
    GROUP BY cl.Name;


SELECT cl.Name, tr.Id, MAX(tr.Price) AS MaxPrice
    FROM Clubs cl
        LEFT JOIN Tournaments tr
    ON cl.Id = tr.ClubId
    GROUP BY cl.Name, tr.Id;
