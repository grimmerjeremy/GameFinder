using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameConsoleDetail
    {
        public string ConsoleName { get; set; }

        public List<string> GameNames { get; set; } = new List<string>();
    }
}
