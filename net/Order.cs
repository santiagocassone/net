namespace net
{
    public class Order
    {
        public int ClientId { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public double Amount { get; internal set; }
        public State State { get; internal set; }

        public Order(int clientId, double amount, DateTime createdAt, State state)
        {
            ClientId = clientId;
            CreatedAt = createdAt;
            Amount = amount;
            State = state;
        }
    }
}
