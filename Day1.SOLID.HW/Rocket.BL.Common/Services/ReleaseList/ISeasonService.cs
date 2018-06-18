using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.BL.Common.DtoModels.ReleaseList;

namespace Rocket.BL.Common.Services.ReleaseList
{
    /// <summary>
    /// Представляет сервис для работы с детальной информацией
    /// о сезоне сериала в хранилище данных
    /// </summary>
    public interface ISeasonService
    {
        /// <summary>
        /// Возвращает коллекцию сезонов сериала по заданному идентификатору сериала
        /// </summary>
        /// <param name="id">Идентификатор сериала</param>
        /// <returns>Коллекция сезонов сериала</returns>
        TvSeriesSeasonsDto GetSeasons(int id);
    }
}
