using Lab5_6.Entities;

namespace Lab5_6.Repository
{
    public interface IPatientRepository
    {
        Task<IList<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(Guid? id);
        Task<Patient> AddAsync(Patient entity);
        Task UpdateAsync(Patient entity);
        Task DeleteAsync(Guid id);
    }
}
