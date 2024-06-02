using SR3Generator.Creation.Validation;
using SR3Generator.Data.Character;
using SR3Generator.Data.Character.Creation;
using SR3Generator.Data.Gear;
using Attribute = SR3Generator.Data.Character.Attribute;

namespace SR3Generator.Creation
{
    public class CharacterBuilder
    {
        private CharacterPriorityValidator _characterValidator = new CharacterPriorityValidator();

        public Character Character { get; set; }
        public List<ValidationIssue> ValidationIssues { get; set; } = new List<ValidationIssue>();
        public int AttributePointsAllowance { get; set; }
        public int SkillPointsAllowance { get; set; }
        public int ResourcesAllowance { get; set; }
        public List<Race> RacesAllowed { get; set; }
        public List<MagicAspect> MagicAspectsAllowed { get; set; }

        public CharacterBuilder()
        {
            Character = new Character();
            var initialPriorities = new List<Priority>
            {
                new Priority(PriorityType.Race, PriorityRank.A),
                new Priority(PriorityType.Magic, PriorityRank.B),
                new Priority(PriorityType.Attributes, PriorityRank.C),
                new Priority(PriorityType.Skills, PriorityRank.D),
                new Priority(PriorityType.Resources, PriorityRank.E)
            };
            this.WithPriorities(initialPriorities);
        }

        public CharacterBuilder WithPriorities(List<Priority> priorities)
        {
            foreach (var priority in priorities)
            {
                if (priority.Type == PriorityType.Attributes)
                {
                    AttributePointsAllowance = priority.GetAttributePoints();
                }
                else if (priority.Type == PriorityType.Skills)
                {
                    SkillPointsAllowance = priority.GetSkillPoints();
                }
                else if (priority.Type == PriorityType.Resources)
                {
                    ResourcesAllowance = priority.GetNuyen();
                }
                else if (priority.Type == PriorityType.Race)
                {
                    RacesAllowed = priority.GetAllowedRaces();
                }
                else if (priority.Type == PriorityType.Magic)
                {
                    MagicAspectsAllowed = priority.GetAllowedMagicAspects();
                }
            }
            return this;
        }

        public CharacterBuilder WithRace(Race race)
        {
            Character.Race = race;

            // manage troll dermal armor
            if (race.Name == RaceName.Troll)
            {
                var dermalArmor = new Augmentation
                {
                    Name = "Dermal Armor",
                    CategoryTree = new List<string> { "BODYWARE", "Dermal Plating/Sheath/Ruthenium" },
                    Book = "sr3",
                    Page = 56,
                    Notes = "Natural Troll Dermal Armor",
                    Rating = 1,
                    Mods = new List<Mod>
                    {
                        new AttributeMod(AttributeName.Body, 1)
                    }
                };
                this.AddNaturalAugmentation(dermalArmor);
            }
            else
            {
                this.RemoveNaturalAugmentation("Dermal Armor");
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
            return this;
        }
        public CharacterBuilder RemoveGear(Guid equipmentId)
        {
            if (Character.Gear.TryGetValue(equipmentId, out var item) == false)
            {
                return this;
            }
            Character.Gear.Remove(equipmentId);
            return this;
        }
        public CharacterBuilder AddNuyen(long nuyen)
        {
            Character.Nuyen += nuyen;
            return this;
        }
        public CharacterBuilder RemoveNuyen(long nuyen)
        {
            Character.Nuyen -= nuyen;
            return this;
        }
        public CharacterBuilder BuyGear(Equipment item, bool useStreetIndex = false)
        {
            var costm = item.Cost * (useStreetIndex ? item.StreetIndex : 1);
            long cost = (long)Math.Round(costm, MidpointRounding.AwayFromZero);

            RemoveNuyen(cost).AddGear(item);
            return this;
        }
        public CharacterBuilder SellGear(Guid equipmentId, bool useStreetIndex = false)
        {
            if (Character.Gear.TryGetValue(equipmentId, out var item) == false)
            {
                return this;
            }
            var costm = item.Cost * (useStreetIndex ? item.StreetIndex : 1);
            long cost = (long)Math.Round(costm, MidpointRounding.AwayFromZero);

            AddNuyen(cost).RemoveGear(equipmentId);
            return this;
        }

        public CharacterBuilder AddNaturalAugmentation(Augmentation item)
        {
            Character.NaturalAugmentations.Add(item.Name, item);
            return this;
        }
        public CharacterBuilder RemoveNaturalAugmentation(string name)
        {
            if (Character.NaturalAugmentations.TryGetValue(name, out var item) == false)
            {
                return this;
            }
            Character.NaturalAugmentations.Remove(name);
            return this;
        }

        public CharacterBuilder AddActiveSkill(Skill skill)
        {
            Character.ActiveSkills.Add(skill.Name, skill);
            return this;
        }
        public CharacterBuilder RemoveActiveSkill(string name)
        {
            Character.ActiveSkills.Remove(name);
            return this;
        }

        public CharacterBuilder AddKnowledgeSkill(Skill skill)
        {
            Character.KnowledgeSkills.Add(skill.Name, skill);
            return this;
        }
        public CharacterBuilder RemoveKnowledgeSkill(string name)
        {
            Character.KnowledgeSkills.Remove(name);
            return this;
        }

        public Character Build()
        {
            return Character;
        }
    }
}