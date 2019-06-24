<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/LineOfBestFit/Form1.cs) (VB: [Form1.vb](./VB/LineOfBestFit/Form1.vb))
* [Program.cs](./CS/LineOfBestFit/Program.cs) (VB: [Program.vb](./VB/LineOfBestFit/Program.vb))
<!-- default file list end -->
# Obsolete - How to implement the best fit function, and apply it to a chart's series
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1300)**
<!-- run online end -->


<p><strong>[OBSOLETE WARNING] </strong>The approach shown in this example is not applicable in recent versions (v16.1 and later). It is recommended to calculate the "Best Fit" data using the ChartControl.<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraChartsChartControl_BoundDataChangedtopic">BoundDataChanged</a> event handler (see a similar approach shown in the <a href="https://www.devexpress.com/Support/Center/p/T485375">Unhandled runtime error when implementing a custom summary function</a> ticket).<br><br><em>Original description:</em><br>This example demonstrates how to implement the best fit function and apply it to a chart's series.</p>


<h3>Description</h3>

<p>To accomplish this task, it is necessary to manually perform the required data analysis, and then display the corresponding line series within your chart.<br />
In this example, the approach of registering custom summary functions within a particular chart instance is used to implement all necessary calculations. Also additional calculations are implemented within the summary function in order to determine the correlation coefficient.</p>

<br/>


