using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Character
{
    public class Skill
    {
        public string Name { get; set; }
        public string Attribute { get; set; }
        public int BaseValue { get; set; }
        public string? Specialization { get; set; }
        public int AugmentedModValue { get; set; }

        public int Rating
        {
            get
            {
                return BaseValue + AugmentedModValue;
            }
        }
    }
}
