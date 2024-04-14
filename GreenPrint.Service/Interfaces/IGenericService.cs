using GreenPrint.Repository.Paging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IGenericService<DTO> where DTO : class
    {
        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="entity"></param>
        Task CreateAsync(DTO entity);

        /// <summary>
        /// Adds a list of entities to the database
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task CreateListAsync(List<DTO> entityList);

        /// <summary>
        /// Adds an entity to the database and returns it
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<DTO> CreateAndReturn(DTO entity);

        /// <summary>
        /// Updates an entiry in the database
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(DTO entity);

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(DTO entity);

        /// <summary>
        /// Gets an entities from the database
        /// </summary>
        /// <returns></returns>
        Task<List<DTO>> GetAllAsync();

        /// <summary>
        /// Gets an entity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DTO> GetByIdAsync(int id);

    }
}
