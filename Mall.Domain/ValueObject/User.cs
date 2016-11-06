using System;

namespace Mall.Domain.ValueObject
{
    public class User : Infrastructure.DomainCore.ValueObject
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal AvailableBalance { get; private set; }

        public User(Guid userId, string userName, decimal availableBalance)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("参数不能为Guid.Empty", "userId");
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");
            if (availableBalance < 0)
                throw new ArgumentOutOfRangeException("availableBalance", "参数不能小于0");

            this.UserId = userId;
            this.UserName = userName;
            this.AvailableBalance = availableBalance;
        }
    }
}
