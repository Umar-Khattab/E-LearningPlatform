using E_LearningPlatform.Interfaces;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq.Expressions;
using E_LearningPlatform.Models;

namespace E_LearningPlatform.Repositories
{
    /// <summary>
    /// A base repository class that provides common data access methods for entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        /// <summary>
        /// Finds an entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match.</param>
        /// <returns>The entity that matches the predicate, or throws an exception if no entity is found.</returns>
        /// <exception cref="Exception">Thrown when no entity is found that matches the predicate.</exception>
        public T Find(Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate).FirstOrDefault() ?? throw new Exception($"Entity of type {typeof(T).Name} not found.");

        /// <summary>
        /// Gets all entities from the database.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        /// <summary>
        /// Gets the count of all entities in the database.
        /// </summary>
        /// <returns>The count of all entities.</returns>
        public int Count()
        {
            return _context.Set<T>().Count();
        }

        /// <summary>
        /// Gets the count of entities that match the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria to match.</param>
        /// <returns>The count of entities that match the criteria.</returns>
        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }

        /// <summary>
        /// Finds all entities that match the specified criteria, with optional pagination.
        /// </summary>
        /// <param name="criteria">The criteria to match.</param>
        /// <param name="skip">The number of entities to skip.</param>
        /// <param name="take">The number of entities to take.</param>
        /// <returns>An enumerable collection of entities that match the criteria.</returns>
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return query.ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
