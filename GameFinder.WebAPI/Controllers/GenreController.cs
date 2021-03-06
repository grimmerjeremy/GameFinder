using GameFinder.Models;
using GameFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameFinder.WebAPI.Controllers
{
    [Authorize]
    public class GenreController : ApiController
    {
        private readonly GenreService _service = new GenreService();

        public IHttpActionResult Post(GenreCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_service.CreateGenre(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Get()
        {
            var genres = _service.GetAllGenres();

            return Ok(genres);
        }

        public IHttpActionResult Get(int genreId)
        {
            var genre = _service.GetGenreByGenreId(genreId);

            return Ok(genre);
        }

        public IHttpActionResult Put(GenreUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_service.UpdateGenre(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int genreId)
        {
            if (!_service.DeleteGenre(genreId))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
