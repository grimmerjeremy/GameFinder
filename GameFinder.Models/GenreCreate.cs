using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GenreCreate
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Genre name is too long")]
        public string Name { get; set; }
    }
}
