using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.BL.Common.Models.User;

namespace Rocket.BL.Common.Services.User
{
    public interface IUserAccountManager : IDisposable
    {
        /// <summary>
        /// Получает уровень аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Уровень аккаунта пользователя.</returns>
        AccountLevel GetUserAccountLevel(int id);

        /// <summary>
        /// Задает значение уровня аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="accountLevel">Задаваемый уровень аккаунта.</param>
        void SetUserAccountLevel(int id, AccountLevel accountLevel);

        /// <summary>
        /// Получает статус аккаунта пользователя с определенным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Статус аккаунта пользователя.</returns>
        AccountStatus GetUserAccountStatus(int id);

        /// <summary>
        /// Задает статус аккаунта пользователя с определенным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="accountStatus">Статус аккаунта пользователя.</param>
        void SetUserAccountStatus(int id, AccountStatus accountStatus);

        /// <summary>
        /// После добавление пользователя в репозитарий 
        /// генерирует ссылку, по которой пользователь
        /// в случае получения уведомлении об активации, может 
        /// активировать аккаунт.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Ссылку для активации аккаунта.</returns>
        string CreateConfirmationLink(Models.User.User user);

        /// <summary>
        /// Получение модели авторизованного пользователя по Id.
        /// </summary>
        /// <param name="id">Id по которому необходимо найти пользователя.</param>
        /// <returns>Модель авторизованного пользователя.</returns>
        UserProfile GetUserData(string id);

        /// <summary>
        /// Изменение персональных данных.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену личных данных.</param>
        /// <param name="firstName">Имя пользователя.</param>
        /// <param name="lastName">Фамилия пользователя.</param>
        /// <param name="avatar">Аватар пользователя.</param>
        void ChangePersonalData(string id, string firstName, string lastName, string avatar);
    }
}
