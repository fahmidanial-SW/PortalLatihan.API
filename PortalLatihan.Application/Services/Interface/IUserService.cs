using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface IUserService
    {
        Task<string> Login(StaffLoginRequest model);
        Task Register(StaffAddRequest model);
    }
}
