using BusinessToDeveloper.Repositories.Repository;

namespace BusinessToDeveloper.Repositories.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
