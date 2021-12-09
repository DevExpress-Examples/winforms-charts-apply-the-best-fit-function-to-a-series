Namespace LineOfBestFit

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim xyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
            Dim series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim pointSeriesView1 As DevExpress.XtraCharts.PointSeriesView = New DevExpress.XtraCharts.PointSeriesView()
            Dim pointSeriesView2 As DevExpress.XtraCharts.PointSeriesView = New DevExpress.XtraCharts.PointSeriesView()
            Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
            Me.button1 = New System.Windows.Forms.Button()
            Me.textBox1 = New System.Windows.Forms.TextBox()
            Me.label1 = New System.Windows.Forms.Label()
            CType((Me.chartControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((xyDiagram1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((series1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((pointSeriesView1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((pointSeriesView2), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' chartControl1
            ' 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
            Me.chartControl1.Diagram = xyDiagram1
            Me.chartControl1.Location = New System.Drawing.Point(1, 1)
            Me.chartControl1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
            Me.chartControl1.Name = "chartControl1"
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
            series1.Name = "Series 1"
            series1.View = pointSeriesView1
            Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {series1}
            Me.chartControl1.SeriesTemplate.View = pointSeriesView2
            Me.chartControl1.Size = New System.Drawing.Size(1035, 567)
            Me.chartControl1.TabIndex = 0
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(781, 583)
            Me.button1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(255, 59)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Show Line of Best Fit"
            Me.button1.UseVisualStyleBackColor = True
            AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
            ' 
            ' textBox1
            ' 
            Me.textBox1.Location = New System.Drawing.Point(1, 614)
            Me.textBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
            Me.textBox1.Name = "textBox1"
            Me.textBox1.Size = New System.Drawing.Size(222, 31)
            Me.textBox1.TabIndex = 2
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(-4, 583)
            Me.label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(227, 25)
            Me.label1.TabIndex = 3
            Me.label1.Text = "Correlation coefficient:"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(12F, 25F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1040, 653)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.textBox1)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.chartControl1)
            Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((xyDiagram1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((pointSeriesView1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((series1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((pointSeriesView2), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.chartControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

#End Region
        Private chartControl1 As DevExpress.XtraCharts.ChartControl

        Private button1 As System.Windows.Forms.Button

        Private textBox1 As System.Windows.Forms.TextBox

        Private label1 As System.Windows.Forms.Label
    End Class
End Namespace
