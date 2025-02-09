using PC_ControllerApi.Interfaces;
using PC_ControllerApi.Models;

namespace PC_ControllerApi.Implementations.Factories
{
    public class DbManagerFactory : IDbManagerFactory
    {
        ApplicationContext _context;

        public DbManagerFactory(ApplicationContext context)
        {
            _context = context;
        }

        public DbManager<T> GetDbManager<T>() where T :  BaseEntity => new DbManager<T>(_context);

    }
}
