using System;
using System.Drawing;
using PterodactylCharts;
using Xunit;

namespace UnitTestEngine
{
    public class TestGraphSettingsHelper : TheoryData<string, GraphSizes, Color, GraphAxis, string>
    {
        public TestGraphSettingsHelper()
        {
            Add("Title example", new GraphSizes(200, 200), Color.Aqua, new GraphAxis("X", "Y"), "Graph Settings");
        }
    }
    
    public class TestGraphSettingsAdvancedHelper : TheoryData<string, double, GraphSizes, Color, GraphAxis, double, string>
    {
        public TestGraphSettingsAdvancedHelper()
        {
            Add("Title example", 5.0, new GraphSizes(200, 200), Color.Aqua, new GraphAxis("X", "Y"), 0.0, "Graph Settings");
            Add("Title example", 140.0, new GraphSizes(300, 400), Color.Red, new GraphAxis("X Axis", "Y Axis"), 250.0, "Graph Settings");
        }
    }
    
    public class TestGraphSettingsAdvancedExceptionHelper : TheoryData<string, double, GraphSizes, Color, GraphAxis, double, string>
    {
        public TestGraphSettingsAdvancedExceptionHelper()
        {
            Add("Title example", 4.9, new GraphSizes(200, 200), Color.Aqua, new GraphAxis("X", "Y"), 0.0, "Title size is limited from 5 to 140");
            Add("Title example", 140.1, new GraphSizes(300, 400), Color.Red, new GraphAxis("X Axis", "Y Axis"), 0.0, "Title size is limited from 5 to 140");
            Add("Title example", 5.0, new GraphSizes(200, 200), Color.Aqua, new GraphAxis("X", "Y"), -0.1, "Padding is limited from 0 to 250");
            Add("Title example", 5.0, new GraphSizes(300, 400), Color.Red, new GraphAxis("X Axis", "Y Axis"), 250.1, "Padding is limited from 0 to 250");
        }
    }
    
    public class TestGraphSettings
    {
        [Theory]
        [ClassData(typeof(TestGraphSettingsHelper))]
        public void CorrectData(string graphTitle, GraphSizes graphSizes, Color graphColor, GraphAxis graphAxis, string toString)
        {
            GraphSettings testObject = new GraphSettings(graphTitle, graphSizes, graphColor, graphAxis);
            Assert.Equal(graphTitle, testObject.Title);
            Assert.Equal(graphSizes, testObject.Sizes);
            Assert.Equal(graphColor, testObject.GraphColor);
            Assert.Equal(graphAxis, testObject.Axis);
            Assert.Equal(toString, testObject.ToString());
        }
        
        [Theory]
        [ClassData(typeof(TestGraphSettingsAdvancedHelper))]
        public void CorrectDataAdvanced(string graphTitle, double titleSize, GraphSizes graphSizes, Color graphColor, GraphAxis graphAxis, double padding, string toString)
        {
            GraphSettings testObject = new GraphSettings(graphTitle, titleSize, graphSizes, graphColor, graphAxis, padding);
            Assert.Equal(graphTitle, testObject.Title);
            Assert.Equal(titleSize, testObject.TitleSize);
            Assert.Equal(graphSizes, testObject.Sizes);
            Assert.Equal(graphColor, testObject.GraphColor);
            Assert.Equal(graphAxis, testObject.Axis);
            Assert.Equal(padding, testObject.Padding);
            Assert.Equal(toString, testObject.ToString());
        }
        
        [Theory]
        [ClassData(typeof(TestGraphSettingsAdvancedExceptionHelper))]
        public void CheckAdvancedExceptions(string graphTitle, double titleSize, GraphSizes graphSizes, Color graphColor, GraphAxis graphAxis, double padding, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new GraphSettings(graphTitle, titleSize, graphSizes, graphColor, graphAxis, padding));
            Assert.Equal(message, exception.Message);
        }
    }
}