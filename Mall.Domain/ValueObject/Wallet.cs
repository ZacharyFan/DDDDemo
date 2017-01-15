using System;

namespace Mall.Domain.ValueObject
{
    public class Wallet : Infrastructure.DomainCore.ValueObject
    {
        public string ID { get; private set; }

        public string UserId { get; private set; }

        public decimal AvailableBalance { get; private set; }

        public int AvailableScore { get; private set; }

        public Wallet(string id, string userId, decimal availableBalance, int availableScore)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");

            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");
        
            this.ID = id;
            this.UserId = userId;
            this.AvailableBalance = availableBalance;
            this.AvailableScore = availableScore;
        }
    }
}
