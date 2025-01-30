using SR3Generator.Data.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Magic
{
    public class AdeptPower
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public List<Mod> Mods { get; set; }
        public string Notes { get; set; }
        public string Book { get; set; }
        public int Page { get; set; }
    }
}
