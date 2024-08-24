using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class BaseRepository<T>(PortalLatihanDBContext context) : IBaseRepository<T> where T : class
    {
        public async Task<List<T>> GetListAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(Guid ID)
        {
            return await context.Set<T>().FindAsync(ID) ?? throw new Exception($"{typeof(T).Name} not found");
        }

        public async Task Add(T input, string user)
        {
            await context.AddAsync(input);
        }

        public async Task Update(Guid ID, T input, string user)
        {
            _ = await context.Set<T>().FindAsync(ID) ?? throw new Exception($"{typeof(T).Name} with ID {ID} not found");
            context.Update(input);
        }
    }

}
