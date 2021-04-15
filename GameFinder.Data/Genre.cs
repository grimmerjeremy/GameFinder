using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage ="Genre Name is too long")]
        public string  Name { get; set; }
        public virtual List<Game> GamesInGenre { get; set; } = new List<Game>();
    }
}
