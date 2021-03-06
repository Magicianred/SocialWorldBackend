using Microsoft.EntityFrameworkCore;
using SocialWorld.DataAccess.Concrete.EntityFrameworkCore.Context;
using SocialWorld.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public async Task AddAsync(T entity)
        {
            using var context = new SocialWorldDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            using var context = new SocialWorldDbContext();
            return await context.FindAsync<T>(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new SocialWorldDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new SocialWorldDbContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new SocialWorldDbContext();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(T entity)
        {
            using var context = new SocialWorldDbContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new SocialWorldDbContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
