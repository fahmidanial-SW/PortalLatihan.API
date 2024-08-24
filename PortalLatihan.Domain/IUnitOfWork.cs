using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;
using PortalLatihan.Domain.Repositories;

namespace PortalLatihan.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task Participant_Add(Participant participant, string user);
        Task<Participant> Participant_ByID(Guid ID);
        Task<List<Participant>> Participant_List_ByTicketID(Guid ticketID);
        Task<List<Participant>> Participant_List_ByTrainingID(Guid trainingID);
        //Task<List<Participant>> Participant_List_ByParticipantID(Guid ID);
        Task<List<Participant>> Participant_List();
        Task Participant_Update(Participant participant, string user);
        Task RefRegion_Add(RefRegion refRegion, string user);
        Task<RefRegion> RefRegion_ByID(Guid ID);
        Task<List<RefRegion>> RefRegion_List_ByZoneID(Guid zoneID);
        Task<List<RefRegion>> RefRegion_List();
        Task RefRegion_Update(RefRegion refRegion, string user);
        Task RefZone_Add(RefZone refZone, string user);
        Task<RefZone> RefZone_ByID(Guid ID);
        Task<List<RefZone>> RefZone_List();
        Task RefZone_Update(RefZone refZone, string user);
        Task<List<TicketStatusHistory>> TicketStatusHistory_List_ByTicketID(Guid ticketID);
        Task Ticket_Add(Ticket ticket, List<Participant> participantList, string user);
        Task<Ticket> Ticket_ByID(Guid ID);
        Task<List<Ticket>> Ticket_List_ByStatus(TicketStatusEnum status);
        Task<List<Ticket>> Ticket_List_ByTrainingID(Guid trainingID);
        Task<List<Ticket>> Ticket_List();
        Task Ticket_Update(Ticket ticket, string user);
        Task<TrainingDiscountCode> TrainingDiscountCode_ByID(Guid ID);
        Task<List<TrainingDiscountCode>> TrainingDiscountCode_List();
        Task<List<TrainingDiscountCode>> TrainingDiscountCode_List_ByTrainingID(Guid trainingID);
        Task<List<TrainingDiscountGroup>> TrainingDiscountGroup_List_ByTrainingID(Guid trainingID);
        Task<TrainingDiscountGroup> TrainingDiscountGroup_ByID(Guid ID);
        Task<List<TrainingStatusHistory>> TrainingStatusHistory_List_ByTrainingID(Guid trainingID);
        Task Training_Add(Training training, List<TrainingFee> trainingFee, List<TrainingDiscountGroup>? trainingDiscountGroup, List<TrainingDiscountCode>? trainingDiscountCode, string user);
        Task<Training> Training_ByID(Guid ID);
        Task<List<Training>> Training_List();
        Task<List<TrainingFee>> TrainingFee_List_ByTrainingID(Guid Training);
        Task<TrainingFee> TrainingFee_ByID(Guid ID);
        Task Staff_Add(Staff staff, string user);
        Task<Staff> Staff_ByUsername(string username);
        Task<List<Staff>> Staff_List();
        Task Staff_Update(Staff staff, string user);
        Task Training_Update(Training training, List<TrainingFee> trainingFeeList, List<TrainingDiscountGroup>? trainingDiscountGroupList, List<TrainingDiscountCode>? trainingDiscountCodeList, string user);
        Task Training_Process(Training training, string remark, string user);
        Task<List<Training>> Training_List_ByStatus(TrainingStatusEnum status);
        Task<List<Training>> Training_List_ByUser(string user);
        Task<List<Training>> Training_List_Available();
        Task Ticket_Update_Status(Guid ID, TicketStatusEnum status, string user);
    }
}
