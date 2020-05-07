using System;
using Pterodactyl;
using Xunit;

namespace UnitTests
{
    public class TestPterodactylInfo
    {
        [Fact]
        public void TestName()
        {
            PterodactylInfo testObject = new PterodactylInfo();

            string expected;
            string actual;

            expected = "Pterodactyl";
            actual = testObject.Name;

            Assert.Equal(expected, actual);

        }
    }
}
