using SR3Generator.Data.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Creation
{
    internal static class SkillDatabase
    {
        public static Dictionary<string, Skill> ActiveSkills { get; set; } = new Dictionary<string, Skill>();
        public static Dictionary<string, Skill> KnowledgeSkills { get; set; } = new Dictionary<string, Skill>();

        static SkillDatabase()
        {
            // TODO: preload skill data from json

            // validate data: all specializations must have a base skill name
        }
    }
}
