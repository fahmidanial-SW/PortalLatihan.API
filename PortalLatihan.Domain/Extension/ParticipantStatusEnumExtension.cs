using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Extension
{
    public static class ParticipantStatusEnumExtension
    {
        public static string ToString(this ParticipantStatusEnum participantStatus)
        {
            return participantStatus switch
            {
                ParticipantStatusEnum.REGISTERED => "Registered",
                ParticipantStatusEnum.PAID => "Paid",
                ParticipantStatusEnum.CANCELLED => "Cancelled",
                _ => "Unknown"
            };
        }

        public static ParticipantStatusEnum FromString(string participantStatus)
        {
            return participantStatus switch
            {
                "Registered" => ParticipantStatusEnum.REGISTERED,
                "Paid" => ParticipantStatusEnum.PAID,
                "Cancelled" => ParticipantStatusEnum.CANCELLED,
                _ => throw new InvalidDataException("Invalid ParticipantStatus")
            };
        }
    }
}
