using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [ForeignKey(nameof(GameConsole))]
        public int ConsoleId { get; set; }

        public virtual GameConsole Console { get; set; }

        [Required]
        public int Playtime { get; set; }
        [Required]
        public double GameRating { get; set; }
    }
}
