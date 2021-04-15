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
    public class GameConsoleController : ApiController
    {
        private readonly GameConsoleService service = new GameConsoleService();

        public IHttpActionResult Post(GameConsoleCreate console)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!service.CreateGameConsole(console))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Get()
        {
            var console = service.GetConsoles();
            return Ok(console);
        }

        public IHttpActionResult Put(GameConsoleUpdate consoleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!service.UpdateConsole(consoleId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(string consoleName)
        {

            if (!service.DeleteConsole(consoleName))
            {
                return InternalServerError();
            }

            return Ok();
        }

    }
}
