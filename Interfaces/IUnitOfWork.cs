namespace E_LearningPlatform.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : class;
        int Save();
        Task<int> SaveAsync();
    }
}
