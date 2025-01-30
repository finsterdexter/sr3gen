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

        public DicePool(DicePoolType type)
        {
            Type = type;
        }

        public int GetAugmentedValue(Character character)
        {
            int modValue = 0;

            // check gear mods
            foreach (var mod in character.Gear.Values.Where(g => g.Mods != null).SelectMany(g => g.Mods.Where(m => m is DicePoolMod d && d.DicePoolType == Type)))
            {
                modValue += mod.ModValue;
            }

            // check natural augmentations
            foreach (var mod in character.NaturalAugmentations.Values.Where(g => g.Mods != null).SelectMany(g => g.Mods.Where(m => m is DicePoolMod d && d.DicePoolType == Type)))
            {
                modValue += mod.ModValue;
            }

            return Value + modValue;
        }
    }

    public enum DicePoolType
    {
        Karma,
        Combat,
        Control,
        Hacking,
        Spell,
        AstralCombat,
        Task
    }
}
