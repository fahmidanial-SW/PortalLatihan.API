namespace PortalLatihan.Application.ViewModel
{
    public class TrainingApproveRequest
    {
        public required Guid TrainingID { get; set; }
        public string? Remark { get;set; }
    }
}
