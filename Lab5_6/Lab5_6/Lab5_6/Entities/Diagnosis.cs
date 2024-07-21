using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab5_6.Entities
{
    public class Diagnosis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();

        public Diagnosis(string title)
        {
            Title = title;
        }
    }
}
