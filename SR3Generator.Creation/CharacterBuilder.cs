using SR3Generator.Creation.Validation;
using SR3Generator.Data.Character;
using SR3Generator.Data.Character.Creation;
using SR3Generator.Data.Gear;
using Attribute = SR3Generator.Data.Character.Attribute;

namespace SR3Generator.Creation
{
    public class CharacterBuilder
    {
        private CharacterValidator _characterValidator = new CharacterValidator();
        private int AttributePointsAllowance = 0;
        private int SkillPointsAllowance = 0;
        private int ResourcesAllowance = 0;
        private List<Race> AllowedRaces = new List<Race>() { RaceDatabase.PlayerRaces.First(r => r.Name == RaceName.Human) };

        public Character Character { get; set; }
        public List<ValidationIssue> ValidationIssues { get; set; } = new List<ValidationIssue>();

        public CharacterBuilder()
        {
            Character = new Character();
        }

        public CharacterBuilder WithPriorities(List<Priority> priorities)
        {

            return this;
        }

        public CharacterBuilder WithRace(Race race)
        {
            Character.Race = race;
            foreach (var (name, att) in Character.Attributes)
            {
                att.RaceModValue = 0;
            }
            foreach (var attMod in race.AttributeMods)
            {
                Character.Attributes[attMod.AttributeName].RaceModValue += attMod.ModValue;
            }

            // manage troll dermal armor
            if (race.Name == RaceName.Troll)
            {
                Character.Gear.Add(new Augmentation
                {
                    Name = "Dermal Armor",
                    CategoryTree = new List<string> { "BODYWARE", "Dermal Plating/Sheath/Ruthenium" },
                    Availability = null,
                    Book = "sr3",
                    Page = 56,
                    Notes = "Natural Troll Dermal Armor",
                    Rating = 1,
                    Mods = new List<Mod>
                    {
                        new AttributeMod
                        {
                            AttributeName = AttributeName.Body,
                            ModValue = 1
                        }
                    }
                });
            }
            else
            {
                Character.Gear.RemoveAll(g => g.Name == "Dermal Armor");
            }

            return this;
        }

        public CharacterBuilder WithAttribute(Attribute attribute)
        {
            Character.Attributes[attribute.Name] = attribute;
            return this;
        }

        // TODO: split this out into different types of gear, like cyberware, foci, etc.?
        public CharacterBuilder AddGear(Equipment item)
        {
            Character.Gear.Add(Guid.NewGuid(), item);

            // process gear mods
            if (item is Augmentation)
            {
                var aug = item as Augmentation;
                foreach (var mod in aug.Mods)
                {
                    if (mod is AttributeMod)
                    {
                        var attMod = mod as AttributeMod;
                        Character.Attributes[attMod.AttributeName].AugmentedModValue += attMod.ModValue;
                    }
                    if (mod is SkillMod)
                    {
                        var skillMod = mod as SkillMod;
                        if (Character.ActiveSkills.ContainsKey(skillMod.SkillName))
                        {
                            Character.ActiveSkills[skillMod.SkillName].AugmentedModValue += skillMod.ModValue;
                        }
                        else if (Character.KnowledgeSkills.ContainsKey(skillMod.SkillName))
                        {
                            Character.KnowledgeSkills[skillMod.SkillName].AugmentedModValue += skillMod.ModValue;
                        }
                    }
                    // TODO: add other mod types
                }
            }

            return this;
        }
        public CharacterBuilder RemoveGear(Guid equipmentId)
        {
            if (Character.Gear.TryGetValue(equipmentId, out var item) == false)
            {
                return this;
            }

            // process gear mods
            if (item is Augmentation)
            {
                var aug = item as Augmentation;
                foreach (var mod in aug.Mods)
                {
                    if (mod is AttributeMod)
                    {
                        var attMod = mod as AttributeMod;
                        Character.Attributes[attMod.AttributeName].AugmentedModValue -= attMod.ModValue;
                    }
                    if (mod is SkillMod)
                    {
                        var skillMod = mod as SkillMod;
                        if (Character.ActiveSkills.ContainsKey(skillMod.SkillName))
                        {
                            Character.ActiveSkills[skillMod.SkillName].AugmentedModValue -= skillMod.ModValue;
                        }
                        else if (Character.KnowledgeSkills.ContainsKey(skillMod.SkillName))
                        {
                            Character.KnowledgeSkills[skillMod.SkillName].AugmentedModValue -= skillMod.ModValue;
                        }
                    }
                }
            }

            Character.Gear.Remove(equipmentId);
            return this;
        }

        public CharacterBuilder AddNaturalAugmentation(Augmentation item)
        {
            Character.NaturalAugmentations.Add(item.Name, item);
            foreach (var mod in item.Mods)
            {
                if (mod is AttributeMod)
                {
                    var attMod = mod as AttributeMod;
                    Character.Attributes[attMod.AttributeName].AugmentedModValue += attMod.ModValue;
                }
            }
            return this;
        }

        public CharacterBuilder RemoveNaturalAugmentation(string name)
        {
            if (Character.NaturalAugmentations.TryGetValue(name, out var item) == false)
            {
                return this;
            }

            foreach (var mod in item.Mods)
            {
                if (mod is AttributeMod)
                {
                    var attMod = mod as AttributeMod;
                    Character.Attributes[attMod.AttributeName].AugmentedModValue -= attMod.ModValue;
                }
            }

            Character.NaturalAugmentations.Remove(name);
            return this;
        }

        public CharacterBuilder AddActiveSkill(Skill skill)
        {
            Character.ActiveSkills.Add(skill.Name, skill);
            return this;
        }

        public Character Build()
        {
            return Character;
        }
    }
}