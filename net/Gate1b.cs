public static class Gate1b
{
    public static void Run()
    {
        var repository = new Repository<Quote>();
        var quote1 = new Quote("asdf", "Talanga", 2);
        var quote2 = new Quote("sdfg", "Tolongo", 3);
        var quote3 = new Quote("dfgh", "Tulungu", 4);

        repository.Add(quote1);
        repository.Add(quote2);
        repository.Add(quote3);
        quote1.AddQuoteLine(new QuoteLine("1", 5, 10));
        quote1.AddQuoteLine(new QuoteLine("2", 3, 20));
        try
        {
            quote1.AddQuoteLine(new QuoteLine("3", 7, 60));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

        quote2.AddQuoteLine(new QuoteLine("1", 5, 10));
        quote2.AddQuoteLine(new QuoteLine("1", 5, 10));

        var quoteFind = repository.Find("asdf");
        if (quoteFind != null)
        {
            Console.WriteLine($"Customer: {quoteFind.CustomerName} - Total: {quoteFind.QuoteLines.Select(q => q.Value).Sum(v => v.price * v.quantity)}");
        }
        var unexistingQuoteFind = repository.Find("fghj");
        var codeQuantity = repository.Items.SelectMany(i => i.QuoteLines).Select(ql => ql.Value).GroupBy(v => v.code).Select(g => new { Code = g.Key, Quantity = g.Sum(x => x.quantity) }).Take(3).OrderByDescending(s => s.Quantity);

        foreach (var item in codeQuantity)
        {
            Console.WriteLine($"Code: {item.Code} - Quantity: {item.Quantity}");
        }
    }

    public record QuoteLine(string code, int quantity, decimal price);

    public interface IContract
    {
        string Code { get; }
    }

    public class Quote : IContract
    {
        private readonly string _code;
        private readonly string _customerName;
        private readonly int _maxQuoteLines;
        public string Code => _code;
        public string CustomerName => _customerName;
        public int MaxQuoteLines => _maxQuoteLines;
        private readonly Dictionary<string, QuoteLine> _quoteLines = new();
        public IReadOnlyDictionary<string, QuoteLine> QuoteLines => _quoteLines;
        public Quote(string code, string customerName, int maxQuoteLines)
        {
            _code = code;
            _customerName = customerName;
            _maxQuoteLines = maxQuoteLines;
        }
        public void AddQuoteLine(QuoteLine quoteLine)
        {
            QuoteLine existingQuote;
            if (_quoteLines.TryGetValue(quoteLine.code, out existingQuote))
            {
                int oldQuantity = existingQuote.quantity;
                _quoteLines.Remove(existingQuote.code);
                _quoteLines.Add(quoteLine.code, quoteLine with { quantity = oldQuantity + quoteLine.quantity });
            }
            else if (_quoteLines.Count < _maxQuoteLines)
            {
                _quoteLines.Add(quoteLine.code, quoteLine);
            }
            else
            {
                throw new InvalidOperationException("Unable to insert Quote. Maximum lines reached");
            }
        }

        
    }
    public class Repository<T> where T : IContract
    {
        private readonly Dictionary<string, T> _items = new();
        public void Add(T item) => _items.Add(item.Code, item);
        public T? Find(string code) => _items.GetValueOrDefault(code);
        public IReadOnlyCollection<T> Items => _items.Values;
    }
}