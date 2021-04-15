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
    public class GameServices
    {

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    Name = model.Name,
                    GenreId = model.GenreId,
                    ConsoleId = model.ConsoleId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                var genreEntity = ctx.Genres.Find(model.GenreId);
                var consoleEntity = ctx.GameConsoles.Find(model.ConsoleId);

                genreEntity.GamesInGenre.Add(entity);
                consoleEntity.GamesOnConsole.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameList> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games.Include(e => e.Console).Include(e => e.Genre)
                        .Select(
                            e =>
                                new GameList
                                {
                                    Name = e.Name,
                                    Id = e.Id,
                                    GenreName = e.Genre.Name,
                                    ConsoleName = e.Console.ConsoleName
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<GameList> GetGamesByPlayTime(int high, int low)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e =>
                               e.Playtime >= low && e.Playtime <= high)
                        .Include(e => e.Console).Include(e => e.Genre)
                        .Select(e =>
                             new GameList
                             {
                                 Id = e.Id,
                                 Name = e.Name,
                                 GenreName = e.Genre.Name,
                                 ConsoleName = e.Console.ConsoleName
                             });
                
                return query.ToArray();
            }
        }

        public IEnumerable<GameList> GetGamesByGameRating(double minRating, double maxRating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e =>
                               e.GameRating <= minRating && e.GameRating >= maxRating)
                        .Include(e => e.Console).Include(e => e.Genre)
                        .Select(e =>
                             new GameList
                             {
                                 Id = e.Id,
                                 Name = e.Name,
                                 GenreName = e.Genre.Name,
                                 ConsoleName = e.Console.ConsoleName,
                                 GameRating = e.GameRating

                             });

                return query.ToArray();
            }
        }

        public bool UpdateGame(GameUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(e => e.Id == model.Id);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(e => e.Id == Id);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}