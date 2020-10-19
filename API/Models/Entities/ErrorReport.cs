namespace API.Models.Entities
{
    public class ErrorReport
    {
        public int ErrorReportId { get; set; }
        
        public User UserSource { get; set; }
        public string Error { get; set; }
        public string Type { get; set; }
        public string Contents { get; set; }

    }
}