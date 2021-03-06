﻿using Rocket.BL.Common.DtoModels.ReleaseList;
using Rocket.BL.Common.Models.Pagination;
using System;

namespace Rocket.BL.Common.Services.ReleaseList
{
    /// <summary>
    /// Представляет сервис для работы с детальной информацией
    /// о сериалах в хранилище данных
    /// </summary>
    public interface ITvSeriesService : IDisposable
    {
        /// <summary>
        /// Возвращает страницу сериалов с заданным номером, размером страницы
        /// и идентификатором жанра
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="genreId">Идентификатор жанра</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Страница сериалов</returns>
        PageInfo<TvSeriesMinimalDto> GetPageInfo(int pageSize, int pageNumber, int? genreId = null, string userId = null);

        /// <summary>
        /// Возвращает информацию о сериале с заданным идентификатором,
        /// количеством возвращаемых последних серий и количеством участников
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="episodesCount">Количество последних серий</param>
        /// <param name="personsCount">Количество участников сериала</param>
        /// <returns>Сериал</returns>
        TvSeriesFullDto GetTvSeries(int id, int? episodesCount = null, int? personsCount = null);
    }
}