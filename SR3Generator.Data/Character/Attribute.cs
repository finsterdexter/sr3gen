using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Data.Character
{
    public class Attribute
    {
        public AttributeName Name { get; set; }
        public AttributeType Type { get; set; }
        public int BaseValue { get; set; }
        public bool Stressed { get; set; }

        public int GetAugmentedValue(Character character)
        {
            int modValue = 0;

            // check gear mods
            foreach (var mod in character.Gear.Values.Where(g => g.Mods != null).SelectMany(g => g.Mods.Where(m => m is AttributeMod a && a.AttributeName == Name)))
            {
                modValue += mod.ModValue;
            }

            // check natural mods
            foreach (var mod in character.NaturalAugmentations.Values.Where(g => g.Mods != null).SelectMany(g => g.Mods.Where(m => m is AttributeMod a && a.AttributeName == Name)))
            {
                modValue += mod.ModValue;
            }

            return BaseValue + modValue;
        }

        public AttributeAbbr Abbr
        {
            get
            {
                return GetAbbr(Name);
            }
        }

        public static AttributeAbbr GetAbbr(AttributeName name)
        {
            switch (name)
            {
                case AttributeName.Body:
                    return AttributeAbbr.BOD;
                case AttributeName.Quickness:
                    return AttributeAbbr.QCK;
                case AttributeName.Strength:
                    return AttributeAbbr.STR;
                case AttributeName.Willpower:
                    return AttributeAbbr.WIL;
                case AttributeName.Intelligence:
                    return AttributeAbbr.INT;
                case AttributeName.Charisma:
                    return AttributeAbbr.CHA;
                case AttributeName.Initiative:
                    return AttributeAbbr.INI;
                case AttributeName.Reaction:
                    return AttributeAbbr.REA;
                case AttributeName.Essence:
                    return AttributeAbbr.ESS;
                case AttributeName.BioIndex:
                    return AttributeAbbr.BioIndex;
                case AttributeName.Magic:
                    return AttributeAbbr.MAG;
                default:
                    return AttributeAbbr.BOD;
            }
        }
    }

    public enum AttributeType
    {
        Physical,
        Mental,
        Combat,
        Special
    }

    public enum AttributeName
    {
        Body,
        Quickness,
        Strength,
        Willpower,
        Intelligence,
        Charisma,
        Initiative,
        Reaction,
        Essence,
        BioIndex,
        Magic
    }

    public enum AttributeAbbr
    {
        BOD,
        QCK,
        STR,
        WIL,
        INT,
        CHA,
        INI,
        REA,
        ESS,
        BioIndex,
        MAG
    }



}
