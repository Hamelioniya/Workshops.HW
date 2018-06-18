using System.Collections.Generic;
using Rocket.BL.Common.Models.UserRoles;

namespace Rocket.BL.Common.Services.UserRole
{
    public interface IPermissionService
    {
        /// <summary>
        /// Добавить существующую функц возможность для выбранной роли
        /// </summary>
        /// <param name="idRole"> ID role </param>
        /// <param name="idPermission"> ID permission </param>
        void AddPermissionToRole(string idRole, int idPermission);

        /// <summary>
        /// Удалить функц возможность из текущего списка у роли
        /// </summary>
        /// <param name="idRole"> ID role </param>
        /// <param name="idPermission"> ID permission </param>
        void RemovePermissionFromRole(string idRole, int idPermission);

        /// <summary>
        /// Получить все пермишены
        /// </summary>
        /// <returns>Список пермишенов</returns>
        IEnumerable<Permission> GetAllPermissions();

        /// <summary>
        /// Возвращает пермешен с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Permission</returns>
        Permission GetPermissionById(string id);

        /// <summary>
        /// Получить пермишены для роли
        /// </summary>
        /// <param name="idRole">ID role</param>
        /// <returns></returns>
        IEnumerable<Permission> GetPermissionByRole(string idRole);
    }
}