using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Extension
{
    public static class StringExtension
    {
        public static BuyerTypeEnum ToBuyerTypeEnum(this string buyerType)
        {
            return BuyerTypeEnumExtension.FromString(buyerType);
        }

        public static DiscountTypeEnum ToDiscountTypeEnum(this string discountType)
        {
            return DiscountTypeEnumExtension.FromString(discountType);
        }

        public static IdentityTypeEnum ToIdentityTypeEnum(this string identityType)
        {
            return IdentityTypeEnumExtension.FromString(identityType);
        }

        public static ParticipantStatusEnum ToParticipantStatusEnum(this string participantStatus)
        {
            return ParticipantStatusEnumExtension.FromString(participantStatus);
        }

        public static TicketStatusEnum ToTicketStatusEnum(this string ticketStatus)
        {
            return TicketStatusEnumExtension.FromString(ticketStatus);
        }

        public static TrainingStatusEnum ToTrainingStatusEnum(this string trainingStatus)
        {
            return TrainingStatusEnumExtension.FromString(trainingStatus);
        }
    }
}
