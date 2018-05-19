Imports Microsoft.VisualBasic
Imports System
Namespace LineOfBestFit
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim xyDiagram2 As New DevExpress.XtraCharts.XYDiagram()
			Dim series2 As New DevExpress.XtraCharts.Series()
			Dim pointSeriesLabel2 As New DevExpress.XtraCharts.PointSeriesLabel()
			Dim pointSeriesView3 As New DevExpress.XtraCharts.PointSeriesView()
			Dim pointSeriesView4 As New DevExpress.XtraCharts.PointSeriesView()
			Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
			Me.button1 = New System.Windows.Forms.Button()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(xyDiagram2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(series2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(pointSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(pointSeriesView3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(pointSeriesView4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' chartControl1
			' 
			xyDiagram2.AxisX.Range.SideMarginsEnabled = True
			xyDiagram2.AxisX.VisibleInPanesSerializable = "-1"
			xyDiagram2.AxisY.Range.SideMarginsEnabled = True
			xyDiagram2.AxisY.VisibleInPanesSerializable = "-1"
			Me.chartControl1.Diagram = xyDiagram2
			Me.chartControl1.Location = New System.Drawing.Point(11, 22)
			Me.chartControl1.Name = "chartControl1"
			series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
			pointSeriesLabel2.OverlappingOptionsTypeName = "PointOverlappingOptions"
			pointSeriesLabel2.Visible = False
			series2.Label = pointSeriesLabel2
			series2.Name = "Series 1"
			series2.View = pointSeriesView3
			Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() { series2}
			Me.chartControl1.SeriesTemplate.View = pointSeriesView4
			Me.chartControl1.Size = New System.Drawing.Size(693, 490)
			Me.chartControl1.TabIndex = 0
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(35, 529)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(235, 52)
			Me.button1.TabIndex = 1
			Me.button1.Text = "Show Line of Best Fit"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(319, 561)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(263, 20)
			Me.textBox1.TabIndex = 2
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.label1.Location = New System.Drawing.Point(366, 529)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(167, 20)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Correlation coefficient:"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(716, 593)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.chartControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(xyDiagram2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(pointSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(pointSeriesView3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(series2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(pointSeriesView4, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.chartControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private chartControl1 As DevExpress.XtraCharts.ChartControl
		Private WithEvents button1 As System.Windows.Forms.Button
		Private textBox1 As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace

