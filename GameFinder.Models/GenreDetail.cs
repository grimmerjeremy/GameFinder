using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GenreDetail
    {
        public string Name { get; set; }

        public List<string> GameNames { get; set; } = new List<string>();
    }
}
