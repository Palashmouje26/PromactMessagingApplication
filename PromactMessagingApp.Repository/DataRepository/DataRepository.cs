using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromactMessagingApp.DomainModel.DbContexts;

namespace PromactMessagingApp.Repository.Data
{
    public class DataRepository : IDataRepository
    {
        #region Private Methods
        private readonly MessagingDbContext _messagingDbContext;
        #endregion

        #region Constructor
        public DataRepository(MessagingDbContext messagingDbContext) 
        {
            _messagingDbContext = messagingDbContext;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds entity to the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to add.</param>
        /// <returns>Task</returns>
        public async Task AddAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            await dbSet.AddAsync(entity);
            await _messagingDbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Adds entities to the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to add.</param>
        /// <returns>Nothing</returns>
        public Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Determines whether any data matches the condition.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Nothing</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get count for respective dbset.
        /// </summary>
        /// <typeparam name="T"> Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to get count details.</param>
        /// <returns>Generic Entity</returns>
        public async Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            return await dbSet.CountAsync(predicate);
        }

        /// <summary>
        /// Get all information from respective 
        /// </summary>
        /// <typeparam name="T"> Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        public async Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            return await dbSet.FindAsync(predicate);
        }

        /// <summary>
        /// Get first row from respective DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Generic Entity</returns>
        public async Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            return await dbSet.FirstAsync(predicate);
        }
        /// <summary>
        /// Get first row from respective DbSet if data not found then return null.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>If row found then return enitity else return null</returns>
        public Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            return dbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Retrieves all the data.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <returns>List of all the elements.</returns>
        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            var values = await dbSet.ToListAsync<T>();
            return values;
        }

        /// <summary>
        /// Method to get a database transaction.
        /// </summary>
        /// <returns>Database context transaction</returns>
        public IDbContextTransaction GetTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove entity from the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to remove.</param>
        /// <returns>Task</returns>
        public async Task RemoveAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            dbSet.Remove(entity);
            await _messagingDbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Remove entities from the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to remove.</param>
        /// <returns>Task</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Saves all tracking entity.
        /// </summary>
        /// <returns>Nothing</returns>
        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Selects data based on predicate.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <typeparam name="Tresult">The type of entity, returned by the method.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Noyhing</returns>
        public IQueryable<Tresult> Select<T, Tresult>(Expression<Func<T, Tresult>> predicate) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to begin database transaction.
        /// </summary>
        /// <returns>Nothing</returns>
        public void TransactionBegin()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to commit database transaction.
        /// </summary>
        /// <returns>Nothing</returns>
        public void TransactionCommit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to Rolllback database transaction.
        /// </summary>
        /// <returns>Nothing</returns>
        public void TransactionRollback()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates entity in the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to update.</param>
        /// <returns>Task</returns>
        public async Task UpdateAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            dbSet.Update(entity);
            await _messagingDbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Updates entities to the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to update.</param>
        /// <returns>Nothing</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// update status entity Dbset.
        /// </summary>
        /// <typeparam name="T"> Model class to create DbSet.</typeparam>
        /// <param name="entities">Entity to update.</param>
        /// <returns>Task</returns>
        public async Task UpdateStatusAsync<T>(List<T> entities) where T : class
        {
            _messagingDbContext.Update(entities);
            await _messagingDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Filters data based on predicate.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>IQueryable containing filtered elements.</returns>
        public IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();

            return dbSet.Where(predicate);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// Model class for creating set.
        /// </typeparam>
        /// <returns>A DbSet object.</returns>
        private DbSet<T> CreateDbSetAsync<T>()
        where T : class
        {
            return _messagingDbContext.Set<T>();
        }
        #endregion
    }
}
