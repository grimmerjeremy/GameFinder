using GameFinder.Data;
using GameFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GameFinder.Services
{
    public class GameConsoleService
    {

        public bool CreateGameConsole(GameConsoleCreate console)
        {
            var entity = new GameConsole()
            {
                ConsoleId = console.ConsoleId,
                ConsoleName = console.ConsoleName

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameConsoles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameConsoleList> GetConsoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameConsoles
                    .Select(
                        e => new GameConsoleList
                        {
                            ConsoleName = e.ConsoleName
                        }
                    );

                return query.ToArray();
            }
        }

        public GameConsoleDetail GetConsoleByConsoleId(int consoleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameConsoles.Include(e => e.GamesOnConsole).Single(e => consoleId == e.ConsoleId);

                var namesOfGamesOnConsole = new List<string>();
                foreach (var game in entity.GamesOnConsole)
                {
                    namesOfGamesOnConsole.Add(game.Name);
                }

                return new GameConsoleDetail()
                {
                    ConsoleName = entity.ConsoleName,
                    GameNames = namesOfGamesOnConsole
                };
            }
        }

        public bool UpdateConsole(GameConsoleUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameConsoles.Single(e => e.ConsoleId == model.ConsoleId);

                entity.ConsoleName = model.ConsoleName;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteConsole(string consoleName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameConsoles.Single(e => e.ConsoleName == consoleName);
                ctx.GameConsoles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }






    }
}
