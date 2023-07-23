using System.Linq.Expressions;
using UserManagement.Domain.DTO;
using UserManagement.Domain.Entities.Base;

namespace UserManagement.Application.Contracts.Base
{
    public interface IGet<T> where T : EntityBase
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Paginate? paginate = null);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Paginate? paginate = null);
        Task<int> GetTotal(Expression<Func<T, bool>>? predicate = null);
    }
}
