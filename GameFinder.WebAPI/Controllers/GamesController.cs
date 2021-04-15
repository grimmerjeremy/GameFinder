using GameFinder.Models;
using GameFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameFinder.WebAPI.Controllers
{
    [Authorize]
    public class GamesController : ApiController
    {
        private readonly GameServices gameServices = new GameServices();
        public IHttpActionResult Get()
        {
            var games = gameServices.GetGames();
            var gamesAlphabetical = games.OrderBy(x => x.Name);

            return Ok(gamesAlphabetical);
        }

        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!gameServices.CreateGame(game))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int maxPlayTime, int minPlayTime)
        {
            var GamesByPlayTime = gameServices.GetGamesByPlayTime(maxPlayTime, minPlayTime);

            return Ok(GamesByPlayTime);
        }

        public IHttpActionResult Put(GameUpdate game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!gameServices.UpdateGame(game))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int Id)
        {

            if (!gameServices.DeleteGame(Id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}