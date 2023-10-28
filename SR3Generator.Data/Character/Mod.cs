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

        public abstract void Apply(Character character);
    }

    public class SkillMod : Mod
    {
        public string SkillName { get; set; }

        public override void Apply(Character character)
        {
            var skill = character.ActiveSkills.First(s => s.Name == SkillName);
            if (skill == null) skill = character.KnowledgeSkills.First(s => s.Name == SkillName);
            if (skill != null)
            {
                skill.AugmentedModValue += ModValue;
            }
        }
    }

    public class AttributeMod : Mod
    {
        public AttributeName AttributeName { get; set; }
    }
}
