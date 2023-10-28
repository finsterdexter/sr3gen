using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Character
{
    public class Race
    {
        public RaceName Name { get; set; }
        // attribute mods
        public List<AttributeMod> AttributeMods { get; set; } = new List<AttributeMod>();
        // extras
        public List<string> Extras { get; set; } = new List<string>();
    }

    public enum RaceName
    {
        Human,
        Dwarf,
        Elf,
        Ork,
        Troll
    }
}
