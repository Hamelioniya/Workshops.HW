using Rocket.BL.Common.Models.PersonalArea;

namespace Rocket.BL.Common.Services.PersonalArea
{
    /// <summary>
    /// Интерфейс для работы с личными данными AuthorisedUser.
    /// </summary>
    public interface IPersonalDataManager
    {
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