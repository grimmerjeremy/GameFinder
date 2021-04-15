using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameCreate
    {
        public string Name { get; set; }

        public int GenreId { get; set; }

        public int ConsoleId { get; set; }
        public double GameRating { get; set; }
    }
}
