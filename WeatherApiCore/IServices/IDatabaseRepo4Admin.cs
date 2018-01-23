using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.IServices
{
    public interface IDatabaseRepo4Admin
    {

        /// <summary>
        /// Clears the content of the Repository.
        /// </summary>
        /// <remarks>For Testing proposes.</remarks>
        /// <returns>Task Void.</returns>
        Task ClearRepo();

    }
}
