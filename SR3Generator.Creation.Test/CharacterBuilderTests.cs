using SR3Generator.Data.Character;

namespace SR3Generator.Creation.Test
{
    public class CharacterBuilderTests
    {
        // AwardKarma
        [Theory]
        [InlineData(5, 0, 10, 14, 1)]
        public void AwardKarma_ShouldHaveCorrectAmountsInKarmaPool(int totalKarma, int spentKarma, int awardedKarma, int newRemainingKarma, int newKarmaPool)
        {
            var builder = new CharacterBuilder();
            var character = builder.Build();
            character.TotalKarma = totalKarma;
            character.SpentKarma = spentKarma;

            builder.AwardKarma(awardedKarma);

            Assert.Equal(totalKarma + awardedKarma, character.TotalKarma);
            Assert.Equal(newRemainingKarma, character.RemainingKarma);
            Assert.Equal(newKarmaPool, character.DicePools[DicePoolType.Karma].Value);
            Assert.Single(character.KarmaOperations);
        }
    }
}