using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Extension
{
    public static class TrainingStatusEnumExtension
    {
        public static string ToString(this TrainingStatusEnum trainingStatusEnum)
        {
            return trainingStatusEnum switch
            {
                TrainingStatusEnum.PENDING_APPROVAL => "PENDING_APPROVAL",
                TrainingStatusEnum.APPROVED => "APPROVED",
                TrainingStatusEnum.REJECTED => "REJECTED",
                _ => "Unknown"
            };
        }

        public static TrainingStatusEnum FromString(string trainingStatus)
        {
            return trainingStatus switch
            {
                "PENDING_APPROVAL" => TrainingStatusEnum.PENDING_APPROVAL,
                "APPROVED" => TrainingStatusEnum.APPROVED,
                "REJECTED" => TrainingStatusEnum.REJECTED,
                _ => throw new InvalidDataException("Invalid TrainingStatus")
            };
        }
    }
}
