using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Gear
{
    public class Weapon : Equipment
    {
        public string Skill { get; set; }
        public int Concealability { get; set; }
        public string Damage { get; set; }
    }
}
