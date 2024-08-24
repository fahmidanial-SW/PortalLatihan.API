using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Extension;

namespace PortalLatihan.Application.Services
{
    public class ParticipantService(IUnitOfWork unitOfWork) : IParticipantService
    {
        public async Task<List<ParticipantListResponse>> GetListByTicketID(Guid ticketID)
        {
            try
            {
                var participantList = await unitOfWork.Participant_List_ByTicketID(ticketID);
                List<ParticipantListResponse> result = [];

                foreach (var participant in participantList)
                {
                    ParticipantListResponse item = new()
                    {
                        ID = participant.ID,
                        TicketID = participant.TicketID,
                        Name = participant.Name,
                        IdentityNumber = participant.IdentityNum,
                        PhoneNumber = participant.Phone,
                        Email = participant.Email,
                        Status = participant.Status.ToString(),
                        IsAttended = participant.IsAttended
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ParticipantListResponse>> GetListByTrainingID(Guid trainingID)
        {
            try
            {
                var participantList = await unitOfWork.Participant_List_ByTrainingID(trainingID);
                List<ParticipantListResponse> result = [];

                foreach (var participant in participantList)
                {
                    ParticipantListResponse item = new()
                    {
                        ID = participant.ID,
                        TicketID = participant.TicketID,
                        Name = participant.Name,
                        IdentityNumber = participant.IdentityNum,
                        PhoneNumber = participant.Phone,
                        Email = participant.Email,
                        Status = participant.Status.ToString(),
                        IsAttended = participant.IsAttended
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

        //public async Task<List<ParticipantListResponse>> GetParticipantByParticipantID(Guid ID)
        //{
        //    try
        //    {
        //        var participantList = await unitOfWork.Participant_List_ByParticipantID(ID);
        //        List<ParticipantListResponse> result = [];

        //        foreach (var participant in participantList)
        //        {
        //            ParticipantListResponse item = new()
        //            {
        //                ID = participant.ID,
        //                TicketID = participant.TicketID,
        //                Name = participant.Name,
        //                IdentityNumber = participant.IdentityNum,
        //                PhoneNumber = participant.Phone,
        //                Email = participant.Email,
        //                Status = participant.Status.ToString(),
        //                IsAttended = participant.IsAttended
        //            };

        //            result.Add(item);
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task Add(ParticipanAddRequest participanInsertRequest,string user)
        {
            try
            {
                Participant participant = new()
                {
                    TrainingFeeID = participanInsertRequest.TrainingFeeID,
                    TicketID = participanInsertRequest.TicketID,
                    Name = participanInsertRequest.Name,
                    IdentityType = participanInsertRequest.IdentityType.ToIdentityTypeEnum(),
                    IdentityNum = participanInsertRequest.IdentityNum,
                    Email = participanInsertRequest.Email,
                    Phone = participanInsertRequest.Phone,
                };

                await unitOfWork.Participant_Add(participant, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(ParticipantUpdateRequest participantUpdateInput, string user)
        {
            try
            {
                Participant participant = await unitOfWork.Participant_ByID(participantUpdateInput.ID);
                participant.Name = participantUpdateInput.Name;
                participant.IdentityType = participantUpdateInput.IdentityType.ToIdentityTypeEnum();
                participant.IdentityNum = participantUpdateInput.IdentityNum;
                participant.Email = participantUpdateInput.Email;
                participant.Phone = participantUpdateInput.Phone;
                

                await unitOfWork.Participant_Update(participant, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAttendance(ParticipantUpdateAttendanceRequest participantUpdateAttendanceInput, string user)
        {
            try
            {
                Participant participant = await unitOfWork.Participant_ByID(participantUpdateAttendanceInput.ID);
                

                if (participantUpdateAttendanceInput.IsAttended)
                {
                    participant.ChangeStatusToAttended();
                }
                else
                {
                    participant.ChangeStatusToAbsent();
                }

                await unitOfWork.Participant_Update(participant, user);
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
                Participant participant = await unitOfWork.Participant_ByID(id);
                participant.Delete();

                await unitOfWork.Participant_Update(participant, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
