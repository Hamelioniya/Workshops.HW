using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Rocket.BL.Common.Services.User;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;
using Swashbuckle.Swagger.Annotations;

namespace Rocket.Web.Controllers.User
{
    [RoutePrefix("user/account")]
    public class UserAccountController : ApiController
    {
        private IUserAccountManager _userAccountManager;

        public UserAccountController(IUserAccountManager userAccountManager)
        {
            _userAccountManager = userAccountManager;
        }

        [HttpGet]
        [Route()]
        public IHttpActionResult GetAuthorisedUser()
        {
            var user = _userAccountManager.GetUserData(User.GetUserId());
            return user == null ? (IHttpActionResult)NotFound() : Ok(user);
        }

        [HttpPut]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid", typeof(string))]
        [Route("info")]
        public IHttpActionResult UpdateUserPersonalInfo(string firstName, string lastName, string avatar)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return BadRequest(Resources.UserEmptyFirstNameOrLastName);
            }

            try
            {
                _userAccountManager.ChangePersonalData(User.GetUserId(), firstName, lastName, avatar);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return new StatusCodeResult(HttpStatusCode.NoContent, Request);
        }
    }
}
