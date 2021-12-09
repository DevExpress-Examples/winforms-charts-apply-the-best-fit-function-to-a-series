Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

Namespace LineOfBestFit

    Public Partial Class Form1
        Inherits Form

        Public Shared r As Double

        Private tag As String = "BestFit"

        Public Sub GetPointForLinearRegression(ByVal series As Series)
            Dim points = New SeriesPoint(1) {}
            Dim mx As Double = 0R
            Dim my As Double = 0R
            Dim mxy As Double = 0R
            Dim mx2 As Double = 0R
            Dim sx As Double = 0R
            Dim sy As Double = 0R
            Dim a As Double = 0R
            Dim b As Double = 0R
            Dim corr As Double = 0R
            Dim minValue As Double = Double.MaxValue
            Dim maxValue As Double = Double.MinValue
            Dim n As Integer = chartControl1.Series(0).Points.Count
            For Each sp As SeriesPoint In chartControl1.Series(0).Points
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

            sx = Math.Pow(sx / n, 0.5R)
            sy = Math.Pow(sy / n, 0.5R)
            corr = corr / (n * sx * sy)
            r = corr
            series.Points.Clear()
            series.Points.AddRange(points)
        End Sub

        Public Sub New()
            InitializeComponent()
            Dim dt = New DataTable()
            dt.Columns.Add("ProductID", GetType(Integer))
            dt.Columns.Add("Quantity", GetType(Integer))
            For i As Integer = 1 To 10
                dt.Rows.Add(i, i * 2)
            Next

            chartControl1.DataSource = dt
            chartControl1.Series(0).ArgumentDataMember = "ProductID"
            chartControl1.Series(0).ValueDataMembers.AddRange(New String() {"Quantity"})
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim BestFit = New Series("Line Of Best Fit", ViewType.Line)
            BestFit.ArgumentScaleType = ScaleType.Numerical
            BestFit.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
            BestFit.Tag = tag
            chartControl1.Series.Add(BestFit)
            textBox1.Text = r.ToString()
            AddHandler chartControl1.BoundDataChanged, AddressOf chartControl1_BoundDataChanged
        End Sub

        Private Sub chartControl1_BoundDataChanged(ByVal sender As Object, ByVal e As EventArgs)
            For Each series As Series In chartControl1.Series
                If Equals(CStr(series.Tag), tag) Then
                    GetPointForLinearRegression(series)
                End If
            Next
        End Sub
    End Class
End Namespace
