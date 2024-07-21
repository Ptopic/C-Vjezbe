using System;
using Lab4.Entities;

namespace Lab4.Models
{
	public class PatientCreationDto
	{
        public string? PatientOib { get; set; }
        public string? PatientMbo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid DiagnosisId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmittance { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public Gender PatientGender { get; set; }
        public Insurance PatientInsurance { get; set; }
        public bool IsDischarged { get; set; }
    }
}

