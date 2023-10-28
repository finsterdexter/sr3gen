using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Character
{
    public class DicePool
    {
        public DicePoolType Type { get; set; }
        public int Value { get; set; }
    }

    public enum DicePoolType
    {
        Combat,
        Control,
        Hacking,
        Spell,
        AstralCombat,
        Task
    }
}
