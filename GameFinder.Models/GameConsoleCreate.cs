using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameConsoleCreate
    {
        [Key]
        public int ConsoleId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Console name is too long")]
        public string ConsoleName { get; set; }
    }
}
