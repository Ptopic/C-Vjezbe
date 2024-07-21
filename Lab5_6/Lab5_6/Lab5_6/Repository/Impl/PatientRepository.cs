using Lab5_6.Data;
using Lab5_6.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab5_6.Repository.Impl
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientInfoContext _context;
        protected readonly DbSet<Patient> DbSet;

        public PatientRepository(PatientInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<Patient>();
        }

        public IQueryable<Patient> FindByCondition(Expression<Func<Patient, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking();
        }

        public async Task<Patient> AddAsync(Patient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(patient => patient.Id == id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(Guid? id)
        {
            return await FindByCondition(product => product.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Patient entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
