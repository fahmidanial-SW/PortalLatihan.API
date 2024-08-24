namespace PortalLatihan.Application.ViewModel
{
    public class StaffAddRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public required string Email { get; set; }
    }
}
