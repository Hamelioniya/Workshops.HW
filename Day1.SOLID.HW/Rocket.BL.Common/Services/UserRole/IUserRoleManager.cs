﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Rocket.DAL.Common.DbModels.Identity;

namespace Rocket.BL.Common.Services.UserRole
{
    public interface IUserRoleManager : IDisposable
    {
        /// <summary>
        /// Добавить пользователю роль
        /// </summary>
        /// <param name="userId"> Идентификатор ползователя. </param>
        /// <param name="roleId"> Идентификатор ролию </param>
        /// <returns> Task </returns>
        Task<IdentityResult> AddToRole(string userId, string roleId);

        /// <summary>
        /// Получить все роли пользователя по его Id
        /// </summary>
        /// <param name="userId"> Идентификатор ползователя. </param>
        /// <returns>list</returns>
        Task<IEnumerable<string>> GetRoles(string userId);

        /// <summary>
        /// Проверка что у юзера есть соответствующая роль
        /// </summary>
        /// <param name="userId"> Идентификатор ползователя. </param>
        /// <param name="roleId"> Идентификатор ролию </param>
        /// <returns>bool</returns>
        Task<bool> IsInRole(string userId, string roleId);

        /// <summary>
        /// Удалить роль у юзера
        /// </summary>
        /// <param name="userId"> Идентификатор ползователя. </param>
        /// <param name="roleId"> Идентификатор ролию </param>
        /// <returns>bool</returns>
        Task<IdentityResult> RemoveFromRole(string userId, string roleId);
    }
}