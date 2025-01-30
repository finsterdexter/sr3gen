using SR3Generator.Data.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Gear
{
    public class Augmentation : Equipment
    {
        public List<Mod> Mods { get; set; } = new List<Mod>();
    }
}
