using GameFinder.Data;
using GameFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GameServices
    {

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameList> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Select(
                            e =>
                                new GameList
                                {
                                    Id = e.Id,
                                    Name = e.Name
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
                        .Select(e =>
                             new GameList
                             {
                                 Id = e.Id,
                                 Name = e.Name
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