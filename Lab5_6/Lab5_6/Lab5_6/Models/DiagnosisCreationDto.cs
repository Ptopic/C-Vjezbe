using System.ComponentModel.DataAnnotations;

namespace Lab5_6.Models
{
    public class DiagnosisCreationDto
    {
        [Required(ErrorMessage = "Diagnosis title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
