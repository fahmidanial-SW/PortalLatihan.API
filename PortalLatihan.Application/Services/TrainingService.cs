using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;
using PortalLatihan.Domain.Extension;
using System.Data.Common;

namespace PortalLatihan.Application.Services
{
    public class TrainingService(IUnitOfWork unitOfWork
        ) : ITrainingService
    {
        public async Task<List<TrainingListResponse>> GetList()
        {
            try
            {
                var trainingList = await unitOfWork.Training_List();
                List<TrainingListResponse> result = [];

                foreach (var training in trainingList)
                {
                    List<TrainingFee> trainingFee = await unitOfWork.TrainingFee_List_ByTrainingID(training.ID);
                    RefZone refZone = await unitOfWork.RefZone_ByID(training.ZoneID);
                    RefRegion refRegion = await unitOfWork.RefRegion_ByID(training.RegionID);

                    string fee = "";

                    if (trainingFee.Count == 1)
                    {
                        fee = trainingFee[0].Fee.ToString();
                    }
                    else if (trainingFee.Count > 1)
                    {
                        fee = $"{trainingFee.Min(x => x.Fee)} - {trainingFee.Max(x => x.Fee)}";
                    }

                    TrainingListResponse trainingListResponse = new()
                    {
                        ID = training.ID,
                        ZoneName = refZone.Name,
                        RegionName = refRegion.Name,
                        Title = training.Title,
                        Description = training.Description,
                        DateRange = training.DurationInDays == 1
                          ? training.EventDate.ToString("dd/MM/yyyy")
                          : $"{training.EventDate:dd/MM/yyyy} - {training.EventDate.AddDays(training.DurationInDays - 1):dd/MM/yyyy}",
                        DurationInDays = training.DurationInDays,
                        Status = training.Status.ToString(),
                        Fee = fee,
                        ParticipantAttendedCount = 0,
                        ParticipantPaidCount = 0,
                        ParticipantRegisteredCount = 0,
                        TicketBookedCount = 0,
                        TicketPaidCount = 0
                    };


                    result.Add(trainingListResponse);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingListResponse>> GetListByStatus(string trainingStatus)
        {
            try
            {
                var trainingList = await unitOfWork.Training_List_ByStatus(trainingStatus.ToTrainingStatusEnum());
                List<TrainingListResponse> result = [];

                foreach (var training in trainingList)
                {
                    List<TrainingFee> trainingFee = await unitOfWork.TrainingFee_List_ByTrainingID(training.ID);
                    RefZone refZone = await unitOfWork.RefZone_ByID(training.ZoneID);
                    RefRegion refRegion = await unitOfWork.RefRegion_ByID(training.RegionID);

                    string fee = "";

                    if (trainingFee.Count == 1)
                    {
                        fee = trainingFee[0].Fee.ToString();
                    }
                    else if (trainingFee.Count > 1)
                    {
                        fee = $"{trainingFee.Min(x => x.Fee)} - {trainingFee.Max(x => x.Fee)}";
                    }

                    TrainingListResponse trainingListResponse = new()
                    {
                        ID = training.ID,
                        ZoneName = refZone.Name,
                        RegionName = refRegion.Name,
                        Title = training.Title,
                        Description = training.Description,
                        DateRange = training.DurationInDays == 1
                          ? training.EventDate.ToString("dd/MM/yyyy")
                          : $"{training.EventDate:dd/MM/yyyy} - {training.EventDate.AddDays(training.DurationInDays - 1):dd/MM/yyyy}",
                        DurationInDays = training.DurationInDays,
                        Status = training.Status.ToString(),
                        Fee = fee,
                        ParticipantAttendedCount = 0,
                        ParticipantPaidCount = 0,
                        ParticipantRegisteredCount = 0,
                        TicketBookedCount = 0,
                        TicketPaidCount = 0
                    };

                    result.Add(trainingListResponse);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingListResponse>> GetListByUser(string user)
        {
            try
            {
                var trainingList = await unitOfWork.Training_List_ByUser(user);
                List<TrainingListResponse> result = [];

                foreach (var training in trainingList)
                {
                    List<TrainingFee> trainingFee = await unitOfWork.TrainingFee_List_ByTrainingID(training.ID);
                    RefZone refZone = await unitOfWork.RefZone_ByID(training.ZoneID);
                    RefRegion refRegion = await unitOfWork.RefRegion_ByID(training.RegionID);

                    string fee = "";

                    if (trainingFee.Count == 1)
                    {
                        fee = trainingFee[0].Fee.ToString();
                    }
                    else if (trainingFee.Count > 1)
                    {
                        fee = $"{trainingFee.Min(x => x.Fee)} - {trainingFee.Max(x => x.Fee)}";
                    }

                    TrainingListResponse trainingListResponse = new()
                    {
                        ID = training.ID,
                        ZoneName = refZone.Name,
                        RegionName = refRegion.Name,
                        Title = training.Title,
                        Description = training.Description,
                        DateRange = training.DurationInDays == 1
                          ? training.EventDate.ToString("dd/MM/yyyy")
                          : $"{training.EventDate:dd/MM/yyyy} - {training.EventDate.AddDays(training.DurationInDays - 1):dd/MM/yyyy}",
                        DurationInDays = training.DurationInDays,
                        Status = training.Status.ToString(),
                        Fee = fee,
                        ParticipantAttendedCount = 0,
                        ParticipantPaidCount = 0,
                        ParticipantRegisteredCount = 0,
                        TicketBookedCount = 0,
                        TicketPaidCount = 0
                    };


                    result.Add(trainingListResponse);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingListResponse>> GetListAvailable()
        {
            try
            {
                var trainingList = await unitOfWork.Training_List_Available();
                List<TrainingListResponse> result = [];

                foreach (var training in trainingList)
                {
                    List<TrainingFee> trainingFee = await unitOfWork.TrainingFee_List_ByTrainingID(training.ID);
                    List<Participant> participantList = await unitOfWork.Participant_List_ByTrainingID(training.ID);
                    List<Ticket> ticketList = await unitOfWork.Ticket_List_ByTrainingID(training.ID);

                    RefZone refZone = await unitOfWork.RefZone_ByID(training.ZoneID);
                    RefRegion refRegion = await unitOfWork.RefRegion_ByID(training.RegionID);

                    string fee = "";

                    if (trainingFee.Count == 1)
                    {
                        fee = trainingFee[0].Fee.ToString();
                    }
                    else if (trainingFee.Count > 1)
                    {
                        fee = $"{trainingFee.Min(x => x.Fee)} - {trainingFee.Max(x => x.Fee)}";
                    }

                    TrainingListResponse trainingListResponse = new()
                    {
                        ID = training.ID,
                        ZoneName = refZone.Name,
                        RegionName = refRegion.Name,
                        Title = training.Title,
                        Description = training.Description,
                        DateRange = training.DurationInDays == 1
                          ? training.EventDate.ToString("dd/MM/yyyy")
                          : $"{training.EventDate:dd/MM/yyyy} - {training.EventDate.AddDays(training.DurationInDays - 1):dd/MM/yyyy}",
                        DurationInDays = training.DurationInDays,
                        Status = training.Status.ToString(),
                        Fee = fee,
                        ParticipantRegisteredCount = participantList.Count(),
                        ParticipantPaidCount = participantList.Where(x => x.Status == ParticipantStatusEnum.PAID).Count(),
                        ParticipantAttendedCount = participantList.Where(x => x.IsAttended).Count(),
                        TicketBookedCount = ticketList.Count(),
                        TicketPaidCount = ticketList.Where(x => x.Status == TicketStatusEnum.PAID).Count()
                    };

                    result.Add(trainingListResponse);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingDetailResponse> GetDetail(Guid id)
        {
            try
            {

                Training training = await unitOfWork.Training_ByID(id);
                RefZone refZone = await unitOfWork.RefZone_ByID(training.ZoneID);
                RefRegion refRegion = await unitOfWork.RefRegion_ByID(training.RegionID);

                TrainingDetailResponse result = new()
                {
                    ZoneID = training.ZoneID,
                    RegionID = training.RegionID,
                    ZoneName = refZone.Name,
                    RegionName = refRegion.Name,
                    Title = training.Title,
                    Description = training.Description,
                    Location = training.Location,
                    EventDate = training.EventDate,
                    DurationInDays = training.DurationInDays,
                    MinParticipant = training.MinParticipant,
                    MaxParticipant = training.MaxParticipant,
                    Status = training.Status.ToString()
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Add(TrainingAddRequest trainingDetailInput, string user)
        {
            try
            {
                Training training = new()
                {
                    ZoneID = trainingDetailInput.ZoneID,
                    RegionID = trainingDetailInput.RegionID,
                    Title = trainingDetailInput.Title,
                    Description = trainingDetailInput.Description,
                    EventDate = trainingDetailInput.EventDate,
                    Location = trainingDetailInput.Location,
                    DurationInDays = trainingDetailInput.DurationInDays,
                    MinParticipant = trainingDetailInput.MinParticipant,
                    MaxParticipant = trainingDetailInput.MaxParticipant,
                };

                List<TrainingFee> feeList = trainingDetailInput.FeeList.Select(x => new TrainingFee
                {
                    TrainingID = training.ID,
                    Fee = x.Fee,
                    ParticipantType = x.ParticipantType
                }).ToList();

                List<TrainingDiscountGroup>? discountGroupList = trainingDetailInput.DiscountGroupList?.Select(x => new TrainingDiscountGroup
                {
                    TrainingID = training.ID,
                    DiscountType = x.DiscountType.ToDiscountTypeEnum(),
                    MinParticipant = x.MinParticipant,
                    MaxParticipant = x.MaxParticipant,
                    Discount = x.Discount
                }).ToList();

                List<TrainingDiscountCode>? discountCodeList = trainingDetailInput.DiscountCodeList?.Select(x => new TrainingDiscountCode
                {
                    TrainingID = training.ID,
                    DiscountType = x.DiscountType.ToDiscountTypeEnum(),
                    Code = x.Code,
                    Discount = x.Discount,
                    Quota = x.Quota,
                    IsUsableWithGroupDiscount = x.IsUsableWithGroupDiscount
                }).ToList();

                await unitOfWork.Training_Add(training, feeList, discountGroupList, discountCodeList, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(TrainingUpdateRequest trainingUpdateInput, string user)
        {
            try
            {
                Training training = await unitOfWork.Training_ByID(trainingUpdateInput.ID);
                training.ZoneID = trainingUpdateInput.ZoneID;
                training.RegionID = trainingUpdateInput.RegionID;
                training.Title = trainingUpdateInput.Title;
                training.Description = trainingUpdateInput.Description;
                training.EventDate = trainingUpdateInput.EventDate;
                training.Location = trainingUpdateInput.Location;
                training.DurationInDays = trainingUpdateInput.DurationInDays;
                training.MinParticipant = trainingUpdateInput.MinParticipant;
                training.MaxParticipant = trainingUpdateInput.MaxParticipant;

                List<TrainingFee> trainingFeeList = trainingUpdateInput.FeeList.Select(x => new TrainingFee
                {
                    TrainingID = training.ID,
                    Fee = x.Fee,
                    ParticipantType = x.ParticipantType
                }).ToList();

                List<TrainingDiscountGroup>? trainingDiscountGroupList = trainingUpdateInput.DiscountGroupList?.Select(x => new TrainingDiscountGroup
                {
                    TrainingID = training.ID,
                    DiscountType = x.DiscountType.ToDiscountTypeEnum(),
                    MinParticipant = x.MinParticipant,
                    MaxParticipant = x.MaxParticipant,
                    Discount = x.Discount
                }).ToList();

                List<TrainingDiscountCode>? trainingDiscountCodeList = trainingUpdateInput.DiscountCodeList?.Select(x => new TrainingDiscountCode
                {
                    TrainingID = training.ID,
                    DiscountType = x.DiscountType.ToDiscountTypeEnum(),
                    Code = x.Code,
                    Discount = x.Discount,
                    Quota = x.Quota,
                    IsUsableWithGroupDiscount = x.IsUsableWithGroupDiscount
                }).ToList();

                if (training.Status == TrainingStatusEnum.APPROVED)
                {
                    throw new Exception("Training has been approved and cannot be updated.");
                }
                else if (training.Status == TrainingStatusEnum.REJECTED)
                {
                    training.ReSubmit();
                    await unitOfWork.Training_Update(training, trainingFeeList, trainingDiscountGroupList, trainingDiscountCodeList, user);
                    await unitOfWork.Training_Process(training, "Resubmit", user);
                }
                else
                {
                    await unitOfWork.Training_Update(training, trainingFeeList, trainingDiscountGroupList, trainingDiscountCodeList, user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(Guid id, string user)
        {
            try
            {
                Training training = await unitOfWork.Training_ByID(id);
                training.Delete();
                await unitOfWork.Training_Process(training, "Deleted", user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Approve(Guid id, string remark, string user)
        {
            try
            {
                Training training = await unitOfWork.Training_ByID(id);
                training.Approve();
                await unitOfWork.Training_Process(training, remark, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Reject(Guid id, string remark, string user)
        {
            try
            {
                Training training = await unitOfWork.Training_ByID(id);
                training.Reject();
                await unitOfWork.Training_Process(training, remark, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
