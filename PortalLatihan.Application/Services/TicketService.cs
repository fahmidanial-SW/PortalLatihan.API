using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.Services
{
    public class TicketService(IUnitOfWork unitOfWork) : ITicketService
    {
        public async Task<List<TicketListResponse>> GetList()
        {
            try
            {
                var ticketList = await unitOfWork.Ticket_List();
                
                List<TicketListResponse> result = [];

                foreach (var ticket in ticketList)
                {
                    var participantList = await unitOfWork.Participant_List_ByTicketID(ticket.ID);
                    
                    TicketListResponse item = new()
                    {
                        ID = ticket.ID,
                        TrainingID = ticket.TrainingID,
                        BuyerName = ticket.BuyerName,
                        Quantity = participantList.Count(),
                        Fee = ticket.FinalFee,
                        Status = ticket.Status.ToString()
                    };

                    result.Add(item);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TicketListResponse>> GetListByTrainingID(Guid trainingID)
        {
            try
            {
                var ticketList = await unitOfWork.Ticket_List_ByTrainingID(trainingID);

                List<TicketListResponse> result = [];

                foreach (var ticket in ticketList)
                {
                    var participantList = await unitOfWork.Participant_List_ByTicketID(ticket.ID);

                    TicketListResponse item = new()
                    {
                        ID = ticket.ID,
                        TrainingID = ticket.TrainingID,
                        BuyerName = ticket.BuyerName,
                        Quantity = participantList.Count(),
                        Fee = ticket.FinalFee,
                        Status = ticket.Status.ToString()
                    };

                    result.Add(item);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TicketDetailResponse> GetDetail(Guid ticketID)
        {
            try
            {
                Ticket ticket = await unitOfWork.Ticket_ByID(ticketID);

                TicketDetailResponse result = new()
                {
                    TrainingID = ticket.TrainingID,
                    TrainingDiscountCodeID = ticket.TrainingDiscountCodeID,
                    TrainingDiscountGroupID = ticket.TrainingDiscountGroupID,
                    BuyerName = ticket.BuyerName,
                    BuyerType = ticket.BuyerType.ToString(),
                    Quantity = 0,
                    BaseFee = 0,
                    DiscountedFee = 0,
                    DiscountDescription = "",
                    TotalFee = ticket.TotalFee,
                    Status = ticket.Status.ToString()
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Add(TicketAddRequest ticketInsertInput, string user)
        {
            try
            {
                TicketPriceRequest ticketPriceRequest = new TicketPriceRequest()
                {
                    TrainingID = ticketInsertInput.TrainingID,
                    ticketCountList = ticketInsertInput.ticketCountList,
                    DiscountCode = ticketInsertInput.DiscountCode,
                };

                var price = await CalculatePrice(ticketPriceRequest);

                Ticket ticket = new()
                {
                    TrainingID = ticketInsertInput.TrainingID,
                    BuyerName = ticketInsertInput.BuyerName,
                    BuyerType = Domain.Enum.BuyerTypeEnum.INDIVIDUAL,
                    TotalFee = price.TotalFee,
                    DiscountCode = price.DiscountCode,
                    DiscountGroup = price.DiscountGroup,
                };

                List<Participant> participantList = ticketInsertInput.participantList.Select(x => new Participant
                {
                    TrainingFeeID = x.TrainingFeeID,
                    TicketID = ticket.ID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    IdentityNum = x.IdentityNum,
                    IdentityType = Domain.Enum.IdentityTypeEnum.NRIC

                }).ToList();

                await unitOfWork.Ticket_Add(ticket, participantList, user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Cancel(Guid ticketID, string user)
        {
            try
            {
                Ticket ticket = await unitOfWork.Ticket_ByID(ticketID);
                ticket.ChangeStatusToCancel();

                await unitOfWork.Ticket_Update_Status(ticketID, TicketStatusEnum.CANCELLED, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Paid(Guid ticketID, string user)
        {
            try
            {
                Ticket ticket = await unitOfWork.Ticket_ByID(ticketID);
                ticket.ChangeStatusToPaid();

                await unitOfWork.Ticket_Update_Status(ticketID, TicketStatusEnum.PAID, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TicketPriceResponse> CalculatePrice(TicketPriceRequest ticketPriceRequest)
        {
            try
            {
                TicketPriceResponse ticketPriceResponse = new()
                {
                    DiscountCode = 0,
                    DiscountGroup = 0,
                    FinalFee = 0,
                    TotalFee = 0

                };

                Training training = await unitOfWork.Training_ByID(ticketPriceRequest.TrainingID);
                List<TrainingFee> trainingFeeList = await unitOfWork.TrainingFee_List_ByTrainingID(ticketPriceRequest.TrainingID);
                int quantity = ticketPriceRequest.ticketCountList.Sum(x => x.Count);

                foreach (var ticket in ticketPriceRequest.ticketCountList)
                {
                    var fee = trainingFeeList.Where(x => x.ID == ticket.TrainingFeeID).FirstOrDefault()?.Fee ?? throw new Exception("Fee not found");
                    ticketPriceResponse.TotalFee += (fee * ticket.Count);
                }

                ticketPriceResponse.DiscountGroup = await CalculateDiscountGroup(ticketPriceRequest.TrainingID, ticketPriceResponse.TotalFee, quantity);

                if (ticketPriceResponse.DiscountGroup > ticketPriceResponse.TotalFee)
                {
                    ticketPriceResponse.DiscountGroup = ticketPriceResponse.TotalFee;
                }

                if (ticketPriceRequest.DiscountCode != null)
                {
                    ticketPriceResponse.DiscountCode = await CalculateDiscountCode(ticketPriceRequest.TrainingID, ticketPriceResponse.TotalFee, ticketPriceResponse.DiscountGroup, ticketPriceRequest.DiscountCode);
                }

                if (ticketPriceResponse.DiscountCode > ticketPriceResponse.TotalFee - ticketPriceResponse.DiscountGroup)
                {
                    ticketPriceResponse.DiscountCode = ticketPriceResponse.TotalFee - ticketPriceResponse.DiscountGroup;
                }

                ticketPriceResponse.FinalFee = ticketPriceResponse.TotalFee - ticketPriceResponse.DiscountGroup - ticketPriceResponse.DiscountCode;

                return ticketPriceResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<decimal> CalculateDiscountGroup(Guid trainingID, decimal baseFee, int quantity)
        {
            try
            {
                var trainingDiscountGroupList = await unitOfWork.TrainingDiscountGroup_List_ByTrainingID(trainingID);

                var trainingDiscountGroup = trainingDiscountGroupList.FirstOrDefault(x => x.MinParticipant <= quantity && x.MaxParticipant >= quantity);

                if (trainingDiscountGroup == null)
                {
                    return 0;
                }

                return trainingDiscountGroup.CalculateDiscount(baseFee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<decimal> CalculateDiscountCode(Guid trainingID, decimal baseFee, decimal groupDiscountFee, string discountCode)
        {
            try
            {
                var trainingDiscountCodeList = await unitOfWork.TrainingDiscountCode_List_ByTrainingID(trainingID);
                var trainingDiscountCode = trainingDiscountCodeList.FirstOrDefault(x => x.Code == discountCode);

                if (trainingDiscountCode == null)
                {
                    return 0;
                }

                return trainingDiscountCode.CalculateDiscount(baseFee, groupDiscountFee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
