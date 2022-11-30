Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraCharts

Namespace LineOfBestFit

    Public Partial Class Form1
        Inherits Form

        Public Shared r As Double

        Private Shared Function GetPointForLinearRegression(ByVal series As Series, ByVal argument As Object, ByVal functionArguments As String(), ByVal values As DataSourceValues(), ByVal colors As Object()) As SeriesPoint()
            Dim points As SeriesPoint() = New SeriesPoint(1) {}
            Dim mx As Double = 0
            Dim my As Double = 0
            Dim mxy As Double = 0
            Dim mx2 As Double = 0
            Dim sx As Double = 0
            Dim sy As Double = 0
            Dim a As Double = 0
            Dim b As Double = 0
            Dim corr As Double = 0
            Dim minValue As Double = Double.MaxValue
            Dim maxValue As Double = Double.MinValue
            Dim n As Integer = series.Points.Count
            For Each sp As SeriesPoint In series.Points
                If Convert.ToDouble(sp.Argument) < minValue Then
                    minValue = Convert.ToDouble(sp.Argument)
                End If

                If Convert.ToDouble(sp.Argument) > maxValue Then
                    maxValue = Convert.ToDouble(sp.Argument)
                End If

                mx += Convert.ToDouble(sp.Argument)
                my += sp.Values(0)
                mxy += Convert.ToDouble(sp.Argument) * sp.Values(0)
                mx2 += Math.Pow(Convert.ToDouble(sp.Argument), 2)
            Next

            Try
                a =(my / mx - mxy / mx2) / (n / mx - mx / mx2)
                b =(my / n - mxy / mx) / (mx / n - mx2 / mx)
            Catch
            End Try

            points(0) = New SeriesPoint(minValue, New Double() {a + b * minValue})
            points(1) = New SeriesPoint(maxValue, New Double() {a + b * maxValue})
            mx = mx / n
            my = my / n
            For Each sp As SeriesPoint In series.Points
                sx += Math.Pow(Convert.ToDouble(sp.Argument) - mx, 2)
                sy += Math.Pow(sp.Values(0) - my, 2)
                corr +=(Convert.ToDouble(sp.Argument) - mx) * (sp.Values(0) - my)
            Next

            sx = Math.Pow(sx / n, 0.5)
            sy = Math.Pow(sy / n, 0.5)
            corr = corr / (n * sx * sy)
            r = corr
            Return points
        End Function

        Public Sub New()
            InitializeComponent()
            chartControl1.RegisterSummaryFunction("BESTFIT", "BESTFIT", 1, Nothing, New SummaryFunction(AddressOf GetPointForLinearRegression))
            Dim ds As DataSet = New DataSet()
            Dim dt As DataTable = New DataTable("MyDataTable")
            dt.Columns.Add("MyArg", GetType(Double))
            dt.Columns.Add("MyData", GetType(Double))
            Dim rnd As Random = New Random()
            For x As Double = -2 To 9
                dt.Rows.Add(New Object() {x, rnd.NextDouble() * 10 - 5})
            Next

            ds.Tables.Add(dt)
            chartControl1.DataSource = ds.Tables("MyDataTable")
            chartControl1.Series(0).ArgumentDataMember = "MyArg"
            chartControl1.Series(0).ValueDataMembers.AddRange(New String() {"MyData"})
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim BestFit As Series = New Series("Line Of Best Fit", ViewType.Line)
            BestFit.ArgumentScaleType = ScaleType.Numerical
            BestFit.LabelsVisibility = DefaultBoolean.False
            chartControl1.Series.Add(BestFit)
            chartControl1.Series(1).ArgumentDataMember = "MyArg"
            chartControl1.Series(1).ValueDataMembers.AddRange(New String() {"MyData"})
            chartControl1.Series(1).NumericSummaryOptions.SummaryFunction = "BESTFIT()"
            textBox1.Text = r.ToString()
        End Sub
    End Class
End Namespace
