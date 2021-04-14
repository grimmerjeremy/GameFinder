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
            return Ok(games);
        }

        public IHttpActionResult Game(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!gameServices.CreateGame(game))
                return InternalServerError();

            return Ok();
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