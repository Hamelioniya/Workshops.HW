using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.BL.Common.DtoModels.ReleaseList;

namespace Rocket.BL.Common.Services.ReleaseList
{
    public interface ITvSeriesPersonService
    {
        /// <summary>
        /// Возвращает коллекцию участников сериала по заданному идентификатору сериала
        /// </summary>
        /// <param name="id">Идентификатор сериала</param>
        /// <returns>Коллекция участников сериала</returns>
        TvSeriesPersonsDto GetPersons(int id);
    }
}
