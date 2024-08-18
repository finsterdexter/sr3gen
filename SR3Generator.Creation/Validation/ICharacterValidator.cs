namespace SR3Generator.Creation.Validation
{
    internal interface ICharacterValidator
    {
        (bool isValid, List<ValidationIssue> issues) Validate(CharacterBuilder builder);
    }

    internal abstract class CharacterValidatorBase : ICharacterValidator
    {
        public List<ValidationIssue> Issues { get; set; } = new List<ValidationIssue>();

        public abstract (bool isValid, List<ValidationIssue> issues) Validate(CharacterBuilder builder);

        public (bool isValid, List<ValidationIssue> issues) IssueCheck()
        {
            if (Issues.Any(vi => vi.Level == ValidationIssueLevel.Error))
            {
                return (false, Issues);
            }
            else
            {
                return (true, Issues);
            }
        }

    }
}