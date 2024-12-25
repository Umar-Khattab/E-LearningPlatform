using E_LearningPlatform.Interfaces;
using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_LearningPlatform.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly ILogger<BaseRepository<T>> _logger;

        public BaseRepository(AppDBContext context, ILogger<BaseRepository<T>> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _logger.LogInformation($"Adding new {typeof(T).Name}");
                _context.Set<T>().Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding {typeof(T).Name}");
                throw new RepositoryException($"Error adding {typeof(T).Name}", ex);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _logger.LogInformation($"Deleting {typeof(T).Name}");
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting {typeof(T).Name}");
                throw new RepositoryException($"Error deleting {typeof(T).Name}", ex);
            }
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                _logger.LogInformation($"Finding {typeof(T).Name} by predicate");
                var entity = _context.Set<T>().FirstOrDefault(predicate);

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

        public IEnumerable<T> GetAll()
        {
            try
            {
                _logger.LogInformation($"Getting all {typeof(T).Name} entities");
                return _context.Set<T>().AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting all {typeof(T).Name} entities");
                throw new RepositoryException($"Error retrieving {typeof(T).Name} list", ex);
            }
        }

        public T Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _logger.LogInformation($"Updating {typeof(T).Name}");
                _context.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating {typeof(T).Name}");
                throw new RepositoryException($"Error updating {typeof(T).Name}", ex);
            }
        }

        public int Count()
        {
            try
            {
                return _context.Set<T>().Count();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error counting {typeof(T).Name} entities");
                throw new RepositoryException($"Error counting {typeof(T).Name} entities", ex);
            }
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            try
            {
                return _context.Set<T>().Count(criteria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error counting {typeof(T).Name} entities with criteria");
                throw new RepositoryException($"Error counting {typeof(T).Name} entities", ex);
            }
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>().Where(criteria);

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

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database update error occurred");
                throw new RepositoryException("Error saving changes to database", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving changes");
                throw new RepositoryException("Error saving changes", ex);
            }
        }
    }

    // Custom exceptions
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException = null)
            : base(message, innerException) { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}