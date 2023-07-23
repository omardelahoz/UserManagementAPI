namespace UserManagement.Application.Exceptions
{
    public class UserManagementException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
        public UserManagementException(string message) : base(message)
        {

        }
        public UserManagementException(IDictionary<string, string[]> errors) : this("Se presentaron uno o mas errores de validación")
        {
            Errors = errors;
        }
    }
}
