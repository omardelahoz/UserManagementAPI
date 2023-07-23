using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Contracts.Database;
using UserManagement.Infrastructure.Database;

namespace UserManagement.Infrastructure.Managers.Database
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementContext _context;

        public UserRepository(UserManagementContext context)
        {
            _context = context;
        }

        public async Task<bool> DisableUser(Guid Id)
        {
            await _context.Users
                .Where(u => u.Id == Id)
                .ExecuteUpdateAsync(a => a.SetProperty(i => i.IsActive, false));

            return true;
        }

        public async Task<bool> EnableUser(Guid Id)
        {
            await _context.Users
                .Where(u => u.Id == Id)
                .ExecuteUpdateAsync(a => a.SetProperty(i => i.IsActive, true));

            return true;
        }
    }
}
