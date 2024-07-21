using System;
using System.Security.Cryptography;
using Bogus;
using static Bogus.DataSets.Name;

namespace Lab_2
{
	public class Patient
	{
        public string OIB { get; set; }
        public string MBO { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Diagnosis { get; set; }

        public Patient(){}

        public Patient(string _OIB, string _MBO, string _Firstname, string _Lastname, DateTime _DateOfBirth, string _Gender, string _Diagnosis)
        {
            OIB = _OIB;
            MBO = _MBO;
            Firstname = _Firstname;
            Lastname = _Lastname;
            DateOfBirth = _DateOfBirth;
            Gender = _Gender;
            Diagnosis = _Diagnosis;
        }

        public static List<Patient> SeedPatients(int count)
        {
            var faker = new Faker<Patient>()
                .RuleFor(p => p.OIB, f => string.Join("", f.Random.Digits(11)))
                .RuleFor(p => p.MBO, f => string.Join("", f.Random.Digits(9)))
                .RuleFor(p => p.Firstname, f => f.Person.FirstName)
                .RuleFor(p => p.Lastname, f => f.Person.LastName)
                .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(p => p.Gender, f => f.Person.Gender.ToString())
                .RuleFor(p => p.Diagnosis, f => f.Lorem.Sentence());

            return faker.Generate(count);
        }

        public override string ToString()
        {
            return $@"
OIB: {OIB}
MBO: {MBO}
First name: {Firstname}
Last name: {Lastname}
Date of birth: {DateOfBirth.ToString("d")}
Gender: {Gender}
Diagnosis: {Diagnosis}";
        }
    }
}

