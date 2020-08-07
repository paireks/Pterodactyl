# Manual for Pterodactyl 1.2.0

[TOC]

## Introduction

Hey! Thank you for using Pterodactyl! ;)

Pterodactyl is an open-source plug-in for Grasshopper.

**Purpose:** creating reports inside Grasshopper. Those reports or documents can be later saved to pdf/html/docx/LaTeX files.

**Requirements:**

- Rhino 6 or 7
- Markdown editor, Typora is recommended (free during beta: https://typora.io/), or if you look for something open-source, check Mark Text (https://marktext.app/)

**Contact:** If you have any specific questions, email me: w.radaczynski@gmail.com

**Tutorials:** You can find many tutorials on my YT channel here: https://www.youtube.com/channel/UCfXkMo1rOMhKGBoNwd7JPsw

### License

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

### About

Advanced Graph component will help you to create complex graph with many different data, styles, etc.

## Basic Graphs

### About

Basic Graphs components will help you to create simple graphs and charts. With one big component you will create a simple graph. If you need more complex graph - check out Advanced Graph components.

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



## Report

## Tools

## Typora Tips