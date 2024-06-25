<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134061543/15.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1300)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/LineOfBestFit/Form1.cs) (VB: [Form1.vb](./VB/LineOfBestFit/Form1.vb))
* [Program.cs](./CS/LineOfBestFit/Program.cs) (VB: [Program.vb](./VB/LineOfBestFit/Program.vb))
<!-- default file list end -->
# Obsolete - How to implement the best fit function, and apply it to a chart's series


<p><strong>[OBSOLETE WARNING] </strong>The approach shown in this example is not applicable in recent versions (v16.1 and later). It is recommended to calculate the "Best Fit" data using the ChartControl.<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraChartsChartControl_BoundDataChangedtopic">BoundDataChanged</a> event handler (see a similar approach shown in the <a href="https://www.devexpress.com/Support/Center/p/T485375">Unhandled runtime error when implementing a custom summary function</a> ticket).<br><br><em>Original description:</em><br>This example demonstrates how to implement the best fit function and apply it to a chart's series.</p>


<h3>Description</h3>

<p>To accomplish this task, it is necessary to manually perform the required data analysis, and then display the corresponding line series within your chart.<br />
In this example, the approach of registering custom summary functions within a particular chart instance is used to implement all necessary calculations. Also additional calculations are implemented within the summary function in order to determine the correlation coefficient.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-charts-apply-the-best-fit-function-to-a-series&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-charts-apply-the-best-fit-function-to-a-series&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
