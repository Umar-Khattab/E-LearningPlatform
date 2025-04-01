using E_LearningPlatform.Interfaces;
using E_LearningPlatform.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LearningPlatform.Repositories
{
    /// <summary>
    /// Represents the unit of work for managing repositories and saving changes to the database.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly AppDBContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="logger">The logger instance.</param>
        public UnitOfWork(AppDBContext context, ILogger<UnitOfWork> logger)
        {
            _repositories = new Dictionary<Type, object>();
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets the repository for the specified entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <returns>The repository for the specified entity type.</returns>
        public IBaseRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                var logger = (ILogger<BaseRepository<T>>)_logger;
                _repositories[type] = new BaseRepository<T>(_context, logger);
            }
            return (IBaseRepository<T>)_repositories[type];
        }

        /// <summary>
        /// Saves the changes made to the context.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public int Save()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves the changes made to the context.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="UnitOfWork"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
