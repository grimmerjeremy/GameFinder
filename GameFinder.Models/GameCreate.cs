using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Game name is too long")]
        public string Name { get; set; }

        public int GenreId { get; set; }

        public int ConsoleId { get; set; }

        [Required]
        public double GameRating { get; set; }

        [Required]
        public int ExpectedPlayTime { get; set; }
    }
}
