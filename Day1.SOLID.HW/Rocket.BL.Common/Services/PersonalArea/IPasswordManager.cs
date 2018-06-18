namespace Rocket.BL.Common.Services.PersonalArea
{
    /// <summary>
    /// Представляет сервис для работы с паролем.
    /// </summary>
    public interface IPasswordManager
    {
        /// <summary>
        /// Изменение пароля на новый.
        /// </summary>
        /// <param name="id">Id пользователя, инициировавшего смену пароля.</param>
        /// <param name="newPassword">Новый пароль, введенный пользователем.</param>
        /// <param name="newPasswordConfirm">Подтверждение пароля.</param>
        void ChangePasswordData(string id, string newPassword, string newPasswordConfirm);
    }
}
