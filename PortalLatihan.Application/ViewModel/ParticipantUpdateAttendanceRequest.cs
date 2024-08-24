namespace PortalLatihan.Application.ViewModel
{
    public class ParticipantUpdateAttendanceRequest
    {
        public required Guid ID { get; set; }
        public required bool IsAttended { get; set; }

        public void Validate()
        {

        }
    }
}
