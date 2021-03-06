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

            if (game.GameRating >= 0 && game.GameRating <= 10)
            {
                if (!gameServices.CreateGame(game))
                    return InternalServerError();

                return Ok();
            }

            return BadRequest();
        }

        public IHttpActionResult Get(double minRating, double maxRating)
        {
            if (minRating <= maxRating && minRating >= 0 && maxRating <= 10)
            {
                var GamesByGameRating = gameServices.GetGamesByGameRating(minRating, maxRating);

                var GamesByRatingDescending = GamesByGameRating.OrderByDescending(e => e.GameRating);

                return Ok(GamesByRatingDescending);
            }

            return BadRequest();
        }

        public IHttpActionResult Get(int maxPlayTime, int minPlayTime)
        {
            if (maxPlayTime >= minPlayTime && maxPlayTime > 0 && minPlayTime > 0)
            {
                var GamesByPlayTime = gameServices.GetGamesByPlayTime(maxPlayTime, minPlayTime);
                return Ok(GamesByPlayTime);
            }

            return BadRequest();
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