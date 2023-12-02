namespace SR3Generator.Creation.Validation
{
    internal interface ICharacterValidator
    {
        (bool isValid, List<ValidationIssue> issues) Validate(CharacterBuilder builder);
        CharacterPriorityValidator ValidateAttributes(CharacterBuilder builder);
        CharacterPriorityValidator ValidateMagicAspect(CharacterBuilder builder);
        CharacterPriorityValidator ValidateRace(CharacterBuilder builder);
    }
}