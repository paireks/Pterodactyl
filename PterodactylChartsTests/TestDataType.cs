using System;
using System.Drawing;
using PterodactylCharts;
using PterodactylCharts.Enums;
using Xunit;

namespace UnitTestEngine
{
    public class TestDataTypeLineHelper : TheoryData<Color, string, TypeOfData>
    {
        public TestDataTypeLineHelper()
        {
            Add(Color.Aqua, "Line Data", TypeOfData.Line);
            Add(Color.FromArgb(2, 10,23,12), "Line Data", TypeOfData.Line);
        }
    }

    public class TestDataTypeLineAdvancedHelper : TheoryData<Color, int, int, double, string, TypeOfData>
    {
        public TestDataTypeLineAdvancedHelper()
        {
            Add(Color.Aqua, 2, 3, 0.5, "Line Data", TypeOfData.Line);
            Add(Color.Red, 3, 2, 10.2, "Line Data", TypeOfData.Line);
        }
    }

    public class TestDataTypeLineAdvancedHelperExceptions : TheoryData<Color, int, int, double, string>
    {
        public TestDataTypeLineAdvancedHelperExceptions()
        {
            Add(Color.Aqua, -1, 3, 0.5, "Interpolation can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 5, 3, 0.5, "Interpolation can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 2, -1, 0.5, "Line Style can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 2, 5, 0.5, "Line Style can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 2, 3, 20.1, "Line thickness can be from 0.1 to 20.0");
            Add(Color.Aqua, 2, 3, 0.09, "Line thickness can be from 0.1 to 20.0");
        }
    }

    public class TestDataTypePointHelper : TheoryData<Color, int, string, TypeOfData>
    {
        public TestDataTypePointHelper()
        {
            Add(Color.Aqua, 0, "Point Data", TypeOfData.Point);
            Add(Color.FromArgb(2, 10, 23, 12), 4, "Point Data", TypeOfData.Point);
        }
    }

    public class TestDataTypePointExceptionHelper : TheoryData<Color, int, string>
    {
        public TestDataTypePointExceptionHelper()
        {
            Add(Color.Aqua, -1, "Marker can't be larger than 4 or smaller than 0");
            Add(Color.Aqua, 5, "Marker can't be larger than 4 or smaller than 0");
        }
    }
    
    public class TestDataTypePointAdvancedHelper : TheoryData<Color, int, double, string, TypeOfData>
    {
        public TestDataTypePointAdvancedHelper()
        {
            Add(Color.Aqua, 0, 0.2, "Point Data", TypeOfData.Point);
            Add(Color.FromArgb(2, 10, 23, 12), 4, 11.5, "Point Data", TypeOfData.Point);
        }
    }
    
    public class TestDataTypePointAdvancedExceptionHelper : TheoryData<Color, int, double, string>
    {
        public TestDataTypePointAdvancedExceptionHelper()
        {
            Add(Color.Aqua, -1, 0.2, "Marker can't be larger than 6 or smaller than 0");
            Add(Color.Aqua, 7, 0.2, "Marker can't be larger than 6 or smaller than 0");
            Add(Color.Aqua, 0, 0.09, "Marker size can't be larger than 100 or smaller than 0.1");
            Add(Color.Aqua, 0, 100.1, "Marker size can't be larger than 100 or smaller than 0.1");
        }
    }

    public class TestDataTypeScatterHelper : TheoryData<Color[], int, double[], double[], string, TypeOfData>
    {
        public TestDataTypeScatterHelper()
        {
            Add(new []{Color.Aqua, Color.Red}, 2, new []{0.5}, new []{0.2}, "Scatter Data", TypeOfData.Scatter);
            Add(new []{Color.Aqua, Color.Yellow, Color.Red}, 3, new []{0.6, 0.4}, new []{0.2, 1.1}, "Scatter Data", TypeOfData.Scatter);
        }
    }

    public class TestDataTypeScatterExceptionHelper : TheoryData<Color[], int, double[], double[], string>
    {
        public TestDataTypeScatterExceptionHelper()
        {
            Add(new Color[]{}, 2, new []{0.5}, new []{0.2}, "Palette is should have at least one color or max 4096 unique colors");
            Add(new Color[4097], 2, new []{0.5}, new []{0.2}, "Palette is should have at least one color or max 4096 unique colors");
            Add(new []{Color.Aqua, Color.Red}, -1, new []{0.5}, new []{0.2}, "Marker style can't be larger than 6 or smaller than 0");
            Add(new []{Color.Aqua, Color.Red}, 7, new []{0.5}, new []{0.2}, "Marker style can't be larger than 6 or smaller than 0");
            Add(new []{Color.Aqua, Color.Red}, 2, new []{0.5, 0.4, 0.1}, new []{0.3, double.PositiveInfinity, 0.2}, "Scatter Values must be a double precision number");
            Add(new []{Color.Aqua, Color.Red}, 2, new []{0.5, 0.4, -0.1}, new []{0.3, 0.2, 0.1}, "Marker sizes can't be larger than 100 or smaller than 0.1");
            Add(new []{Color.Aqua, Color.Red}, 2, new []{0.5, 0.4, 100.1}, new []{0.3, 0.2, 0.1}, "Marker sizes can't be larger than 100 or smaller than 0.1");
            Add(new []{Color.Aqua, Color.Red}, 2, new []{0.5, 0.1}, new []{0.3, 0.2, 10.2}, "Marker sizes and Scatter Values count must be the same");
        }
    }

    public class TestDataTypeAnnotationHelper : TheoryData<string[], double, int, string, TypeOfData>
    {
        public TestDataTypeAnnotationHelper()
        {
            Add(new []{"Text A"}, 6.2, 2, "Annotation Data", TypeOfData.Annotation);
            Add(new []{"Text A", "Text B"}, 10.1, 0, "Annotation Data", TypeOfData.Annotation);
        }
    }
    
    public class TestDataTypeAnnotationExceptionHelper : TheoryData<string[], double, int, string>
    {
        public TestDataTypeAnnotationExceptionHelper()
        {
            Add(new []{"Text A"}, 5.9, 2, "Annotation sizes can't be larger than 72 or smaller than 6");
            Add(new []{"Text A"}, 72.1, 2, "Annotation sizes can't be larger than 72 or smaller than 6");
            Add(new string[]{}, 6.0, 2, "Annotation array is empty");
            Add(new []{"Text A"}, 6.0, -1, "Annotation position index out of range");
            Add(new []{"Text A"}, 6.0, 5, "Annotation position index out of range");
        }
    }

    public class TestDataType
    {
        [Theory]
        [ClassData(typeof(TestDataTypeLineHelper))]
        public void CorrectDataLine(Color color, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(typeOfData, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }

        [Theory]
        [ClassData(typeof(TestDataTypeLineAdvancedHelper))]
        public void CorrectDataLineAdvance(Color color, int interpolation, int lineStyle, double lineWeight, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color, interpolation, lineStyle, lineWeight);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(typeOfData, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
            Assert.Equal(interpolation, testObject.LineInterpolation);
            Assert.Equal(lineStyle, testObject.LineStyle);
            Assert.Equal(lineWeight, testObject.LineWeight);
        }
        
        [Theory]
        [ClassData(typeof(TestDataTypeLineAdvancedHelperExceptions))]
        public void DataLineAdvanceExceptions(Color color, int interpolation, int lineStyle, double lineWeight, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(color, interpolation, lineStyle, lineWeight));
            Assert.Equal(message, exception.Message);
        }
        
        [Theory]
        [ClassData(typeof(TestDataTypePointHelper))]
        public void CorrectDataPoint(Color color, int markerType, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color, markerType);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(markerType, testObject.Marker);
            Assert.Equal(typeOfData, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypePointExceptionHelper))]
        public void CheckExceptions(Color color, int markerType, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(color, markerType));
            Assert.Equal(message, exception.Message);
        }
        
        [Theory]
        [ClassData(typeof(TestDataTypePointAdvancedHelper))]
        public void CorrectDataPointAdvanced(Color color, int markerType, double markerSize, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(color, markerType, markerSize);
            Assert.Equal(color, testObject.DataColor);
            Assert.Equal(markerType, testObject.Marker);
            Assert.Equal(markerSize, testObject.MarkerSizes[0]);
            Assert.Single(testObject.MarkerSizes);
            Assert.Equal(typeOfData, testObject.TypeOfData);
            Assert.Equal(toString, testObject.ToString());
        }
        [Theory]
        [ClassData(typeof(TestDataTypePointAdvancedExceptionHelper))]
        public void DataPointAdvancedExceptions(Color color, int markerType, double markerSize, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(color, markerType, markerSize));
            Assert.Equal(message, exception.Message);
        }

        [Theory]
        [ClassData(typeof(TestDataTypeScatterHelper))]
        public void CorrectDataScatter(Color[] colors, int marker, double[] markerSizes, double[] scatterValues, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(scatterValues, markerSizes, marker, colors);
            Assert.Equal(colors, testObject.ScatterPalette);
            Assert.Equal(marker, testObject.Marker);
            Assert.Equal(markerSizes, testObject.MarkerSizes);
            Assert.Equal(scatterValues, testObject.ScatterValues);
            Assert.Equal(toString, testObject.ToString());
            Assert.Equal(typeOfData, testObject.TypeOfData);
        }
        
        [Theory]
        [ClassData(typeof(TestDataTypeScatterExceptionHelper))]
        public void DataScatterAdvancedExceptions(Color[] colors, int marker, double[] markerSizes, double[] scatterValues, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(scatterValues, markerSizes, marker, colors));
            Assert.Equal(message, exception.Message);
        }

        [Theory]
        [ClassData(typeof(TestDataTypeAnnotationHelper))]
        public void CorrectDataAnnotation(string[] annotationTexts, double annotationTextSize, int annotationTextPosition, string toString, TypeOfData typeOfData)
        {
            DataType testObject = new DataType(annotationTexts, annotationTextSize, annotationTextPosition);
            Assert.Equal(annotationTexts, testObject.AnnotationTexts);
            Assert.Equal(annotationTextSize, testObject.AnnotationTextSize);
            Assert.Equal(annotationTextPosition, testObject.AnnotationTextPosition);
            Assert.Equal(toString, testObject.ToString());
            Assert.Equal(typeOfData, testObject.TypeOfData);
        }
        
        [Theory]
        [ClassData(typeof(TestDataTypeAnnotationExceptionHelper))]
        public void DataAnnotationExceptions(string[] annotationTexts, double annotationTextSize, int annotationTextPosition, string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DataType(annotationTexts, annotationTextSize, annotationTextPosition));
            Assert.Equal(message, exception.Message);
        }
    }
}