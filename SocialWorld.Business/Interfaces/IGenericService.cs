using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.Interfaces
{
    public interface IGenericService<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> FindByIdAsync(int id);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
