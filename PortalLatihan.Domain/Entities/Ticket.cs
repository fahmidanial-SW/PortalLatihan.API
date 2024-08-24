using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Entities
{
    public class Ticket : BaseDomainEntity
    {
        public required Guid TrainingID { get; set; }
        public Guid? TrainingDiscountCodeID { get; set; }
        public Guid? TrainingDiscountGroupID { get; set; }
        public required BuyerTypeEnum BuyerType { get; set; }
        public required string BuyerName { get; set; }
        public decimal FinalFee { get; private set; }
        public required decimal TotalFee
        {
            get => totalFee;
            set
            {
                totalFee = value;
                UpdateFinalFee();
            }
        }
        public required decimal DiscountCode
        {
            get => discountCode;
            set
            {
                discountCode = value;
                UpdateFinalFee();
            }
        }
        public required decimal DiscountGroup
        {
            get => discountGroup;
            set
            {
                discountGroup = value;
                UpdateFinalFee();
            }
        }       
        public TicketStatusEnum Status { get; private set; } 
        public Ticket()
        {
            Status = TicketStatusEnum.BOOKED;
            FinalFee = TotalFee - DiscountGroup - DiscountCode;
        }
        public void Validate()
        {
            if (TrainingID == Guid.Empty)
            {
                throw new InvalidDataException("Training ID is required");
            }

            if (string.IsNullOrEmpty(BuyerName))
            {
                throw new InvalidDataException("Buyer Name is required");
            }

            if (TotalFee <= 0)
            {
                throw new InvalidDataException("Base Fee must be greater than 0");
            }

            if (DiscountCode + DiscountGroup > TotalFee)
            {
                throw new InvalidDataException("Discounted Fee cannot be greater than Base Fee");
            }
        }
        public void ChangeStatusToPaid()
        {
            if (Status != TicketStatusEnum.BOOKED)
            {
                throw new InvalidDataException("Only Booked Ticket can be paid");
            }

            Status = TicketStatusEnum.PAID;
        }
        public void ChangeStatusToCancel()
        {
            Status = TicketStatusEnum.CANCELLED;
        }
        private void UpdateFinalFee()
        {
            FinalFee = TotalFee - DiscountCode - DiscountGroup;
        }

        private decimal totalFee;
        private decimal discountCode;
        private decimal discountGroup;
    }
}
