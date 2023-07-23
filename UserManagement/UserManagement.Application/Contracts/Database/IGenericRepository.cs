using UserManagement.Application.Contracts.Base;
using UserManagement.Domain.Entities.Base;

namespace UserManagement.Application.Contracts.Database
{
    public interface IGenericRepository<T> : IAdd<T>, IDelete<T>, IGet<T>, IUpdate<T> where T : EntityBase
    {
    }
}
