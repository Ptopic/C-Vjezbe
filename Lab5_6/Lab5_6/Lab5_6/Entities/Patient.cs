using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Lab5_6.Entities.Enums;

namespace Lab5_6.Entities
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(11)]
        public string? PatientOib { get; set; }

        [Required]
        [StringLength(9)]
        public string? PatientMbo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [ForeignKey("DiagnosisId")]
        public Diagnosis? Diagnosis { get; set; }
        public Guid DiagnosisId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmittance { get; set; }
        public DateTime? DateOfDischarge { get; set; }
        public Gender PatientGender { get; set; }
        public Insurance PatientInsurance { get; set; }
        public bool IsDischarged { get; set; }
    }
}
