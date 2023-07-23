namespace UserManagement.Domain.DTO
{
    public class Paginate
    {
        public int PageIndex { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public bool Ascendent { get; set; }
        public string? OrderBy { get; set; } = string.Empty;

        public Paginate()
        {
            PageSize = 10;
            PageIndex = 1;
            Ascendent = true;
        }
    }
}
