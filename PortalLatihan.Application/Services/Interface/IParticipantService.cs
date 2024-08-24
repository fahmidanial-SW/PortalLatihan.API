using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface IParticipantService
    {
        Task Add(ParticipanAddRequest participanInsertRequest, string user);
        Task Delete(Guid id, string user);  
        Task<List<ParticipantListResponse>> GetListByTicketID(Guid ticketID);
        Task<List<ParticipantListResponse>> GetListByTrainingID(Guid trainingID);
        //Task<List<ParticipantListResponse>> GetParticipantByParticipantID(Guid ID);
        Task Update(ParticipantUpdateRequest participantUpdateInput, string user);
        Task UpdateAttendance(ParticipantUpdateAttendanceRequest participantUpdateAttendanceInput, string user);
    }
}
