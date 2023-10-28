using SR3Generator.Data.Gear;

namespace SR3Generator.Data.Character
{
    public class Character
    {
        public string PlayerName { get; set; } = string.Empty;
        public Race Race { get; set; }
        public Identity Identity { get; set; } = new Identity();
        public List<Lifestyle> Lifestyles { get; set; } = new List<Lifestyle>();
        public Dictionary<AttributeName, Attribute> Attributes { get; set; }
        public Dictionary<string, Skill> ActiveSkills { get; set; } = new Dictionary<string, Skill>();
        public Dictionary<string, Skill> KnowledgeSkills { get; set; } = new Dictionary<string, Skill>();
        public Dictionary<Guid, Weapon> Weapons { get; set; } = new Dictionary<Guid, Weapon>();
        public Dictionary<Guid, Armor> ArmorClothing { get; set; } = new Dictionary<Guid, Armor>();
        public Dictionary<Guid, Equipment> Gear { get; set; } = new Dictionary<Guid, Equipment>();
        public Dictionary<string, Augmentation> NaturalAugmentations { get; set; } = new Dictionary<string, Augmentation>();

        // Cyberdecks/Programs

        // Magical Data
        //     Spells
        //     Adept Powers
        //     Bonded Spirits
        //         Watchers
        //         Ally Spirit
        // Foci
        // Vehicles
        // Contacts

        public Character()
        {
            Attributes = new Dictionary<AttributeName, Attribute>
            {
                { AttributeName.Body, new Attribute { Name = AttributeName.Body, BaseValue = 1, Type = AttributeType.Physical } },
                { AttributeName.Quickness, new Attribute { Name = AttributeName.Quickness, BaseValue = 1, Type = AttributeType.Physical } },
                { AttributeName.Strength, new Attribute { Name = AttributeName.Strength, BaseValue = 1, Type = AttributeType.Physical } },

                { AttributeName.Charisma, new Attribute { Name = AttributeName.Charisma, BaseValue = 1, Type = AttributeType.Mental } },
                { AttributeName.Intelligence, new Attribute { Name = AttributeName.Intelligence, BaseValue = 1, Type = AttributeType.Mental } },
                { AttributeName.Willpower, new Attribute { Name = AttributeName.Willpower, BaseValue = 1, Type = AttributeType.Mental } },

                { AttributeName.Essence, new Attribute { Name = AttributeName.Essence, BaseValue = 6, Type = AttributeType.Special } },
                { AttributeName.Magic, new Attribute { Name = AttributeName.Magic, BaseValue = 0, Type = AttributeType.Special } },
                { AttributeName.Reaction, new Attribute { Name = AttributeName.Reaction, BaseValue = 1, Type = AttributeType.Combat } },
                { AttributeName.Initiative, new Attribute { Name = AttributeName.Initiative, BaseValue = 1, Type = AttributeType.Combat } },
            };
        }
    }
}