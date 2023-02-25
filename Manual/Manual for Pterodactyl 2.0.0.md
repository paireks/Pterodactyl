# Manual for Pterodactyl 2.0.0

[TOC]

## Introduction

<p align="center">
    <img src="Img\Logo.png" alt="Logo" style="zoom:50%;" />
</p>

Hey! Thank you for using Pterodactyl! ;)

Pterodactyl is an open-source plug-in for Grasshopper.

**Purpose:** creating reports inside Grasshopper. Those reports or documents can be later saved to pdf/html/docx/LaTeX files.

**Requirements:**

- Rhino 6 or 7
- Markdown editor, Typora is recommended (https://typora.io/), or if you look for something open-source, check MarkText (https://marktext.app/)

**Contact:** If you have any specific questions, email me: w.radaczynski@gmail.com

**Tutorials:** You can find many tutorials on my YT channel here: https://www.youtube.com/channel/UCfXkMo1rOMhKGBoNwd7JPsw

### License (MIT License)

Copyright © 2023 Wojciech Radaczyński

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

[Link to license](https://opensource.org/licenses/MIT)

Credits:

OxyPlot

- license: https://github.com/oxyplot/oxyplot/blob/develop/LICENSE
- source code / info: https://github.com/oxyplot/oxyplot

### How does Pterodactyl work

Pterodactyl will help you to build those documents step by step. Components are creating small parts of text, that are written in Markdown. These parts are called Report Parts.

<p align="center">
    <img src="Img\ReportPart.png" alt="Report Part" style="zoom:100%;" />
</p>

To create report you need to add all those Report Parts to an egg component, which is called Create Report. This component will create report that will be later ready to save.

<p align="center">
    <img src="Img\CreateReport.png" alt="Create Report" style="zoom:100%;" />
</p>

To save and open this report to see the results, you have to connect Report with Save Report component. You need to set the file path also, with the .md extension (.md = Markdown).

![SaveReport](Img\SaveReport.png)

When you saved it you can open it. To open it properly use your favorite Markdown editor (Typora recommended).

<p align="center">
    <img src="Img\0Example.png" alt="0 Example" style="zoom:100%;" />
</p>

### Your first report (Hello Jurassic world)

Well, now let's create our first simple report with Pterodactyl. It will have one heading, and a text "Hello Jurassic world" below the heading. We will save it to pdf later.

To create heading we use Heading component. We can set text and level of the heading.

<p align="center">
    <img src="Img\1Example_Heading.png" alt="1Example_Heading" style="zoom:100%;" />
</p>

Let's add it to Create Report and Save Report component like this:

<p align="center">
    <img src="Img\1Example0.png" alt="1Example0" style="zoom:100%;" />
</p>

OK, so right now let's add some text. We do it just by adding plain text as Report Part, like that:

![1Example1](Img\1Example1.png)

So we have our first document written using Pterodactyl. Now to save it as .pdf in Typora we click File -> Export -> Pdf.

## Advanced Graph

<p align="center">
    <img src="Img\AdvancedGraphs.png" alt="AdvancedGraphs" style="zoom:100%;" />
</p>

### About

Advanced Graph component will help you to create complex graph with many different data, styles, etc.

### Tips

**Look at the tips given in a Basic Graph chapter at first - all of them will work for Advanced Graph as well.**

### Components

#### Graph

Graph component will create a graph for you.

<p align="center">
    <img src="Img\GraphComponent.png" alt="GraphComponent" style="zoom:100%;" />
</p>

To create this graph you need to connect Graph Elements and Graph Settings component.

This component looks pretty much the same as the components from Basic Graphs. It also requires Path with .png extension to create the Report Part that can be added to report. The best approach is to connect Button component to Show Graph input.

#### Graph Elements

<p align="center">
    <img src="Img\GraphElements.png" alt="GraphElements" style="zoom:100%;" />
</p>

Graph Elements collect Graph Data and Graph Legend together and pass it to Graph component.

#### Graph Data

<p align="center">
    <img src="Img\GraphData.png" alt="GraphData" style="zoom:100%;" />
</p>

Graph Data has a crucial role in Advanced Graph because you will set a data that you want to add to the plot there.

X Values and Y Values are inputs that require tree of data to plug in. Each branch represents each set of data. Component also requires to set Value Names that will represents those sets of data in the Legend that will appear on a plot. The number of branches in X Values and Y Values must be the same as the number of elements if Values Names and Data Types.

Data Types let you decide how sets of data will represent inside plot.

Examples:

<p align="center">
    <img src="Img\DataGraphExample1.png" alt="DataGraphExample1" style="zoom:100%;" />
</p>

<p align="center">
    <img src="Img\DataTypeExample2.png" alt=DataTypeExample2" style="zoom:100%;" />
</p>

<p align="center">
    <img src="Img\DataGraphExample3.png" alt="DataGraphExample3" style="zoom:100%;" />
</p>

#### Data Styles

##### Point Data
                                                                                   
Point data defines the appearance of point information that is passed to the Graph Data component. You can define the color as any RGB value, the type of marker as interger (0 - None, 1 - Circle, 2 - Square, 3 - Diamond, 4 - Triangle, 5 - Cross, 6 - Plus) and the size of the marker [0.1-100.0]  

##### Line Data
                                                                                   
Line Data is similar to point data but instead of drawing points it connects them with lines. You can define the color as any RGB value, the interpolation between the points (0 - None 1 - UniformCatmullRomSpline 2 - CatmullRomSpline 3 - CanonicalSpline 4 - ChordalCatmullRomSpline), the line style (0 - Solid, 1 - Dash, 2 - Dot, 3 - DashDot, 4 - DashDotDot) and the thicnkess [0.1-20.0] 
                                                                   
##### Point Annotation
                                                                                   
Point annotation draws text in relation to the points specified in the Graph Data component. You can set the text, the size and the location (0 = Centre, 1 = Left, 2 = Right, 3 = Top, 4 = Bottom).
                                                                                 
##### Scatter Data
                                                                                   
Scatter Data is very similar to point data. It draws points to the graph, however, you can additionally specify color and size gradients. You can define the color range as a list of colors or a gradient, one type of marker as interger (0 - None, 1 - Circle, 2 - Square, 3 - Diamond, 4 - Triangle, 5 - Cross, 6 - Plus), the list of marker sizes [0.1-50.0] and the list of color parameters that specify the corresponding color for each point (this list should be equal lenght as the X&Y value lists). The color pallete range is determined from the min. and max. values from the Params list.
                                                                          
<p align="center">
    <img src="Img\DataTypes.png" alt="DataTypes" style="zoom:100%;" />
</p>

#### Graph Legend

Graph Legend will help you to set the legend in your graph.

<p align="center">
    <img src="Img\GraphLegend.png" alt="GraphLegend" style="zoom:100%;" />
</p>

You need to set a title of the legend and a position (as an integer number).

You can set position from 0 to 12, here it's how it works:

<p align="center">
    <img src="Img\GraphLegendPosition.png" alt="GraphLegendPosition" style="zoom:50%;" />
</p>

To set the colors of the data that are shown in the legend - set them in Data Type component.

#### Graph Settings

Graph Settings requires to take 4 arguments: 

- Title - this will be a title of the graph,
- Graph Sizes (from Graph Sizes component),
- Color - this will be a background color of the graph,
- Graph Axis (from Graph Axis component)

Graph Settings need to be connected with Graph component.

 <p align="center">
    <img src="Img\GraphSettings.png" alt="GraphSettings" style="zoom:100%;" />
</p>

#### Graph Sizes

Graph Sizes will let you set the size of a graph. Width and Height can be between 200 and 1000.

When you change the Height - it will be visible in a preview window (Show Graph) and in the report.

When you change the Width - it will be visible only in the report - that's because width in a preview depends on a size of a window.

 <p align="center">
    <img src="Img\GraphSizes.png" alt="GraphSizes" style="zoom:100%;" />
</p>

#### Graph Axis

This component will set the names of the x and y axis:

 <p align="center">
    <img src="Img\GraphAxis.png" alt="GraphAxis" style="zoom:100%;" />
</p>

## Basic Graphs

 <p align="center">
    <img src="Img\BasicGraphs.png" alt="BasicGraphs" style="zoom:100%;" />
</p>

### About

Basic Graphs components will help you to create simple graphs and charts. With one big component you will create a simple graph. If you need more complex graph - check out Advanced Graph components.

### Tips

All those components have many things in common, so there are the tips for all of them:

- Show Graph input will open the window that will show your graph in a new window. The best approach is to plug Button component (build-in Grasshopper component) to this input, so every time you click this Button - the window with your graph will appear and you can look at the results: 

  <p align="center">
      <img src="Img\ShowGraph.png" alt="ShowGraph" style="zoom:100%;" />
  </p>

- To create Report Part - you have to set the Path first. That's because the graph will appear in your document as .png file, so you need to save it first, and then import as image, like that:

  <p align="center">
      <img src="Img\BasicGraphsTip2.png" alt="BasicGraphsTip2" style="zoom:100%;" />
  </p>

  Then you can later add it as Report Part to your document:

  <p align="center">
      <img src="Img\BasicGraphsTip2_1.png" alt="BasicGraphsTip2_1" style="zoom:100%;" />
  </p>

- You can interact with the window that will appear after setting Show Graph to true - by clicking at the data. It is especially helpful in Line Graph and Point Graph where you can click for example at the local values to get some more info:

  <p align="center">
      <img src="Img\GraphInteraction.png" alt="GraphInteraction" style="zoom:100%;" />
  </p>

- There is a simple way to display our graphs / charts inside Rhino (inside our viewports). To do this we can use build-in component called Import Image.

  If you plug the same file path to File input (F) - our graph will appear inside Rhino viewport:

  <p align="center">
      <img src="Img\GraphImage.png" alt="GraphImage" style="zoom:100%;" />
  </p>

  You can optionally plug rectangle to Rectangle input (R) - this way you can decide how big and where our graph will appear in a Rhino viewport.
  
  Import Image component takes actually some visible amount of time to re-import the image every time it changes, so you have to for example let go a slider that is connected to graph / chart components to see the new results.

### Components

#### Bar Chart

Bar Chart will create bar chart for given data.

<p align="center">
    <img src="Img\BarChartExample.png" alt="BarChartExample" style="zoom:100%;" />
</p>

You can change Text Format input to set how the values will be presented.

Remember that number of Values must be the same as number of Bar Names and Colors.

#### Column Chart

Column Chart will create column chart for given data.

<p align="center">
    <img src="Img\ColumnChart.png" alt="ColumnChart" style="zoom:100%;" />
</p>

You can change Text Format input to set how the values will be presented.

Remember that Values, Column Names and Colors must have the same number of elements.

#### Pie Chart

Pie Chart will create pie chart for given data.

<p align="center">
    <img src="Img\PieChart.png" alt="PieChart" style="zoom:100%;" />
</p>

Remember that Values, Slices Names and Colors must have the same number of elements.

#### Point Graph

Point Graph will create a graph with point representation of the given data.

<p align="center">
    <img src="Img\PointGraph.png" alt="PointGraph" style="zoom:100%;" />
</p>

As you can see at the example above: there are 3 different points: (10, 5), (20, 15), (30, 45). You have to make sure that every X Value has it's own Y Value. We can create more complex graphs like this:

 <p align="center">
    <img src="Img\PointGraph1.png" alt="PointGraph1" style="zoom:100%;" />
</p>

If we change right now the parameters of the Series component (build-in Grasshopper component), then our sinus function will look much more clearer:

<p align="center">
    <img src="Img\PointGraph2.png" alt="PointGraph2" style="zoom:100%;" />
</p>

#### Line Graph

Line Graph works similar to Point Graph, but it connects all the points with the lines. So let's try the same example like with Point Graph above:

<p align="center">
    <img src="Img\LineGraph1.png" alt="LineGraph1" style="zoom:100%;" />
</p>

And again, if we change our parameters:

<p align="center">
    <img src="Img\LineGraph2.png" alt="LineGraph2" style="zoom:100%;" />
</p>

## Format

<p align="center">
    <img src="Img\Format.png" alt="Format" style="zoom:100%;" />
</p>

### About

Format components will help you to format your text. Without format it looks like this:

<p align="center">
    <img src="Img\WithoutFormat.png" alt="WithoutFormat" style="zoom:80%;" />
</p>

So now let's try different format components.

#### Emphasis

<p align="center">
    <img src="Img\Emphasis.png" alt="Emphasis" style="zoom:80%;" />
</p>

#### Strong

<p align="center"><img src="Img\Strong.png" alt="Strong" style="zoom:80%;" /></p>

#### Strike

<p align="center"><img src="Img\Strike.png" alt="Strike" style="zoom:80%;" /></p>

#### Underline

<p align="center"><img src="Img\Underline.png" alt="Underline" style="zoom:80%;" /></p>

## Parts

<p align="center">
    <img src="Img\Parts.png" alt="Parts" style="zoom:100%;" />
</p>

### About

These components allow you to insert some special type of paragraphs like headings, lists, tables, images etc.

### Components

#### Heading

Heading needs two inputs: text that will be a heading, and level. There are 6 levels of headings, from 1 to 6. 1 is the biggest, 6 is the smallest one.

Level of your headings will affect your Table of content (table of content is heading - dependent). To turn on table of contents - switch it on in Create Report component. Here is an example of setting one heading:

<p align="center">
    <img src="Img\Heading.png" alt="Heading" style="zoom:100%;" />
</p>

Now let's add multiple headings with text between and let's see how it will affect the table of contents:

<p align="center">
    <img src="Img\HeadingExample.png" alt="HeadingExample" style="zoom:100%;" />
</p>

As you can see: the higher level of a heading = the lower level of hierarchy in table of contents.

#### Horizontal Line

This component add horizontal line in your document. You can divide a plain text using this component. For example:

<p align="center">
    <img src="Img\HorizontalLine.png" alt="HorizontalLine" style="zoom:100%;" />
</p>

#### Hyperlink

To add hyperlink use Hyperlink component. It takes two inputs: text, and the link for the hyperlink. Here is an example how to add a hyperlink for food4rhino website.

<p align="center">
    <img src="Img\Hyperlink.png" alt="Hyperlink" style="zoom:100%;" />
</p>

When you save it to .pdf and click it inside document - it will open the website.

**Tip:** If you give the path to your local folder / file instead of the website address to the Link input - you can open this location / folder / file inside Typora by clicking ctrl + left mouse button on a hyperlink. Example:

<p align="center">
    <img src="Img\Hyperlink2.png" alt="Hyperlink2" style="zoom:100%;" />
</p>

#### Page Break

Page Break component can be helpful when you try to force creation of another page where you exactly want. It will be visible only in your exported .pdf.

<p align="center">
    <img src="Img\PageBreakBefore.png" alt="PageBreakBefore" style="zoom:100%;" />
</p>

#### Quote

<p align="center">
    <img src="Img\Quote.png" alt="Quote" style="zoom:100%;" />
</p>

#### Table

To add table use Table component. It takes 3 inputs: Table Headings, Alignment and Data Tree. These are three different inputs, but all of these are related with each other, and all are needed to create a table.

<p align="center">
    <img src="Img\Table.png" alt="Table" style="zoom:100%;" />
</p>

As you can see to add Data Tree you need to create a tree where each branch will be a list of rows for each column.

There are few requirements to create a table:

- The number of headings, alignments and branches of data tree have to be the same
- The number of rows in each branch have to be the same

In alignment input there are options from 0 to 2. It works like this:

<p align="center">
    <img src="Img\TableAlignment.png" alt="TableAlignment" style="zoom:100%;" />
</p>

So basically alignment are set for whole column.

#### Ordered List / Unordered List

Ordered List and Unordered List component work basically the same. All you need to do is to add items of the list to Items input, like that:

<p align="center">
    <img src="Img\Lists.png" alt="Lists" style="zoom:100%;" />
</p>

#### Task List

What is different in Task List is the ability to choose if the item of the list is done or not.

<p align="center">
    <img src="Img\TaskList.png" alt="TaskList" style="zoom:100%;" />
</p>

The number of tasks and the number of boolean values for Done input must be the same. 

#### Code Block

Code block can be helpful when you want to add some part of your code to your report.

<p align="center">
    <img src="Img\CodeBlock.png" alt="CodeBlock" style="zoom:100%;" />
</p>

The syntax highlight will be added automatically depending on a language given as an input.

There are many things that you can do with that. For example:

<p align="center">
    <img src="Img\CodeBlockExample.png" alt="CodeBlockExample" style="zoom:100%;" />
</p>

So that way you can combine code block with the results of those blocks.

Of course other languages syntax also will be highlighted, for example:

<p align="center">
    <img src="Img\CodeBlockCSharpExample.png" alt="CodeBlockCSharpExample" style="zoom:100%;" />
</p>

#### Math Block

Math Block will help you to create beautiful and complex equations. It let you write them in TeX, for example:

<p align="center">
    <img src="Img\MathBlock.png" alt="MathBlock" style="zoom:100%;" />
</p>

You don't need to learn all the TeX syntax if you don't want to - there are many websites that will help you to build complex equations without knowing anything about LaTeX. For example:

https://www.latex4technics.com/

With this website you can create those complex definitions just by clicking on a different symbols. Then you can just copy-paste the result to Text input of Math Block component.

#### Dynamic Math Block

Dynamic math block let you combine writing complex equations with dynamically changing variables.

<p align="center">
    <img src="Img\DynamicMathBlock1.png" alt="DynamicMathBlock1" style="zoom:100%;" />
</p>

As you can see above: when you put the variable name in Text input in angle brackets, then it will automatically change it's value to the Variable Value. You can do the same with multiple variables like this:

<p align="center">
    <img src="Img\DynamicMathBlock2.png" alt="DynamicMathBlock2" style="zoom:100%;" />
</p>

This can be helpful to create reports of your calculations. Look at the Math Block to read more about LaTeX syntax that can be used here as well.

#### Image

If you want to add an image to your report - use Image component. All you need to do is to add a title of your image, and path to this file.

<p align="center">
    <img src="Img\Image.png" alt="Image" style="zoom:100%;" />
</p>

Remember that path need to contain a file name with the extension (like .png for example). 

#### Viewport

Viewport component let you capture the viewport to .png file and insert it to your report.

Viewport Name input must be the same as the name of your viewport that you want to capture. It captures current position / view of your elements that are inside that viewport.

<p align="center">
    <img src="Img\Viewport.png" alt="Viewport" style="zoom:100%;" />
</p>

There are multiple settings that you can set to change the result image. Also changing the style of the viewport or the size of it will affect the result .png file:

<p align="center">
    <img src="Img\Viewport1.png" alt="Viewport1" style="zoom:100%;" />
</p>

Sometimes there is a need to click "Recompute" inside Grasshopper to refresh the image shown in Typora. To do this click right mouse button anywhere in Grasshopper and click Recompute, then click on a Typora window.

## Report

<p align="center">
    <img src="Img\Report.png" alt="Report" style="zoom:100%;" />
</p>

### About

Report components are the main components of the Pterodactyl plug-in. They are always required to create the report and open it with the Typora or other Markdown editor.

<p align="center">
    <img src="Img\ReportExample.png" alt="ReportExample" style="zoom:100%;" />
</p>

### Components

#### Create Report

Create Report component will create your report, but to save it and open you need to use Save Report component.

To create the report plug all the Report Parts you have to the Report Parts input. The order of this list of Report Parts will be the order of all those parts in your document:

<p align="center">
    <img src="Img\CreateReport1.png" alt="CreateReport1" style="zoom:100%;" />
</p>

If you have to manage multiple parts - Entwine component (which is build in component in Grasshopper) can be helpful. That way it's easier to have a control of an order of report parts:

<p align="center">
    <img src="Img\CreateReport2.png" alt="CreateReport2" style="zoom:100%;" />
</p>

Remember to flatten the output of Entwine (right click on the output -> Flatten).

You can set a Title and Table of Contents for the document here:

<p align="center">
    <img src="Img\CreateReport3.png" alt="CreateReport3" style="zoom:100%;" />
</p>

To open the document - see the Save Report component.

#### Save Report

Save Report component allow you to save your created report and open it in your favorite Markdown editor.

 <p align="center">
    <img src="Img\SaveReport1.png" alt="SaveReport1" style="zoom:100%;" />
</p>

To save the report you need to connect Create Report output and a path where your report will be saved. Remember that path need to have a name of the file at the end with .md extension for example: *C:\Users\MyUserName\Desktop\MyReport.md*

Save Report will create a .md file in the given location. You can open this file with any Markdown editor (Typora recommended). 

File can be constantly opened in Typora, but remember that it won't always refresh after changes - not all changes in Grasshopper will make Typora refresh, (but most of them will). To make sure it'll refresh try some of these options:

- Recompute document inside Grasshopper (right click anywhere in Grasshopper -> Recompute)
- Click on a Typora
- Close and reopen Typora

Many Markdown editors (like MarkText) won't allow you to do constant changes outside editors (with Grasshopper) and they want you to confirm that you're going to change document externally every time something changes.

## Tools

 <p align="center">
    <img src="Img\Tools.png" alt="Tools" style="zoom:100%;" />
</p>

### About

Tools component are the components based on Mermaid: https://mermaid-js.github.io/

### Pie Chart

 <p align="center">
    <img src="Img\PieChartTool.png" alt="PieChartTool" style="zoom:100%;" />
</p>

Categories and Values must have the same number of elements.

You can also create pie chart with another component in Basic Graph group - called also Pie Chart.

### Flowchart Tools

Above you'll find all the components that will help you to build flowcharts.

Creating flowchart can help you for example to document your complex Grasshopper definitions.

In flowchart you have nodes and links between those nodes:

<p align="center">
    <img src="Img\Flowchart0.png" alt="FlowChart0" style="zoom:100%;" />
</p>


To start flowchart we need to use Flowchart Start Node, then we connect Flowchart Nodes or Links, then at the end we connect end Flowchart Nodes to Flowchart component that will create Report Part.

To modify the link between both nodes - we need to add Flowchart Link component between those nodes:

<p align="center">
    <img src="Img\FlowchartModifiedLink.png" alt="FlowChartModifiedLink" style="zoom:100%;" />
</p>


There are 4 types (0 - 3) of link that you can choose.

You can as well change a style of a node (change the shape of it from 0 to 8):

<p align="center">
    <img src="Img\FlowchartShape.png" alt="FlowChartShape" style="zoom:100%;" />
</p>


The text for the node is also it's id, so if you connect two nodes with the same name:

<p align="center">
    <img src="Img\FlowchartTheSameName.png" alt="FlowChartTheSameName" style="zoom:100%;" />
</p>


Let's plug two nodes to one starting node:

<p align="center">
    <img src="Img\Flowchart2in1.png" alt="FlowChart2In1" style="zoom:100%;" />
</p>


No let's try to connect those two to a new one:

<p align="center">
    <img src="Img\Flowchart1in2.png" alt="FlowChart1in2" style="zoom:100%;" />
</p>


Let's present more complex flowchart example:

<p align="center">
    <img src="Img\FlowchartComplexExample.png" alt="FlowChartComplexExample" style="zoom:100%;" />
</p>

