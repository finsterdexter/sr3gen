using SR3Generator.Data.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Creation.Validation
{
    internal class CharacterValidator
    {
        public List<ValidationIssue> Issues { get; set; }

        public (bool isValid, List<ValidationIssue> issues) Validate(Character character)
        {
            ValidateAttributes(character);
        }

        public CharacterValidator ValidateAttributes(Character character)
        {
            // basic validation
            if (character.Attributes.Count != 10
                || !character.Attributes.ContainsKey(AttributeName.Body)
                || !character.Attributes.ContainsKey(AttributeName.Quickness)
                || !character.Attributes.ContainsKey(AttributeName.Strength)
                || !character.Attributes.ContainsKey(AttributeName.Charisma)
                || !character.Attributes.ContainsKey(AttributeName.Intelligence)
                || !character.Attributes.ContainsKey(AttributeName.Willpower)
                || !character.Attributes.ContainsKey(AttributeName.Reaction)
                || !character.Attributes.ContainsKey(AttributeName.Magic)
                || !character.Attributes.ContainsKey(AttributeName.Initiative)
                || !character.Attributes.ContainsKey(AttributeName.Essence)
                )
            {
                Issues.Add(new ValidationIssue { Category = ValidationIssueCategory.Attributes, Level = ValidationIssueLevel.Error, Message = "Character must have 10 attributes: Body, Quickness, Strength, Charisma, Intelligence, Willpower, Reaction, Magic, Initiative, and Essence." });
            }

            foreach (var (name, att) in character.Attributes)
            {
                if (name == AttributeName.Magic && att.Natural < 0 || att.Natural > 6)
                {
                    Issues.Add(new ValidationIssue { Category = ValidationIssueCategory.Attributes, Level = ValidationIssueLevel.Error, Message = "Magic must have a value between 0 and 6." });
                }
                else if (name == AttributeName.Essence && att.Natural < 0 || att.Natural > 6)
                {
                    Issues.Add(new ValidationIssue { Category = ValidationIssueCategory.Attributes, Level = ValidationIssueLevel.Error, Message = "Essence must have a value between 0 and 6." });
                }

                if (att.Type != AttributeType.Physical && att.Type != AttributeType.Mental)
                {
                    // don't need to validate Reaction or Initiative
                    continue;
                }
                if (att.Natural < 1 || att.Natural > 6)
                {
                    Issues.Add(new ValidationIssue { Category = ValidationIssueCategory.Attributes, Level = ValidationIssueLevel.Error, Message = $"Attribute {name} must have a natural value between 1 and 6." });
                }
            }

            return this;
        }
    }
}
