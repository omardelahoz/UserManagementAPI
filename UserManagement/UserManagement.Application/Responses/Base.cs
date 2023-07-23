namespace UserManagement.Application.Responses
{
    public class Base
    {
        public string? Message { get; set; }
        public bool Result { get; set; }
        public int Status { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
