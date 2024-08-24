using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;
using PortalLatihan.Infrastructure.Data.Repositories;

namespace PortalLatihan.Infrastructure.Data
{
    public class UnitOfWork(PortalLatihanDBContext context,
        IParticipantRepository participantRepository,
        IRefRegionRepository refRegionRepository,
        IRefZoneRepository refZoneRepository,
        ITicketRepository ticketRepository,
        ITicketStatusHistoryRepository ticketStatusHistoryRepository,
        ITrainingRepository trainingRepository,
        ITrainingFeeRepository trainingFeeRepository,
        ITrainingDiscountCodeRepository trainingDiscountCodeRepository,
        ITrainingDiscountGroupRepository trainingDiscountGroupRepository,
        ITrainingStatusHistoryRepository trainingStatusHistoryRepository,
        IStaffRepository staffRepository
        ) : IUnitOfWork
    {
        private bool disposed = false;

        #region Participant
        public async Task Participant_Add(Participant participant, string user)
        {
            try
            {
                participant.CreatedTimeStamp(user);
                participant.Validate();
                _ = await ticketRepository.GetByID(participant.TicketID);
                _ = await trainingFeeRepository.GetByID(participant.TrainingFeeID);

                await participantRepository.Add(participant, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Participant_Update(Participant participant, string user)
        {
            try
            {
                participant.ModifiedTimeStamp(user);
                participant.Validate();
                _ = await ticketRepository.GetByID(participant.TicketID);
                _ = await trainingFeeRepository.GetByID(participant.TrainingFeeID);

                await participantRepository.Update(participant.ID, participant, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Participant>> Participant_List()
        {
            try
            {
                return await participantRepository.GetListAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Participant> Participant_ByID(Guid ID)
        {
            try
            {
                return await participantRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Participant>> Participant_List_ByTrainingID(Guid trainingID)
        {
            try
            {
                var tickets = await ticketRepository.GetListByTrainingID(trainingID);

                List<Participant> participants = [];

                foreach (var ticket in tickets)
                {
                    participantRepository = new ParticipantRepository(context);
                    var participant = await participantRepository.GetListByTicketID(ticket.ID);
                    participants.AddRange(participant);
                }

                return participants;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<List<Participant>> Participant_List_ByParticipatnID(Guid ID)
        //{
        //    try
        //    {
        //        var tickets = await ticketRepository.GetParticipantByParticipantID(ID);

        //        List<Participant> participants = [];

        //        foreach (var ticket in tickets)
        //        {
        //            participantRepository = new ParticipantRepository(context);
        //            var participant = await participantRepository.GetListByTicketID(ticket.ID);
        //            participants.AddRange(participant);
        //        }

        //        return participants;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<List<Participant>> Participant_List_ByTicketID(Guid ticketID)
        {
            try
            {
                return await participantRepository.GetListByTicketID(ticketID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region RefRegion

        public async Task<List<RefRegion>> RefRegion_List()
        {
            try
            {
                return await refRegionRepository.GetListAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RefRegion> RefRegion_ByID(Guid ID)
        {
            try
            {
                return await refRegionRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RefRegion>> RefRegion_List_ByZoneID(Guid zoneID)
        {
            try
            {
                return await refRegionRepository.GetListByZoneID(zoneID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RefRegion_Add(RefRegion refRegion, string user)
        {
            try
            {
                refRegion.CreatedTimeStamp(user);
                refRegion.Validate();

                _ = refZoneRepository.GetByID(refRegion.ZoneID);

                await refRegionRepository.Add(refRegion, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RefRegion_Update(RefRegion refRegion, string user)
        {
            try
            {
                refRegion.ModifiedTimeStamp(user);
                refRegion.Validate();

                _ = refZoneRepository.GetByID(refRegion.ZoneID);

                await refRegionRepository.Update(refRegion.ID, refRegion, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region RefZone
        public async Task<List<RefZone>> RefZone_List()
        {
            try
            {
                return await refZoneRepository.GetListAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RefZone> RefZone_ByID(Guid ID)
        {
            try
            {
                return await refZoneRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RefZone_Add(RefZone refZone, string user)
        {
            try
            {
                refZone.CreatedTimeStamp(user);
                refZone.Validate();

                await refZoneRepository.Add(refZone, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RefZone_Update(RefZone refZone, string user)
        {
            try
            {
                refZone.ModifiedTimeStamp(user);
                refZone.Validate();

                refZoneRepository = new RefZoneRepository(context);
                await refZoneRepository.Update(refZone.ID, refZone, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Ticket
        public async Task Ticket_Add(Ticket ticket, List<Participant> participantList, string user)
        {
            try
            {
                ticket.CreatedTimeStamp(user);
                ticket.Validate();

                _ = await trainingRepository.GetByID(ticket.TrainingID);
                if (ticket.TrainingDiscountCodeID != null) _ = await trainingDiscountCodeRepository.GetByID(ticket.TrainingDiscountCodeID.Value);
                if (ticket.TrainingDiscountGroupID != null) _ = await trainingDiscountGroupRepository.GetByID(ticket.TrainingDiscountGroupID.Value);

                await ticketRepository.Add(ticket, user);

                TicketStatusHistory ticketStatusHistory = new()
                {
                    TicketID = ticket.ID,
                    Status = ticket.Status,
                    Remarks = ""
                };

                ticketStatusHistory.CreatedTimeStamp(user);

                ticketStatusHistoryRepository = new TicketStatusHistoryRepository(context);
                await ticketStatusHistoryRepository.Add(ticketStatusHistory, user);

                foreach (var participant in participantList)
                {
                    participant.TicketID = ticket.ID;
                    participant.CreatedTimeStamp(user);
                    participant.Validate();

                    await participantRepository.Add(participant, user);
                }

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Ticket_Update(Ticket ticket, string user)
        {
            try
            {
                ticket.ModifiedTimeStamp(user);
                ticket.Validate();

                _ = await trainingRepository.GetByID(ticket.TrainingID);
                if (ticket.TrainingDiscountCodeID != null) _ = await trainingDiscountCodeRepository.GetByID(ticket.TrainingDiscountCodeID.Value);
                if (ticket.TrainingDiscountGroupID != null) _ = await trainingDiscountGroupRepository.GetByID(ticket.TrainingDiscountGroupID.Value);

                await ticketRepository.Update(ticket.ID, ticket, user);
                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Ticket_Update_Status(Guid ID, TicketStatusEnum status, string user)
        {
            try
            {
                var ticket = await ticketRepository.GetByID(ID);

                if (ticket.Status == TicketStatusEnum.CANCELLED)
                {
                    ticket.ChangeStatusToCancel();
                }
                else if (ticket.Status == TicketStatusEnum.PAID)
                {
                    ticket.ChangeStatusToPaid();
                }

                await Ticket_Update(ticket, user);

                TicketStatusHistory ticketStatusHistory = new()
                {
                    TicketID = ticket.ID,
                    Status = ticket.Status,
                    Remarks = ""
                };

                ticketStatusHistory.CreatedTimeStamp(user);

                await ticketStatusHistoryRepository.Add(ticketStatusHistory, user);

                var participanList = await Participant_List_ByTicketID(ticket.ID);
                foreach (var participant in participanList)
                {
                    if (ticket.Status == TicketStatusEnum.CANCELLED)
                    {
                        participant.ChangeStatusToCancelled();
                    }
                    else if (ticket.Status == TicketStatusEnum.PAID)
                    {
                        participant.ChangeStatusToPaid();
                    }

                    participant.ModifiedTimeStamp(user);
                    await participantRepository.Update(participant.ID, participant, user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ticket>> Ticket_List()
        {
            try
            {
                return await ticketRepository.GetListAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ticket> Ticket_ByID(Guid ID)
        {
            try
            {
                return await ticketRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ticket>> Ticket_List_ByTrainingID(Guid trainingID)
        {
            try
            {
                return await ticketRepository.GetListByTrainingID(trainingID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ticket>> Ticket_List_ByStatus(TicketStatusEnum status)
        {
            try
            {
                return await ticketRepository.GetByStatus(status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region TicketStatusHistory

        public async Task<List<TicketStatusHistory>> TicketStatusHistory_List_ByTicketID(Guid ticketID)
        {
            try
            {
                return await ticketStatusHistoryRepository.GetListByTicketID(ticketID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region TrainingDiscountCode
        private async Task TrainingDiscountCode_Add(TrainingDiscountCode trainingDiscountCode, string user)
        {
            try
            {
                trainingDiscountCode.CreatedTimeStamp(user);
                trainingDiscountCode.Validate();

                await trainingDiscountCodeRepository.Add(trainingDiscountCode, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task TrainingDiscountCode_Update(TrainingDiscountCode trainingDiscountCode, string user)
        {
            try
            {
                trainingDiscountCode.ModifiedTimeStamp(user);
                trainingDiscountCode.Validate();

                _ = await Training_ByID(trainingDiscountCode.TrainingID);

                await trainingDiscountCodeRepository.Update(trainingDiscountCode.ID, trainingDiscountCode, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingDiscountCode>> TrainingDiscountCode_List()
        {
            try
            {
                return await trainingDiscountCodeRepository.GetListAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingDiscountCode> TrainingDiscountCode_ByID(Guid ID)
        {
            try
            {
                return await trainingDiscountCodeRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingDiscountCode>> TrainingDiscountCode_List_ByTrainingID(Guid trainingID)
        {
            try
            {
                return await trainingDiscountCodeRepository.GetListByTrainingID(trainingID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region TrainingDiscountGroup
        private async Task TrainingDiscountGroup_Add(TrainingDiscountGroup trainingDiscountGroup, string user)
        {
            try
            {
                trainingDiscountGroup.CreatedTimeStamp(user);
                trainingDiscountGroup.Validate();

                trainingDiscountGroupRepository = new TrainingDiscountGroupRepository(context);
                await trainingDiscountGroupRepository.Add(trainingDiscountGroup, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task TrainingDiscountGroup_Update(TrainingDiscountGroup trainingDiscountGroup, string user)
        {
            try
            {
                trainingDiscountGroup.ModifiedTimeStamp(user);
                trainingDiscountGroup.Validate();

                _ = await trainingDiscountGroupRepository.GetByID(trainingDiscountGroup.TrainingID);

                trainingDiscountGroupRepository = new TrainingDiscountGroupRepository(context);
                await trainingDiscountGroupRepository.Update(trainingDiscountGroup.ID, trainingDiscountGroup, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingDiscountGroup>> TrainingDiscountGroup_List_ByTrainingID(Guid trainingID)
        {
            try
            {
                return await trainingDiscountGroupRepository.GetListByTrainingID(trainingID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingDiscountGroup> TrainingDiscountGroup_ByID(Guid ID)
        {
            try
            {
                return await trainingDiscountGroupRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Training
        public async Task Training_Add(Training training, List<TrainingFee> trainingFeeList, List<TrainingDiscountGroup>? trainingDiscountGroupList, List<TrainingDiscountCode>? trainingDiscountCodeList, string user)
        {
            try
            {
                training.CreatedTimeStamp(user);
                training.Validate();

                _ = await refZoneRepository.GetByID(training.ZoneID);
                _ = await refRegionRepository.GetByID(training.RegionID);

                await trainingRepository.Add(training, user);

                foreach (var trainingFee in trainingFeeList)
                    await TrainingFee_Add(trainingFee, user);

                if (trainingDiscountGroupList != null)
                {
                    foreach (var trainingDiscountGroup in trainingDiscountGroupList)
                        await TrainingDiscountGroup_Add(trainingDiscountGroup, user);
                }

                if (trainingDiscountCodeList != null)
                {
                    foreach (var trainingDiscountCode in trainingDiscountCodeList)
                        await TrainingDiscountCode_Add(trainingDiscountCode, user);
                }

                TrainingStatusHistory trainingStatusHistory = new()
                {
                    TrainingID = training.ID,
                    Status = training.Status,
                    Remarks = ""
                };

                trainingStatusHistory.CreatedTimeStamp(user);

                await trainingStatusHistoryRepository.Add(trainingStatusHistory, user);

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Training_Update(Training training, List<TrainingFee> trainingFeeList, List<TrainingDiscountGroup>? trainingDiscountGroupList, List<TrainingDiscountCode>? trainingDiscountCodeList, string user)
        {
            try
            {
                training.ModifiedTimeStamp(user);
                training.Validate();

                _ = await refZoneRepository.GetByID(training.ZoneID);
                _ = await refRegionRepository.GetByID(training.RegionID);

                await trainingRepository.Update(training.ID, training, user);

                await trainingFeeRepository.Delete_ByTrainingID(training.ID);
                await trainingDiscountCodeRepository.Delete_ByTrainingID(training.ID);
                await trainingDiscountGroupRepository.Delete_ByTrainingID(training.ID);

                foreach (var trainingFee in trainingFeeList)
                {
                    await TrainingFee_Add(trainingFee, user);
                }

                if (trainingDiscountGroupList != null)
                {
                    foreach (var trainingDiscountGroup in trainingDiscountGroupList)
                    {
                        await TrainingDiscountGroup_Add(trainingDiscountGroup, user);
                    }
                }

                if (trainingDiscountCodeList != null)
                {
                    foreach (var trainingDiscountCode in trainingDiscountCodeList)
                    {
                        await TrainingDiscountCode_Add(trainingDiscountCode, user);
                    }
                }

                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task Training_Process(Training training, string remark, string user)
        {
            await trainingRepository.Update(training.ID, training, user);

            TrainingStatusHistory trainingStatusHistory = new()
            {
                TrainingID = training.ID,
                Status = training.Status,
                Remarks = remark
            };

            trainingStatusHistory.CreatedTimeStamp(user);

            await trainingStatusHistoryRepository.Add(trainingStatusHistory, user);
            await Commit();
        }

        public async Task<List<Training>> Training_List()
        {
            try
            {
                return await trainingRepository.GetListAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Training>> Training_List_ByStatus(TrainingStatusEnum status)
        {
            try
            {
                return await trainingRepository.GetListByStatus(status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Training>> Training_List_ByUser(string user)
        {
            try
            {
                return await trainingRepository.GetListByUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Training>> Training_List_Available()
        {
            try
            {
                return await trainingRepository.GetListByAvailable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Training> Training_ByID(Guid ID)
        {
            try
            {
                return await trainingRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region TrainingFee

        private async Task TrainingFee_Add(TrainingFee trainingFee, string user)
        {
            try
            {
                trainingFee.CreatedTimeStamp(user);
                trainingFee.Validate();

                await trainingFeeRepository.Add(trainingFee, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingFee>> TrainingFee_List_ByTrainingID(Guid Training)
        {
            try
            {
                return await trainingFeeRepository.List_ByTrainingID(Training);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingFee> TrainingFee_ByID(Guid ID)
        {
            try
            {
                return await trainingFeeRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region TrainingStatusHistory
        public async Task<List<TrainingStatusHistory>> TrainingStatusHistory_List_ByTrainingID(Guid trainingID)
        {
            try
            {
                return await trainingStatusHistoryRepository.GetListByTrainingID(trainingID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Staff
        public async Task Staff_Add(Staff staff, string user)
        {
            try
            {
                staff.CreatedTimeStamp(user);
                staff.Validate();

                await staffRepository.Add(staff, user);
                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Staff_Update(Staff staff, string user)
        {
            try
            {
                staff.ModifiedTimeStamp(user);
                staff.Validate();

                await staffRepository.Update(staff.ID, staff, user);
                await Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Staff>> Staff_List()
        {
            try
            {
                return await staffRepository.GetListAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Staff> Staff_ByUsername(string username)
        {
            try
            {
                return await staffRepository.GetByUsername(username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }
    }
}
