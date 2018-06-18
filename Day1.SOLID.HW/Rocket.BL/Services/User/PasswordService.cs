using System.Text.RegularExpressions;
using FluentValidation;
using Rocket.BL.Common.Services.User;
using Rocket.BL.Properties;
using Rocket.DAL.Common.UoW;
using Rocket.DAL.Identity;

namespace Rocket.BL.Services.User
{
    public class PasswordService : BaseService, IUserPasswordManager
    {
        private readonly RocketUserManager _userManager;

        public PasswordService(IUnitOfWork unitOfWork, RocketUserManager usermanager) : base(unitOfWork)
        {
            _userManager = usermanager;
        }

        /// <summary>
        /// Приватный метод для проверки валидности пароля.
        /// </summary>
        /// <param name="password">Новый пароль.</param>
        /// <param name="passwordConfirm">Подтверждение пароля.</param>
        /// <returns>True - если пароль прошел валидацию, false - если не прошел.</returns>
        private bool PasswordValidate(string password, string passwordConfirm)
        {
            var pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$";
            return Regex.IsMatch(password, pattern) && password == passwordConfirm;
        }

        /// <summary>
        /// Смена пароля.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену пароля.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <param name="newPasswordConfirm">Подтверждение пароля.</param>
        public void ChangePasswordData(string id, string newPassword, string newPasswordConfirm)
        {
            if (!PasswordValidate(newPassword, newPasswordConfirm))
            {
                throw new ValidationException(Resources.UserWrongPassword);
            }

            var user = _unitOfWork.UserRepository.GetById(id) ?? throw new ValidationException(Resources.InvalidUserId);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }
    }
}
