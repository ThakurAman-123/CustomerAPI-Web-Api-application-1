using CustomerAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly CustomerContext _customerContext;
        private readonly DbSet<T> _dbSet;

        //Depenedncy Injection
        public GenericRepository(CustomerContext customerContext){
            _customerContext = customerContext;
            _dbSet = _customerContext.Set<T>();

            }

        //insert query
        public async Task<T> AddEntity(T Entity)
        {
            //saved the object to table
           var result= await _dbSet.AddAsync(Entity);
            //saved changes in the table
            await _customerContext.SaveChangesAsync();
            return result.Entity;

        }
        //delete query
        public async Task<bool> DeleteEntity(long Key)
        {
            bool status = false;
            var entity= await _dbSet.FindAsync(Key);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _customerContext.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        //select all
        public async Task<IEnumerable<T>> GetAllValues()
        {
            return await _dbSet.ToListAsync();

        }

        //select where ?
        public async Task<T> GetEntityById(long Key)
        {
            return await _dbSet.FindAsync(Key);

        }

        //update table
        public async Task<T> UpdateEntity(T Entity)
        {
           var result= _dbSet.Update(Entity);
            await _customerContext.SaveChangesAsync();
            return result.Entity;
        }
    }
 
}
