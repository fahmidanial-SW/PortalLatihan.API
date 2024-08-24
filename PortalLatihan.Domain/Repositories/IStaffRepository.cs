using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Task<Staff> GetByUsername(string username);
    }
}
