namespace Mall.Infrastructure.DomainCore
{
    public interface IRepository<T> where T : DelegateIdentifier, IAloneStorable
    {
        string NextIdentity();

        void Save(T aggregate);

        T GetByIdentity(string identity);
    }
}
