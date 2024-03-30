using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    }
}
