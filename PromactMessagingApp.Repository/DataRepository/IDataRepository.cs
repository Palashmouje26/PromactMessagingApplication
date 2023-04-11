using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromactMessagingApp.Repository.Data
{
    public interface IDataRepository
    {
        /// <summary>
        /// Filters data based on predicate.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>IQueryable containing filtered elements.</returns>
        IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate)
            where T : class;

        /// <summary>
        /// Selects data based on predicate.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <typeparam name="Tresult">The type of entity, returned by the method.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>IQueryable containing selected elements.</returns>
        IQueryable<Tresult> Select<T, Tresult>(Expression<Func<T, Tresult>> predicate)
            where T : class;

        /// <summary>
        /// Determines whether any data matches the condition.
        /// </summary>
        /// <typeparam name="T">Model calss to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>True if such data is found.</returns>
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate)
            where T : class;

        /// <summary>
        /// Retrieves all the data.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <returns>List of all the elements.</returns>
        //task<list<t>> getallasync<t>(func<object, bool> value)
        //    where t : class;
        Task<List<T>> GetAllAsync<T>() where T : class;

        /// <summary>
        /// Adds entity to the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to add.</param>
        /// <returns>Task</returns>
        Task AddAsync<T>(T entity)
            where T : class;

        /// <summary>
        /// Adds entities to the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to add.</param>
        /// <returns>Task</returns>
        Task AddRangeAsync<T>(IEnumerable<T> entities)
            where T : class;

        /// <summary>
        /// Updates entity in the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to update.</param>
        /// <returns>Task</returns>
        Task UpdateAsync<T>(T entity)
            where T : class;

        /// <summary>
        /// Updates entities to the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to update.</param>
        /// <returns>Task</returns>
        Task UpdateRangeAsync<T>(IEnumerable<T> entities)
            where T : class;

        Task UpdateStatusAsync<T>(List<T> entities)
             where T : class;

        /// <summary>
        /// Remove entity from the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to remove.</param>
        /// <returns>Task</returns>
        Task RemoveAsync<T>(T entity)
            where T : class;

        /// <summary>
        /// Remove entities from the DbSet.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to remove.</param>
        /// <returns>Task</returns>
        Task RemoveRangeAsync<T>(IEnumerable<T> entities)
            where T : class;

        /// <summary>
        /// Method to begin database transaction.
        /// </summary>
        /// <returns>Nothing</returns>
        void TransactionBegin();

        /// <summary>
        /// Method to commit database transaction.
        /// </summary>
        /// <returns>Nothing</returns>
        void TransactionCommit();

        /// <summary>
        /// Method to Rolllback database transaction.
        /// </summary>
        /// <returns>Nothing</returns>
        void TransactionRollback();

        /// <summary>
        /// Method to get a database transaction.
        /// </summary>
        /// <returns>Dtabase context transaction</returns>
        IDbContextTransaction GetTransaction();

        /// <summary>
        /// Saves all tracking entity.
        /// </summary>
        /// <returns>Task</returns>
        Task SaveChangesAsync();

        /// <summary>
        /// Get first row from respective DbSet if data not found then return null
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>If row found then return enitity else return null</returns>
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate)
            where T : class;

        /// <summary>
        /// Get first row from respective DbSet
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Generic Entity</returns>
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate)
            where T : class;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate)
            where T : class;
        /// <summary>
        /// Get Count from Dbset.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate)
            where T : class;
    }
}

