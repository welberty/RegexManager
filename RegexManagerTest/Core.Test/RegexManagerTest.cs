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
            var match = manager
                        .AddRegex(new RegexExecute<bool>("[0-9]", (m) => { return m.Success; }))
                        .AddRegex(new RegexExecute<bool>("[a-z]", (m) => { return m.Success; }))
                        .Run("7");
            Assert.True(match);
        }

        [Fact]
        public void Match_False()
        {

            var manager = new RegexManager<bool>(() => { Assert.False(false); });
            var match = manager
                        .AddRegex(new RegexExecute<bool>("[0-9]", (m) => { return m.Success; }))
                        .AddRegex(new RegexExecute<bool>("[a-z]", (m) => { return m.Success; }))
                        .Run("-");
            Assert.False(match);
        }

        [Fact]
        public void Match_True_And_Equals_Value()
        {
            var testValue = "7";

            RegexManager<Match> manager = new RegexManager<Match>(() => { Assert.True(false); });
            var m2 = manager
                    .AddRegex(new RegexExecute<Match>("[0-9]", (m) => { return m; }))
                    .AddRegex(new RegexExecute<Match>("[a-z]", (m) => { return m; }))
                    .Run(testValue);
            Assert.True(m2.Success);
            Assert.Equal(testValue, m2.Value);
        }
    }
}
