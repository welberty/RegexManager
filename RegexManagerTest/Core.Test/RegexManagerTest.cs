using Xunit;
using RegexManagerCore;
using System.Text.RegularExpressions;

namespace RegexManagerTest.Core.Test
{
    public class RegexManagerTest
    {
        [Fact]
        public void Match_True(){

            var manager = new RegexManager<bool>(() => { Assert.True(false); });
            var IsMatched = manager
                        .AddRegex(new RegexExecute<bool>("[0-9]", (m) => { return m.Success; }))
                        .AddRegex(new RegexExecute<bool>("[a-z]", (m) => { return m.Success; }))
                        .Run("7");
            Assert.True(IsMatched);
        }

        [Fact]
        public void Match_False()
        {

            var manager = new RegexManager<bool>(() => { Assert.False(false); });
            var IsMatched = manager
                        .AddRegex(new RegexExecute<bool>("[0-9]", (m) => { return m.Success; }))
                        .AddRegex(new RegexExecute<bool>("[a-z]", (m) => { return m.Success; }))
                        .Run("-");
            Assert.False(IsMatched);
        }

        [Fact]
        public void Match_True_And_Equals_Value()
        {
            var testValue = "7";

            RegexManager<Match> manager = new RegexManager<Match>(() => { Assert.True(false); });
            var match = manager
                    .AddRegex(new RegexExecute<Match>("[0-9]", (m) => { return m; }))
                    .AddRegex(new RegexExecute<Match>("[a-z]", (m) => { return m; }))
                    .Run(testValue);
            Assert.True(match.Success);
            Assert.Equal(testValue, match.Value);
        }
    }
}
