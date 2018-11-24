using Xunit;
using RegexManagerCore;

namespace RegexManagerTest.Core.Test
{
    public class RegexManagerTest
    {
        [Fact]
        public void Match_True(){

            RegexManager manager = new RegexManager((m) => { Assert.True(m.Success); });
            manager
                .AddRegex(new RegexExecute("[0-9]", (m) => { Assert.True(m.Success); }))
                .AddRegex(new RegexExecute("[a-z]", (m) => { Assert.True(m.Success); }))
                .Run("7");
        }

        [Fact]
        public void Match_False()
        {

            RegexManager manager = new RegexManager((m) => { Assert.False(m.Success); });
            manager
                .AddRegex(new RegexExecute("[0-9]", (m) => { Assert.False(m.Success); }))
                .AddRegex(new RegexExecute("[a-z]", (m) => { Assert.False(m.Success); }))
                .Run("+");
        }

        [Fact]
        public void Match_True_And_Equals_Value()
        {
            var testValue = "7";
            var returnValue = "";
            RegexManager manager = new RegexManager((m) => { Assert.True(m.Success); });
            manager
                .AddRegex(new RegexExecute("[0-9]", (m) => { Assert.True(m.Success); returnValue = m.Value; }))
                .AddRegex(new RegexExecute("[a-z]", (m) => { Assert.True(m.Success); returnValue = m.Value; }))
                .Run(testValue);
            Assert.Equal(testValue, returnValue);
        }
    }
}
