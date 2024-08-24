namespace PortalLatihan.Application.ViewModel
{
    public class TrainingRejectRequest
    {
        public required Guid TrainingID { get; set; }
        public string? Remark { get; set; }
    }
}
