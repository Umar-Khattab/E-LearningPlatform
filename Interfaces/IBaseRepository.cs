using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningPlatform.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        T Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T Update(T entity);
        int Count();
        Task<int> CountSpecificAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip);
    }
}
