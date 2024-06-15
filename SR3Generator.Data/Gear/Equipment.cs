using SR3Generator.Data.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Gear
{
    public class Equipment
    {
        public string Name { get; set; }
        public List<string> CategoryTree { get; set; }
        public decimal Weight { get; set; }
        public Availability Availability { get; set; }
        public int Cost { get; set; }
        public decimal StreetIndex { get; set; }
        public string Book { get; set; }
        public int Page { get; set; }
        public string Legality { get; set; }
        public string Notes { get; set; }
        public int? Rating { get; set; }
        public List<Mod> Mods { get; set; } = new List<Mod>();
        public bool IsEquipped { get; set; }
    }
}
