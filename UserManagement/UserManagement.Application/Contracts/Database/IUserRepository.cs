namespace UserManagement.Application.Contracts.Database
{
    /// <summary>
    /// Utilizamos esta interfaz para aplicar particularidades de la clase User
    /// </summary>
    public interface IUserRepository
    {
        Task<bool> DisableUser(Guid Id);
        Task<bool> EnableUser(Guid Id);
    }
}
