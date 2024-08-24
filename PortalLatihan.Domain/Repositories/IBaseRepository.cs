namespace PortalLatihan.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<List<T>> GetListAll();
        public Task<T> GetByID(Guid ID);
        public Task Add(T input, string user);
        public Task Update(Guid ID, T input, string user);
    }
}
