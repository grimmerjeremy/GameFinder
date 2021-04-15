using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class GameConsole
    {
        [Key]
        public int ConsoleId { get; set; }
        [Required]
        public string ConsoleName { get; set; }
        public virtual List<Game> GamesOnConsole { get; set; } = new List<Game>();
    }
}
