using Lab5_6.Entities;
using Lab5_6.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;

namespace Lab5_6.Data
{
    public class PatientInfoContext: DbContext
    {
        public PatientInfoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Diagnosis> Diagnoses { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var diagnoses = new List<Diagnosis>
            {
                new Diagnosis("C00-D48")
                {
                    Id = Guid.Parse("2f5541d0-e32e-4d85-a5ae-37ca9baf7d24"),
                    Description = "Neoplazme"
                },
                new Diagnosis("C50-D89")
                {
                    Id = Guid.Parse("8a3bc909-ffda-47af-8817-2ee9d80baee2"),
                    Description = "Bolesti krvi i krvotvornih organa i određeni poremećaji imunološkog sustava"
                },
                new Diagnosis("E00-E90")
                {
                    Id = Guid.Parse("576fd12d-6eda-44ae-8445-9bd7f5804981"),
                    Description = "Endokrine, nutricijske i metaboličke bolesti"
                },
                new Diagnosis("F00-F99")
                {
                    Id = Guid.Parse("84aff43b-017c-421e-846b-9b55ba1dc61d"),
                    Description = "Mentalni poremećaji i poremećaji ponašanja"
                },
                new Diagnosis("G00-G99")
                {
                    Id = Guid.Parse("c4164c91-408f-4f2c-9963-0f17f915fb32"),
                    Description = "Bolesti živčanog sustava"
                },
                new Diagnosis("H00-H59")
                {
                    Id = Guid.Parse("8abf961e-67e5-4c66-82cd-804e521f7e68"),
                    Description = "Bolesti oka i adneksa"
                }
            };

            modelBuilder.Entity<Diagnosis>().HasData(diagnoses);

            var patients = new List<Patient>
            {
                new Patient()
                    {
                        Id = Guid.Parse("cc3835ad-5937-4426-b8e3-8a1d0a27a495"),
                        FirstName = "Petar",
                        LastName = "Topić",
                        DateOfBirth = DateTime.Parse("15/10/2002", CultureInfo.CreateSpecificCulture("en-GB")).ToUniversalTime(),
                        DateOfAdmittance = DateTime.Parse("20/4/2024", CultureInfo.CreateSpecificCulture("en-GB")).ToUniversalTime(),
                        DateOfDischarge = DateTime.Parse("25/4/2024", CultureInfo.CreateSpecificCulture("en-GB")).ToUniversalTime(),
                        DiagnosisId = Guid.Parse("8abf961e-67e5-4c66-82cd-804e521f7e68"),
                        PatientMbo = "111111111",
                    PatientOib = "11111111111",
                        PatientGender = Gender.Male,
                        PatientInsurance = Insurance.Supplementary,
                        IsDischarged = true
                    },
                    new Patient()
                    {
                        Id = Guid.Parse("cc066571-162b-4c8b-b912-9394e7639c43"),
                        FirstName = "Ivo",
                        LastName = "Ivic",
                        DateOfBirth = DateTime.Parse("1/1/2000", CultureInfo.CreateSpecificCulture("en-GB")).ToUniversalTime(),
                        DateOfAdmittance = DateTime.Parse("15/4/2024", CultureInfo.CreateSpecificCulture("en-GB")).ToUniversalTime(),
                        DateOfDischarge = DateTime.Parse("19/4/2024", CultureInfo.CreateSpecificCulture("en-GB")).ToUniversalTime(),
                        DiagnosisId = Guid.Parse("84aff43b-017c-421e-846b-9b55ba1dc61d"),
                        PatientMbo = "222222222",
                        PatientOib = "22222222222",
                        PatientGender = Gender.Male,
                        PatientInsurance = Insurance.Basic,
                        IsDischarged = true
                    }
            };
            modelBuilder.Entity<Patient>().HasData(patients);
        }
    }
}
