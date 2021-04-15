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
    public class GenreService
    {
        public bool CreateGenre(GenreCreate model) 
        {
            var entity = new Genre()
            {
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GenreList> GetAllGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Genres.Select(e => new GenreList
                {
                    Name = e.Name
                }
                );

                return query.ToArray();
            }
        }

        // This was completed in ticket 4 but was supposed to be in ticket 11, repushing
        public GenreDetail GetGenreByGenreId(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Include(e => e.GamesInGenre).Single(e => genreId == e.Id);

                var namesOfGamesInGenre = new List<string>();
                foreach (var game in entity.GamesInGenre)
                {
                    namesOfGamesInGenre.Add(game.Name);
                }

                return new GenreDetail()
                {
                    Name = entity.Name,
                    GameNames = namesOfGamesInGenre
                };
            }
        }

        public bool UpdateGenre(GenreUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Single(e => e.Id == model.Id);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Single(e => e.Id == genreId);

                ctx.Genres.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
