using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Gear
{
    public class Program : Equipment
    {
        public int Multiplier { get; set; }

        public int Size
        {
            get
            {
                if (Rating == null)
                    return 0;
                else
                    return Rating.Value ^ 2 * Multiplier;
            }
        }

        public ProgramType ProgramType { get; set; }

        public bool HasSourceCode { get; set; }

    }

    public enum ProgramType
    {
        OperationalUtility,
        SpecialUtility,
        OffensiveUtility,
        DefensiveUtility,
    }
}
