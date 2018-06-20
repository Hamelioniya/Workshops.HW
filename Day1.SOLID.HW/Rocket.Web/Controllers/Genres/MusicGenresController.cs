using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Http;
using Rocket.BL.Common.Services.Genres;
using Rocket.Web.Extensions;
using Rocket.Web.Properties;
using Swashbuckle.Swagger.Annotations;

namespace Rocket.Web.Controllers.Genres
{
    public class MusicGenresController : ApiController
    {
        private readonly IMusicGenreManager _musicGenreManager;

        public MusicGenresController(IMusicGenreManager musicGenreManager)
        {
            _musicGenreManager = musicGenreManager;
        }

        [HttpGet]
        [Route("genres/music/all")]
        public IHttpActionResult GetAllMusicGenres()
        {
            var musicGenres = _musicGenreManager.GetAllMusicGenres();
            return musicGenres == null ? (IHttpActionResult)NotFound() : Ok(musicGenres);
        }

        [HttpPut]
        [Route("personal/genres/music/add")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Genre is not valid", typeof(string))]
        public IHttpActionResult SaveMusicGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest(Resources.EmptyGenre);
            }

            try
            {
                _musicGenreManager.AddMusicGenre(User.GetUserId(), genre);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("personal/genres/music/delete")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Genre is not valid", typeof(string))]
        public IHttpActionResult DeleteMusicGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
            {
                return BadRequest(Resources.EmptyGenre);
            }

            try
            {
                _musicGenreManager.DeleteMusicGenre(User.GetUserId(), genre);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
