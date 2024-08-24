namespace PortalLatihan.Application.ViewModel
{
    public class TrainingAddRequest
    {
        public required Guid ZoneID { get; set; }
        public required Guid RegionID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateTime EventDate { get; set; }
        public required string Location { get; set; }
        public required int DurationInDays { get; set; }
        public required int MinParticipant { get; set; }
        public required int MaxParticipant { get; set; }
        public required List<TrainingFeeListRequest> FeeList { get; set; }
        public List<TrainingDiscountGroupListRequest>? DiscountGroupList { get; set; }
        public List<TrainingDiscountCodeListRequest>? DiscountCodeList { get; set; }

        public void Validate()
        {
            if (DurationInDays <= 0)
            {
                throw new Exception("Duration must be greater than 0");
            }

            if (MinParticipant <= 0)
            {
                throw new Exception("Min Participant must be greater than 0");
            }

            if (MaxParticipant <= 0) {
                throw new Exception("Max Participant must be greater than 0");
            }

            if (MinParticipant > MaxParticipant)
            {
                throw new Exception("Min Participant must be less than or equal to Max Participant");
            }

            if (EventDate < DateTime.Now)
            {
                throw new Exception("Event Date must be greater than current date");
            }

            if (FeeList == null || FeeList.Count == 0)
            {
                throw new Exception("Fee List must be provided");
            }

            foreach(var fee in FeeList)
            {
                fee.Validate();
            }

            if (DiscountGroupList != null)
            {
                foreach (var discountGroup in DiscountGroupList)
                {
                    discountGroup.Validate();
                }
            }

            if (DiscountCodeList != null)
            {
                foreach (var discountCode in DiscountCodeList)
                {
                    discountCode.Validate();
                }
            }
        }

    }
}
