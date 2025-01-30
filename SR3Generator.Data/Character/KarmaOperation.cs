using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Character
{
    public class KarmaOperation
    {
        public KarmaOperationType Type { get; set; }
        public int KarmaChangeValue { get; set; }
        public string? Description { get; set; }
    }

    public enum KarmaOperationType
    {
        Gain,
        Spend,
        ConvertToNuyen,
        ConvertFromNuyen
    }
}
