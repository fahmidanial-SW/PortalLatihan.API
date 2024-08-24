using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class RefZoneRepository(PortalLatihanDBContext context) : BaseRepository<RefZone>(context), IRefZoneRepository
    { 
    }
}

