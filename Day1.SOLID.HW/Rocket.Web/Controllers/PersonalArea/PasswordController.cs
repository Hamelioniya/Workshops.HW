using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;
using Swashbuckle.Swagger.Annotations;

namespace Rocket.Web.Controllers.PersonalArea
{
    public class PasswordController : ApiController
    {
        private IPasswordManager _passwordManager;

        public PasswordController(IPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }

        [HttpPut]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Password is not valid", typeof(string))]
        [Route("password")]
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
