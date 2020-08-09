# Manual for Pterodactyl 1.2.0

[TOC]

## Introduction

<img src="Img\Logo.png" alt="Logo" style="zoom:50%;" />

Hey! Thank you for using Pterodactyl! ;)

Pterodactyl is an open-source plug-in for Grasshopper.

**Purpose:** creating reports inside Grasshopper. Those reports or documents can be later saved to pdf/html/docx/LaTeX files.

**Requirements:**

- Rhino 6 or 7
- Markdown editor, Typora is recommended (free during beta: https://typora.io/), or if you look for something open-source, check Mark Text (https://marktext.app/)

**Contact:** If you have any specific questions, email me: w.radaczynski@gmail.com

**Tutorials:** You can find many tutorials on my YT channel here: https://www.youtube.com/channel/UCfXkMo1rOMhKGBoNwd7JPsw

### License (MIT License)

Copyright © 2020 Wojciech Radaczyński

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

![ReportPart](Img\ReportPart.png)

To create report you need to add all those Report Parts to an egg component, which is called Create Report. This component will create report that will be later ready to save.

![CreateReport](Img\CreateReport.png)

To save and open this report to see the results, you have to connect Report with Save Report component. You need to set the file path also, with the .md extension (.md = Markdown).

![SaveReport](Img\SaveReport.png)

When you saved it you can open it. To open it properly use your favorite Markdown editor (Typora recommended).

![0Example](Img\0Example.png)

### Your first report (Hello Jurassic world)

Well, now let's create our first simple report with Pterodactyl. It will have one heading, and a text "Hello Jurassic world" below the heading. We will save it to pdf later.

To create heading we use Heading component. We can set text and level of the heading.

![1Example_Heading](Img\1Example_Heading.png)

Let's add it to Create Report and Save Report component like this:

![1Example0](Img\1Example0.png)

Ok, so right now let's add some text. We do it just by adding plain text as Report Part, like that:

![1Example1](Img\1Example1.png)

So we have our first document written using Pterodactyl. Now to save it as .pdf in Typora we click File -> Export -> Pdf.

## Advanced Graph

![AdvancedGraphs](Img\AdvancedGraphs.png)

### About

Advanced Graph component will help you to create complex graph with many different data, styles, etc.

### Tips

**Look at first at the tips given in a Basic Graph chapter - all of them will work for Advanced Graph as well.**

Here are the tips that will work only for Advanced Graphs:

- If you need to create a line plot that has a markers: combine Line data with Point data for the same set of data:

  ![AdvancedGraphTip1](Img\AdvancedGraphTip1.png)

### Components

#### Graph

Graph component will create a graph for you.

![GraphComponent](Img\GraphComponent.png)

To create this graph you need to connect Graph Elements and Graph Settings component.

This component looks pretty much the same as the components from Basic Graphs. It also requires Path with .png extension to create the Report Part that can be added to report. The best approach is to connect Button component to Show Graph input.

#### Graph Elements

![GraphElements](Img\GraphElements.png)

Graph Elements collect Graph Data and Graph Legend together and pass it to Graph component.

#### Graph Data

![GraphData](Img\GraphData.png)

Graph Data has a crucial role in Advanced Graph because you will set a data that you want to add to the plot there.

X Values and Y Values are inputs that require tree of data to plug in. Each branch represents each set of data. Component also requires to set Value Names that will represents those sets of data in the Legend that will appear on a plot. The number of branches in X Values and Y Values must be the same as the number of elements if Values Names and Data Types.

Data Types let you decide how sets of data will represent inside plot.

Examples:

![DataGraphExample1](Img\DataGraphExample1.png)

![DataTypeExample2](Img\DataTypeExample2.png)

![GraphDataExample3](Img\GraphDataExample3.png)

#### Data Type (Point Data / Line Data)

There are two types of data that you can create: Line or Point. Both of those components take Color as an argument. In Point Data you can also set type of the markers, by setting Marker input from 0 to 4.

![DataTypes](Img\DataTypes.png)

#### Graph Legend

Graph Legend will help you to set the legend in your graph.

![GraphLegend](Img\GraphLegend.png)

You need to set a title of the legend and a position (as an integer number).

You can set position from 0 to 12, here it's how it works:

<img src="Img\GraphLegendPosition.png" alt="GraphLegendPosition" style="zoom:50%;" />

To set the colors of the data that are shown in the legend - set them in Data Type component.

#### Graph Settings

Graph Settings requires to take 4 arguments: 

- Title - this will be a title of the graph,
- Graph Sizes (from Graph Sizes component),
- Color - this will be a background color of the graph,
- Graph Axis (from Graph Axis component)

Graph Settings need to be connected with Graph component.

 ![GraphSettings](Img\GraphSettings.png)

#### Graph Sizes

Graph Sizes will let you set the size of a graph. Width and Height can be between 200 and 1000.

When you change the Height - it will be visible in a preview window (Show Graph) and in the report.

When you change the Width - it will be visible only in the report - that's because width in a preview depends on a size of a window.

![GraphSizes](Img\GraphSizes.png)

#### Graph Axis

This component will set the names of the x and y axis:

![GraphAxis](Img\GraphAxis.png)

## Basic Graphs

![BasicGraphs](Img\BasicGraphs.png)

### About

Basic Graphs components will help you to create simple graphs and charts. With one big component you will create a simple graph. If you need more complex graph - check out Advanced Graph components.

### Tips

All those components have many things in common, so there are the tips for all of them:

- Show Graph input will open the window that will show your graph in a new window. The best approach is to plug Button component (build-in Grasshopper component) to this input, so every time you click this Button - the window with your graph will appear and you can look at the results: 

  ![ShowGraph](Img\ShowGraph.png)

- To create Report Part - you have to set the Path first. That's because the graph will appear in your document as .png file, so you need to save it first, and then import as image, like that:

  ![BasicGraphsTip2](Img\BasicGraphsTip2.png)

  Then you can later add it as Report Part to your document:

  ![BasicGraphsTip2_1](Img\BasicGraphsTip2_1.png)

- You can interact with the window that will appear after setting Show Graph to true - by clicking at the data. It is especially helpful in Line Graph and Point Graph where you can click for example at the local values to get some more info:

  ![GraphInteraction](Img\GraphInteraction.png)

- There is a simple way to display our graphs / charts inside Rhino (inside our viewports). To do this we can use build-in component called Import Image.

  If you plug the same file path to File input (F) - our graph will appear inside Rhino viewport:

  ![GraphImage](Img\GraphImage.png)

  You can optionally plug rectangle to Rectangle input (R) - this way you can decide how big and where out graph will appear in a Rhino viewport.

  Import Image component takes actually some visible amount of time to re-import the image every time it changes, so you have to for example let go a slider that is connected to graph / chart components to see the new results.

### Components

#### Bar Chart

Bar Chart will create bar chart for given data.

![BarChartExample](Img\BarChartExample.png)

You can change Text Format input to set how the values will be presented.

Remember that number of Values must be the same as number of Bar Names and Colors.

#### Column Chart

Column Chart will create column chart for given data.

![ColumnChart](Img\ColumnChart.png)

You can change Text Format input to set how the values will be presented.

Remember that Values, Column Names and Colors must have the same number of elements.

#### Pie Chart

Pie Chart will create pie chart for given data.

![PieChart](Img\PieChart.png)

Remember that Values, Slices Names and Colors must have the same number of elements.

#### Point Graph

Point Graph will create a graph with point representation of the given data.

![PointGraph](Img\PointGraph.png)

As you can see at the example above: there are 3 different points: (10, 5), (20, 15), (30, 45). You have to make sure that every X Value has it's own Y Value. We can create more complex graphs like this:

 ![PointGraph1](Img\PointGraph1.png)

If we change right now the parameters of the Series component (build-in Grasshopper component), then our sinus function will look much more clearer:

![PointGraph2](Img\PointGraph2.png)

#### Line Graph

Line Graph works similar to Point Graph, but it connects all the points with the lines. So let's try the same example like with Point Graph above:

![LineGraph1](Img\LineGraph1.png)

And again, if we change our parameters:

![LineGraph2](Img\LineGraph2.png)

## Format

![Format](Img\Format.png)

### About

Format components will help you to format your text. Without format it looks like this:

![WithoutFormat](Img\WithoutFormat.png)

So now let's try different format components.

#### Emphasis

![Emphasis](Img\Emphasis.png)

#### Strong

![Strong](Img\Strong.png)

#### Strike

![Strike](Img\Strike.png)

#### Underline

![Underline](Img\Underline.png)

## Parts

![Parts](Img\Parts.png)

### About

These components allow you to insert some special type of paragraphs like headings, lists, tables, images etc.

### Components

#### Heading

Heading needs two inputs: text that will be a heading, and level. There are 6 levels of headings, from 1 to 6. 1 is the biggest, 6 is the smallest one.

Level of your headings will affect your Table of content (table of content is heading - dependent). To turn on table of contents - switch it on in Create Report component. Here is an example of setting one heading:

![Heading](Img\Heading.png)

Now let's add multiple headings with text between and let's see how it will affect the table of contents:

![HeadingExample](Img\HeadingExample.png)

As you can see: the higher level of a heading = the lower level of hierarchy in table of contents.

#### Horizontal Line

This component add horizontal line in your document. You can divide a plain text using this component. For example:

![HorizontalLine](Img\HorizontalLine.png)

#### Hyperlink

To add hyperlink use Hyperlink component. It takes two inputs: text, and the link for the hyperlink. Here is an example how to add a hyperlink for food4rhino website.

![Hyperlink](Img\Hyperlink.png)

When you save it to .pdf and click it inside document - it will open the website.

**Tip:** If you give the path to your local folder / file instead of the website address to the Link input - you can open this location / folder / file inside Typora by clicking ctrl + left mouse button on a hyperlink. Example:

![Hyperlink2](Img\Hyperlink2.png)

#### Page Break

Page Break component can be helpful when you try to force creation of another page where you exactly want. It will be visible only in your exported .pdf.

![PageBreakBefore](Img\PageBreakBefore.png)

#### Quote

![Quote](Img\Quote.png)

#### Table

To add table use Table component. It takes 3 inputs: Table Headings, Alignment and Data Tree. These are three different inputs, but all of these are related with each other, and all are needed to create a table.

![Table](Img\Table.png)

As you can see to add Data Tree you need to create a tree where each branch will be a list of rows for each column.

There are few requirements to create a table:

- The number of headings, alignments and branches of data tree have to be the same
- The number of rows in each branch have to be the same

In alignment input there are options from 0 to 2. It works like this:

![TableAlignment](Img\TableAlignment.png)

So basically alignment are set for whole column.

#### Ordered List / Unordered List

Ordered List and Unordered List component work basically the same. All you need to do is to add items of the list to Items input, like that:

![Lists](Img\Lists.png)

#### Task List

What is different in Task List is the ability to choose if the item of the list is done or not.

![TaskList](Img\TaskList.png)

The number of tasks and the number of boolean values for Done input must be the same. 

#### Code Block

Code block can be helpful when you want to add some part of your code to your report.

![CodeBlock](Img\CodeBlock.png)

The syntax highlight will be added automatically depending on a language given as an input.

There are many things that you can do with that. For example:

![CodeBlockExample](Img\CodeBlockExample.png)

So that way you can combine code block with the results of those blocks.

Of course other languages syntax also will be highlighted, for example:

![CodeBlockC#Example](Img\CodeBlockCSharpExample.png)

#### Math Block

Math Block will help you to create beautiful and complex equations. It let you write them in TeX, for example:

![MathBlock](Img\MathBlock.png)

You don't need to learn all the TeX syntax if you don't want to - there are many websites that will help you to build complex equations without knowing anything about LaTeX. For example:

https://www.latex4technics.com/

With this website you can create those complex definitions just by clicking on a different symbols. Then you can just copy-paste the result to Text input of Math Block component.

#### Dynamic Math Block

Dynamic math block let you combine writing complex equations with dynamically changing variables.

![DynamicMathBlock1](Img\DynamicMathBlock1.png)

As you can see above: when you put the variable name in Text input in angle brackets, then it will automatically change it's value to the Variable Value. You can do the same with multiple variables like this:

![DynamicMathBlock2](Img\DynamicMathBlock2.png)

This can be helpful to create reports of your calculations. Look at the Math Block to read more about LaTeX syntax that can be used here as well.

#### Image

If you want to add an image to your report - use Image component. All you need to do is to add a title of your image, and path to this file.

![Image](Img\Image.png)

Remember that path need to contain a file name with the extension (like .png for example). 

#### Viewport

Viewport component let you capture the viewport to .png file and insert it to your report.

Viewport Name input must be the same as the name of your viewport that you want to capture. It captures current position / view of your elements that are inside that viewport.

![Viewport](Img\Viewport.png)

There are multiple settings that you can set to change the result image. Also changing the style of the viewport or the size of it will affect the result .png file:

![Viewport1](C:\Users\EngineerDesign\Desktop\Projekty\Pterodactyl\Pterodactyl\Manual\Img\Viewport1.png)

Sometimes there is a need to click "Recompute" inside Grasshopper to refresh the image shown in Typora. To do this click right mouse button anywhere in Grasshopper and click Recompute.

## Report

![Report](Img\Report.png)

### About

Report components are the main components of the Pterodactyl plug-in. They are always required to create the report and open it with the Typora or other Markdown editor.

![ReportExample](Img\ReportExample.png)

### Components

#### Create Report

Create Report component will create your report, but to save it and open you need to use Save Report component.

To create the report plug all the Report Parts you have to the Report Parts input. The order of this list of Report Parts will be the order of all those parts in your document:

![CreateReport1](Img\CreateReport1.png)

If you have to manage multiple parts - Entwine component (which is build in component in Grasshopper) can be helpful. That way it's easier to have a control of an order of report parts:

![CreateReport2](Img\CreateReport2.png)

Remember to flatten the output of Entwine (right click on the output -> Flatten).

You can set a Title and Table of Contents for the document here:

![CreateReport3](Img\CreateReport3.png)

To open the document - see the Save Report component.

#### Save Report

Save Report component allow you to save your created report and open it in your favorite Markdown editor.

 ![SaveReport1](Img\SaveReport1.png)

To save the report you need to connect Create Report output and a path where your report will be saved. Remember that path need to have a name of the file at the end with .md extension for example: *C:\Users\MyUserName\Desktop\MyReport.md*

Save Report will create a .md file in the given location. You can open this file with any Markdown editor (Typora recommended). 

File can be constantly opened in Typora, but remember that it won't always refresh after changes - not all changes in Grasshopper will make Typora refresh, (but most of them will). To make sure it'll refresh try some of these options:

- Recompute document inside Grasshopper (right click anywhere in Grasshopper -> Recompute)
- Click on a Typora
- Close and reopen Typora

Many Markdown editors (like Mark Text) won't allow you to do constant changes outside editors (with Grasshopper) and they want you to confirm that you're going to change document externally every time something changes.

## Tools

![Tools](Img\Tools.png)

### About

Tools component are the components based on Mermaid: https://mermaid-js.github.io/

### Pie Chart

![PieChartTool](Img\PieChartTool.png)

Categories and Values must have the same number of elements.

You can also create pie chart with another component in Basic Graph group - called also Pie Chart.

### Flowchart Tools

Above you'll find all the components that will help you to build flowcharts.

Creating flowchart can help you for example to document your complex Grasshopper definitions.

In flowchart you have nodes and links between those nodes:

![Flowchart0](Img\Flowchart0.png)

To start flowchart we need to use Flowchart Start Node, then we connect Flowchart Nodes or Links, then at the end we connect end Flowchart Nodes to Flowchart component that will create Report Part.

To modify the link between both nodes - we need to add Flowchart Link component between those nodes:

![FlowchartModifiedLink](Img\FlowchartModifiedLink.png)

There are 4 types (0 - 3) of link that you can choose.

You can as well change a style of a node (change the shape of it):



## Typora Tips

