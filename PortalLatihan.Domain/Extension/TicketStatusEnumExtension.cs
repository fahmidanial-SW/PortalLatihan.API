using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Extension
{
    public static class TicketStatusEnumExtension
    {
        public static string ToString(this TicketStatusEnum ticketStatusEnum)
        {
            return ticketStatusEnum switch
            {
                TicketStatusEnum.BOOKED => "BOOKED",
                TicketStatusEnum.PAID => "PAID",
                TicketStatusEnum.CANCELLED => "CANCELLED",
                _ => "Unknown"
            };
        }

        public static TicketStatusEnum FromString(string ticketStatus)
        {
            return ticketStatus switch
            {
                "BOOKED" => TicketStatusEnum.BOOKED,
                "PAID" => TicketStatusEnum.PAID,
                "CANCELLED" => TicketStatusEnum.CANCELLED,
                _ => throw new InvalidDataException("Invalid TicketStatus")
            };
        }
    }
}
