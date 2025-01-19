using Microsoft.EntityFrameworkCore;
using PC_ControllerApi.Models;
using PC_ControllerApi;
using PluralizeService.Core;
using PC_ControllerApi.Interfaces;

namespace PC_ControllerApi.Implementations
{
    public class DbManager<T> : IDbManager<T> where T : BaseEntity
    {
        private ApplicationContext _context;


        public DbManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(T entity)
        {
            var dbSet = (DbSet<T>)_context.GetType().GetProperty(PluralizationProvider.Pluralize(entity.GetType().Name))!.GetValue(_context)!;
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            var dbSet = (DbSet<T>)_context.GetType().GetProperty(PluralizationProvider.Pluralize(entity.GetType().Name))!.GetValue(_context)!;
            var rec = await dbSet.FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (rec == null) throw new InvalidOperationException($"Entity with id {entity.Id} not found");

            foreach (var prop in rec.GetType().GetProperties())
            {
                var value = prop.GetValue(entity);
                if (value != null) rec.GetType().GetProperty(prop.Name)!.SetValue(rec, value);
                else rec.GetType().GetProperty(prop.Name)!.SetValue(rec, null);
            }

            dbSet.Update(rec);
            await _context.SaveChangesAsync();
        }
    }
}