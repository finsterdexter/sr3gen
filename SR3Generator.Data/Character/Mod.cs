using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Character
{
    public abstract class Mod
    {
        public int ModValue { get; set; }
    }

    public class SkillMod : Mod
    {
        public string SkillName { get; set; }

        public SkillMod(string skillName, int modValue)
        {
            SkillName = skillName;
            ModValue = modValue;
        }

    }

    public class AttributeMod : Mod
    {
        public AttributeName AttributeName { get; set; }

        public AttributeMod(AttributeName attributeName, int modValue)
        {
            AttributeName = attributeName;
            ModValue = modValue;
        }
    }

    public class DicePoolMod : Mod
    {
        public DicePoolType DicePoolType { get; set; }

        public DicePoolMod(DicePoolType dicePoolType, int modValue)
        {
            DicePoolType = dicePoolType;
            ModValue = modValue;
        }
    }
}
