# Pterodactyl

[TOC]

![logo pterodactyl 650x650px](C:\Users\EngineerDesign\Desktop\Projekty\Pterodactyl\Pterodactyl\logo pterodactyl 650x650px.png)

## Purpose

Pterodactyl is an open-source plug-in for Grasshopper (Rhino 6) created for the purpose of generating custom documents, reports, articles, etc. that can be updated in real time. 

## How it works?

Pterodactyl sends data (saves it locally) as .md, which is Markdown filename extension. To open it or to save it as PDF or HTML, you need Typora, which is completely free, lightweight text editor. You can download it [here](https://typora.io/).

Basically it works like this:



```mermaid
graph LR
	subgraph Create, change and see updates of your document in real time
    A[Grasshopper with Pterodactyl] -->|.md file| B(Typora)
    end
    B -->D[.pdf]
    B -->E[.html]
```

You can try other Markdown editors, Typora is recommended. 



## Features (1.0.0)

![2020-05-17_22h31_06](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h31_53.png)

- Format text (strong, emphasis, underline, strike) ![2020-05-17_22h25_48](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h25_48.png)
- Insert images ![2020-05-17_22h26_38](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h26_38.png)
- Create tables ![2020-05-17_22h27_11](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h27_11.png)
- Create lists (ordered list, unordered list, task list)  ![2020-05-17_22h35_11](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h35_11.png)
- Capture and insert Rhino viewports![2020-05-17_22h36_02](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h36_02.png)
- Create pie charts ![2020-05-17_22h36_44](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h36_44.png)
- Creates and saves report ![2020-05-17_22h27_45](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h27_45.png)
- Add hyperlinks ![2020-05-17_22h37_37](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h37_37.png)
- Add quote ![2020-05-17_22h37_50](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h37_50.png)
- Add heading ![2020-05-17_22h38_03](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h38_03.png)
- Math block - write math equations in TeX-style ![2020-05-17_22h41_22](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h41_22.png)
- Dynamic math block - write math equations with dynamically changing variables in TeX-style ![2020-05-17_22h42_39](C:\Users\EngineerDesign\Pictures\Screenpresso\2020-05-17_22h42_39.png)

## Future plans

- Reference links
- Math charts
- Graphs
- Karamba3D templates

## License (MIT License)

Copyright 2020 Wojciech Radaczyński

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

[Link to license](https://opensource.org/licenses/MIT)

## Tutorials

Examples will be posted in the future on my youtube channel, here: https://www.youtube.com/channel/UCfXkMo1rOMhKGBoNwd7JPsw

## Contact

You can email me anytime: w.radaczynski@gmail.com