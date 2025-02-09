using PC_ControllerApi.Implementations;
using PC_ControllerApi.Models;

namespace PC_ControllerApi.Interfaces
{
    public interface IDbManagerFactory
    {
        DbManager<T> GetDbManager<T>() where T : BaseEntity;
    }
}
