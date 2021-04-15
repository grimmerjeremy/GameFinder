using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameList
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string GenreName { get; set; }
        public string ConsoleName { get; set; }
        public double GameRating { get; set; }
        public double ExpectedPlayTime { get; set; }
    }
}
