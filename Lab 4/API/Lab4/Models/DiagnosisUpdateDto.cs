using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
	public class DiagnosisUpdateDto
	{
        [Required(ErrorMessage = "Diagnosis title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}

