using PC_ControllerApi.Models;

namespace PC_ControllerApi.Interfaces
{
    public interface IDbManager<T> where T : BaseEntity
    {
        public Task SaveAsync(T entity);
        public Task UpdateAsync(T entity);

    }
}
