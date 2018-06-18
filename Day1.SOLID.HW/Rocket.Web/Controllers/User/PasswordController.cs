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
    [Route("user/account/password")]
    public class PasswordController : ApiController
    {
        private IUserPasswordManager _passwordManager;

        public PasswordController(IUserPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }

        [HttpPut]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Password is not valid", typeof(string))]
        [Route("")]
        public IHttpActionResult UpdatePassword(string password, string passwordConfirm)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordConfirm))
            {
                return BadRequest(Resources.EmptyPassword);
            }

            try
            {
                _passwordManager.ChangePasswordData(User.GetUserId(), password, passwordConfirm);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return new StatusCodeResult(HttpStatusCode.NoContent, Request);
        }
    }
}
