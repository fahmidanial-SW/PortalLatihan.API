using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface IStaffService
    {
        Task Add(StaffAddRequest staffInsertRequest, string user);
        TokenDataVM CheckToken(string token);
        Task<string> GetUserToken(StaffLoginRequest staffLoginRequest);
    }
}
