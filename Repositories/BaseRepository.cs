using E_LearningPlatform.Interfaces;
using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_LearningPlatform.Repositories
{
    /// <summary>
    /// A base repository class that provides common data access methods for entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<BaseRepository<T>> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="logger">The logger instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when context or logger is null.</exception>
        public BaseRepository(AppDBContext context, ILogger<BaseRepository<T>> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbSet = _context.Set<T>() ?? throw new AbandonedMutexException("Failed to get DbSet for entity");
        }

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
        /// <exception cref="RepositoryException">Thrown when an error occurs while adding the entity.</exception>
        public T Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _logger.LogInformation($"Adding new {typeof(T).Name}");
                _dbSet.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {typeof(T).Name}");
                throw new RepositoryException($"Error adding {typeof(T).Name}", ex);
            }
        }
        /// <summary>
        /// Adds a new entity to the database asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity will be added</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RepositoryException"></exception>
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                _logger.LogInformation($"Adding new {typeof(T).Name}");
                await _dbSet.AddAsync(entity);
                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {typeof(T).Name}");
                throw new RepositoryException($"Error adding {typeof(T).Name}", ex);
            }
        }
        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
        /// <exception cref="RepositoryException">Thrown when an error occurs while deleting the entity.</exception>
        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _logger.LogInformation($"Deleting {typeof(T).Name}");
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting {typeof(T).Name}");
                throw new RepositoryException($"Error deleting {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Finds an entity that matches the specified predicate.
        /// </summary>
        /// <remarks>Warning : Predicate parameter must be Unique like (gmail,ID...etc)!!</remarks>
        /// <param name="predicate">The predicate to match.</param>
        /// <returns>The entity that matches the predicate.</returns>
        /// <exception cref="NotFoundException">Thrown when no entity is found that matches the predicate.</exception>
        /// <exception cref="RepositoryException">Thrown when an error occurs while finding the entity.</exception>
        public T Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                _logger.LogInformation($"Finding {typeof(T).Name} by predicate");
                var entity = _dbSet.FirstOrDefault(predicate);

                if (entity == null)
                    throw new NotFoundException($"{typeof(T).Name} not found");

                return entity;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error finding {typeof(T).Name}");
                throw new RepositoryException($"Error finding {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Gets all entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        /// <exception cref="RepositoryException">Thrown when an error occurs while retrieving the entities.</exception>
        public IEnumerable<T> GetAll()
        {
            try
            {
                _logger.LogInformation($"Getting all {typeof(T).Name} entities");
                return _dbSet.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting all {typeof(T).Name} entities");
                throw new RepositoryException($"Error retrieving {typeof(T).Name} list", ex);
            }
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when entity is null.</exception>
        /// <exception cref="RepositoryException">Thrown when an error occurs while updating the entity.</exception>
        public T Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _logger.LogInformation($"Updating {typeof(T).Name}");
                _dbSet.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {typeof(T).Name}");
                throw new RepositoryException($"Error updating {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Gets the count of all entities in the database.
        /// </summary>
        /// <returns>The count of all entities.</returns>
        /// <exception cref="RepositoryException">Thrown when an error occurs while counting the entities.</exception>
        public int Count()
        {
            try
            {
                return _dbSet.Count();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error counting {typeof(T).Name} entities");
                throw new RepositoryException($"Error counting {typeof(T).Name} entities", ex);
            }
        }

        /// <summary>
        /// Gets the count of entities that match the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria to match.</param>
        /// <returns>The count of entities that match the criteria.</returns>
        /// <exception cref="RepositoryException">Thrown when an error occurs while counting the entities.</exception>
        public async Task<int> CountSpecificAsync(Expression<Func<T, bool>> criteria)
        {
            try
            {
                return await _dbSet.CountAsync(criteria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error counting {typeof(T).Name} entities with criteria");
                throw new RepositoryException($"Error counting {typeof(T).Name} entities", ex);
            }
        }

        /// <summary>
        /// Finds all entities Async that match the specified criteria, with optional pagination.
        /// </summary>
        /// <param name="criteria">The criteria to match.</param>
        /// <param name="skip">The number of entities to skip.</param>
        /// <param name="take">The number of entities to take.</param>
        /// <returns>An enumerable collection of entities that match the criteria.</returns>
        /// <exception cref="RepositoryException">Thrown when an error occurs while finding the entities.</exception>
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take)
        {
            try
            {
                IQueryable<T> query = _dbSet.Where(criteria);

                if (skip.HasValue)
                    query = query.Skip(skip.Value);

                if (take.HasValue)
                    query = query.Take(take.Value);

                return query.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error finding {typeof(T).Name} entities with criteria");
                throw new RepositoryException($"Error finding {typeof(T).Name} entities", ex);
            }
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take)
        {
            try
            {
                IQueryable<T> query = await Task.FromResult(_dbSet.Where(criteria));
                if (skip.HasValue)
                    query = query.Skip(skip.Value);
                if (take.HasValue)
                    query = query.Take(take.Value);
                return await Task.FromResult(query.AsNoTracking().ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error finding {typeof(T).Name} entities with criteria");
                throw new RepositoryException($"Error finding {typeof(T).Name} entities", ex);
            }
        }

        /// <summary>
        /// Represents errors that occur during repository operations.
        /// </summary>
        public class RepositoryException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RepositoryException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
            /// </summary>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
            public RepositoryException(string message, Exception innerException = null)
                : base(message, innerException) { }
        }

        /// <summary>
        /// Represents errors that occur when an entity is not found.
        /// </summary>
        public class NotFoundException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
            /// </summary>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public NotFoundException(string message) : base(message) { }
        }
    }
}
