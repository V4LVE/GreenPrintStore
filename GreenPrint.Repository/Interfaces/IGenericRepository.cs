using GreenPrint.Repository.Paging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Interfaces
{
    public interface IGenericRepository<E> where E : class
    {
        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="entity"></param>
        Task CreateAsync(E entity);

        /// <summary>
        /// Adds a list of entities to the database
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task CreateListAsync(List<E> entityList);

        /// <summary>
        /// Adds an entity to the database and returns it
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<E> CreateAndReturn(E entity);

        /// <summary>
        /// Updates an entiry in the database
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(E entity);

        /// <summary>
        /// Updates a list of entities in the database
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task UpdateListAsync(List<E> entityList);

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(E entity);

        /// <summary>
        /// Gets an entities from the database
        /// </summary>
        /// <returns></returns>
        Task<List<E>> GetAllAsync();

        /// <summary>
        /// Gets an entity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<E> GetByIdAsync(int id);

    }
}
