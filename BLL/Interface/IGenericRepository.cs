using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    
        public interface IGenericRepository<T> where T : BaseModel
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task AddAsync(T entity);
            void Update(T entity);
            void Delete(T entity);
            Task SaveAsync();
        }
    }

