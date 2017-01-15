namespace Mall.Domain.ValueObject
{
    public class PaymentMethod : Infrastructure.DomainCore.ValueObject
    {
        public string ID { get; private set; }

        public string Name { get; private set; }

        public PaymentMethod(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
