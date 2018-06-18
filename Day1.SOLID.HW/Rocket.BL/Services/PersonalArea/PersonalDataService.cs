using AutoMapper;
using FluentValidation;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.BL.Properties;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.UoW;
using Rocket.DAL.Identity;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rocket.BL.Services.PersonalArea
{
    public class PersonalDataService : BaseService, IPersonalDataManager
    {
        private readonly IValidator _validator;
        private readonly RocketUserManager _userManager;

        public PersonalDataService(IUnitOfWork unitOfWork, IValidator<Common.Models.User.User> validator, RocketUserManager usermanager) : base(unitOfWork)
        {
            _validator = validator;
            _userManager = usermanager;
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

       
    }
}