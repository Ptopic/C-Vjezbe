using System;
using System.Linq.Expressions;
using Lab4.Data;
using Lab4.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Repositories
{
    public class PatientInfoRepository : IPatientInfoRepository
	{
        private readonly PatientInfoContext _context;
        protected readonly DbSet<Patient> DbSet;

        public PatientInfoRepository(PatientInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<Patient>();
        }

        public IQueryable<Patient> FindByCondition(Expression<Func<Patient, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking();
        }

        public async Task<Diagnosis?> GetDiagnosisAsync(Guid diagnosisId)
        {
            return await _context.Diagnoses.FirstOrDefaultAsync(diagnosis => diagnosis.Id == diagnosisId);
        }

        public async Task<IEnumerable<Diagnosis>> GetDiagnosesListAsync()
        {
            return await _context.Diagnoses.OrderBy(diagnosis => diagnosis.Id).ToListAsync();
        }

        public async Task<Patient?> GetPatientAsync(Guid patientId)
        {
            return await _context.Patients.FirstOrDefaultAsync(patient => patient.Id == patientId);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.OrderBy(patient => patient.LastName).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<bool> PatientExistsAsync(Guid patientId)
        {
            return await _context.Patients.AnyAsync(patient => patient.Id == patientId);
        }

        public void DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllAdmittedPatients()
        {
            return await _context.Patients
                .Where(p => p.IsDischarged == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllDischargedPatients()
        {
            return await _context.Patients
                .Where(p => p.IsDischarged == true)
                .ToListAsync();
        }
    }
}

