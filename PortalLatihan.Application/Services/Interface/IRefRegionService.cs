using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Application.Services.Interface
{
    public interface IRefRegionService
    {
        Task<string> GetNameByID(Guid ID);
    }
}