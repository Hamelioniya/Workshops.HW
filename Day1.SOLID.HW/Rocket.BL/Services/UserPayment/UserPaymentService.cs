using AutoMapper;
using Rocket.BL.Common.Models.User;
using Rocket.BL.Common.Models.UserPayment;
using Rocket.BL.Common.Services.UserPayment;
using Rocket.DAL.Common.DbModels;
using Rocket.DAL.Common.UoW;

namespace Rocket.BL.Services.UserPayment
{
    /// <summary>
    /// Представляет сервис для работы с платежами
    /// </summary>
    public class UserPaymentService : BaseService, IUserPaymentService
    {
        public UserPaymentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// получение инфы о платеже.
        /// </summary>
        /// <param name="user">Экземпляр пользователя, для которого ищем инфу о платеже.</param>
        /// <returns>Платеж пользователя</returns>
        public Payment GetUserPayment(Common.Models.User.User user)
        {
            var dbPayment = _unitOfWork.UserPaymentRepository.Get(p => p.UserId == user.Id);

            return Mapper.Map<Payment>(dbPayment);
        }

        /// <summary>
        /// добавление инфы о платеже.
        /// </summary>
        /// <param name="payment">Экземпляр платежа пользователя, для которого ищем инфу о платеже.</param>
        public void AddUserPayment(Payment payment)
        {
            var dbPayment = Mapper.Map<DbUserPayment>(payment);
            _unitOfWork.UserPaymentRepository.Insert(dbPayment);
            _unitOfWork.SaveChanges();
        }
    }
}