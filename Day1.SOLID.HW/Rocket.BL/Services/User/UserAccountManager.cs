using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.BL.Common.Models.User;
using Rocket.BL.Common.Services.User;
using Rocket.BL.Properties;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.UoW;

namespace Rocket.BL.Services.User
{
    public class UserAccountManager : BaseService, IUserAccountManager
    {
        /// <summary>
        /// Создает новый экземпляр <see cref="UserAccountManager"/>
        /// с заданным unit of work.
        /// </summary>
        /// <param name="unitOfWork">Экземпляр unit of work.</param>
        public UserAccountManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        /// <summary>
        /// Получает уровень аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Уровень аккаунта пользователя.</returns>
        public AccountLevel GetUserAccountLevel(int id)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id.ToString())
                .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return null;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            return user.AccountLevel;
        }

        ///// <summary>
        ///// Задает значение уровня аккаунта пользователя с заданным идентификатором.
        ///// </summary>
        ///// <param name="id">Идентификатор пользователя.</param>
        ///// <param name="accountLevel">Задаваемый уровень аккаунта.</param>
        public void SetUserAccountLevel(int id, AccountLevel accountLevel)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id.ToString())
                                  .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            user.AccountLevel = accountLevel;

            var dbUser = Mapper.Map<DbUser>(user);
            _unitOfWork.UserRepository.Update(dbUser);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Получает уровень аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Уровень аккаунта пользователя.</returns>
        public AccountStatus GetUserAccountStatus(string id)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id)
                .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return null;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            return user.AccountStatus;
        }

        /// <summary>
        /// Задает значение уровня аккаунта пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="accountStatus">Задаваемый уровень аккаунта.</param>
        public void SetUserAccountStatus(string id, AccountStatus accountStatus)
        {
            var isUserExist = _unitOfWork.UserRepository.Get(u => u.Id == id)
                                  .FirstOrDefault() != null;

            // Проверка на наличие пользователя в хранилище.
            if (!isUserExist)
            {
                return;
            }

            var user = Mapper.Map<Rocket.BL.Common.Models.User.User>(
                _unitOfWork.UserRepository.GetById(id));

            user.AccountStatus = accountStatus;

            var dbUser = Mapper.Map<DbUser>(user);
            _unitOfWork.UserRepository.Update(dbUser);
            _unitOfWork.SaveChanges();
        }

        public AccountStatus GetUserAccountStatus(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SetUserAccountStatus(int id, AccountStatus accountStatus)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Получение пользователя по Id.
        /// </summary>
        /// <param name="id">Id пользователя.</param>
        /// <returns>Модель авторизованного пользователя.</returns>
        public UserProfile GetUserData(string id)
        {
            return Mapper.Map<UserProfile>(_unitOfWork.UserAuthorisedRepository.Get(
                    f => f.DbUser_Id == id,
                    includeProperties: $"{nameof(DbUser)}")
                    ?.FirstOrDefault());
        }

        /// <summary>
        /// Смена персональных данных.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену личных данных.</param>
        /// <param name="firstName">Имя пользователя.</param>
        /// <param name="lastName">Фамилия пользователя.</param>
        /// <param name="avatar">Аватар пользователя.</param>
        public void ChangePersonalData(string id, string firstName, string lastName, string avatar)
        {
            var user = _unitOfWork.UserRepository.Get(
                        f => f.Id == id,
                        includeProperties: $"{nameof(DbUserProfile)}")
                        ?.FirstOrDefault() ?? throw new ValidationException(Resources.InvalidUserId);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.DbUserProfile.Avatar = avatar;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// После добавление пользователя в репозитарий
        /// генерирует ссылку, по которой пользователь
        /// в случае получения уведомлении об активации, может
        /// активировать аккаунт.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Ссылку для активации аккаунта.</returns>
        public string CreateConfirmationLink(Common.Models.User.User user)
        {
            // todo надо сделать реализацию, после того, как "прорастут" вьюхи.
            return string.Empty;
        }
    }
}
