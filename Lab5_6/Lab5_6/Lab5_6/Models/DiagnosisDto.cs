namespace Lab5_6.Models
{
    public class DiagnosisDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
