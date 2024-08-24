using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class StaffRepository(PortalLatihanDBContext context) : BaseRepository<Staff>(context), IStaffRepository
    {
        private readonly PortalLatihanDBContext context = context;
        public async Task<Staff> GetByUsername(string username)
        {
            return await context.STAFF.FirstOrDefaultAsync(x => x.Name == username) ?? throw new Exception("Username and Password is Invalid");
        }
    }
}
