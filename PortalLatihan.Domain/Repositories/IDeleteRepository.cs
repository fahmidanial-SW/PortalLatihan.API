namespace PortalLatihan.Domain.Repositories
{
    public interface IDeleteRepository
    {
        public Task Delete(Guid ID);
    }
}
