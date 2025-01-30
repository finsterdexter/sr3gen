using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Gear
{
    public class RocketMissile : Weapon
    {
        public int? Intelligence { get; set; }
        public Blast? Blast { get; set; }
        public decimal? Scatter { get; set; }
        
    }
}
