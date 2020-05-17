using System;
using System.Collections.Generic;
using PterodactylEngine;
using Xunit;

namespace UnitTestEngine
{
    public class TestHorizontalLine
    {
        [Fact]
        public void CorrectData()
        {
            string expected = Environment.NewLine +  "------" + Environment.NewLine;
            HorizontalLine testObject = new HorizontalLine();
            Assert.Equal(expected, testObject.Create());
        }
    }
}

