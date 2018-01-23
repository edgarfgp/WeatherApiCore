using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherApiCore.Model;

namespace WeatherApiCore.IServices
{
    public interface IDatabaseRepo
    {
        /// <summary>
        /// Create a new object in the repository
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <param name="document">Object reference.</param>
        /// <returns>The just created object.</returns>
        Task<T> Create<T>(T document) where T : ObjectBase;

        /// <summary>
        /// Update an object on the repository
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <param name="Id">Identifier of the object in the Repository</param>
        /// <param name="document">Content used to modify the object.</param>
        /// <returns>The just updated object.</returns>
        Task<T> Update<T>(Guid Id, T document) where T : ObjectBase;

        /// <summary>
        /// Delete an object from the repository
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <param name="Id">Identifier of the object to remove.</param>
        /// <returns>True if the object was removed. False it is was not found.</returns>
        Task<bool> Delete<T>(Guid Id) where T : ObjectBase;

        /// <summary>
        /// Deletes all the object of the class in the database.
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <returns>Number of objects removed.</returns>
        Task<int> DeleteAll<T>() where T : ObjectBase;

        /// <summary>
        /// Retrieve an object from the repository
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <param name="Id">Identifier of the Object to retrieve.</param>
        /// <returns>Desired object or null if the object was not.</returns>
        Task<T> Get<T>(Guid Id) where T : ObjectBase;

        /// <summary>
        /// Retrieve all the objects of a given class from the repository
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <returns>IEnumerable of objects of the given class.</returns>
        Task<IEnumerable<T>> Get<T>() where T : ObjectBase;

        /// <summary>
        /// Retrieve all the objects of a given class from the repository filtered by the predicate.
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <param name="predicate">A <see cref="System.Linq"/> valid predicate to be used to filter the call to <see cref="IDatabaseRepo"/>.</param>
        /// <returns>IEnumerable of objects of the given class.</returns>
        Task<IEnumerable<T>> Get<T>(
            Expression<Func<T, bool>> predicate
            ) where T : ObjectBase;

        /// <summary>
        /// Retrieve all the objects of a given class from the repository filtered by the predicates.
        /// </summary>
        /// <typeparam name="T"><see cref="ObjectBase"/> derive type</typeparam>
        /// <param name="predicate1">First predicate</param>
        /// <param name="predicate2">Second predicate</param>
        /// <returns>IEnumerable of objects of the given class.</returns>
        Task<IEnumerable<T>> Get<T>(
            Expression<Func<T, bool>> predicate1,
            Expression<Func<T, bool>> predicate2
            ) where T : ObjectBase;

    }

}


