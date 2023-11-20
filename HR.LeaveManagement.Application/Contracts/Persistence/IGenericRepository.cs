namespace HR.LeaveManagement.Application.Contracts.Persistence;
public interface IGenericRepository<T> where T : class // public interface that accepts a type parameter T where T is a type of generic class
{
    Task<List<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
