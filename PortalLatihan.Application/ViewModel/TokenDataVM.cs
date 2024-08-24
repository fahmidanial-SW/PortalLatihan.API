namespace PortalLatihan.Application.ViewModel
{
    public class TokenDataVM
    {
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required DateTime Expired { get; set; }
    }
}
