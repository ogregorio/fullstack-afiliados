namespace FullstackAfiliados.Domain.Services.Interfaces;

public interface IBaseService<T>
{
    Task<T> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T value);
    Task<T> DeleteAsync(Guid id);
    Task<T> UpdateAsync(Guid id, T value);
    Task<Boolean> ExistsAsync(Guid id);
}