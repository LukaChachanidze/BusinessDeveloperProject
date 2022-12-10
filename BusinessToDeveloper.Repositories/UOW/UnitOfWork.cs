using BusinessToDeveloper.Infrastructure.Data;
using BusinessToDeveloper.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace BusinessToDeveloper.Repositories.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusinessToDeveloperDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(BusinessToDeveloperDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.TryGetValue(typeof(T), out var repo))
            {
                return (IGenericRepository<T>)repo;
            }

            var newRepo = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), newRepo);
            return newRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
