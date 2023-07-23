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
            PageSize = int.MaxValue;
            PageIndex = 0;
            Ascendent = true;
        }
    }
}
