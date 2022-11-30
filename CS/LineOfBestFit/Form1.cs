using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using DevExpress.Utils;
using DevExpress.XtraCharts;

namespace LineOfBestFit
{
    public partial class Form1 : Form
    {
        public static double r;

        private static SeriesPoint[] GetPointForLinearRegression(Series series, object argument,
            string[] functionArguments, DataSourceValues[] values, object[] colors)
        {            
            SeriesPoint[] points = new SeriesPoint[2];

            double mx = 0;
            double my = 0;
            double mxy = 0;
            double mx2 = 0;
            double sx = 0;
            double sy = 0;
            double a = 0;
            double b = 0;
            double corr = 0;
            double minValue = double.MaxValue;
            double maxValue = double.MinValue;

            int n = series.Points.Count;
            foreach (SeriesPoint sp in series.Points)
            {
                if (Convert.ToDouble(sp.Argument) < minValue)
                {
                    minValue = Convert.ToDouble(sp.Argument);
                }
                if (Convert.ToDouble(sp.Argument) > maxValue)
                {
                    maxValue = Convert.ToDouble(sp.Argument);
                }
                mx += Convert.ToDouble(sp.Argument);
                my += sp.Values[0];
                mxy += Convert.ToDouble(sp.Argument) * sp.Values[0];
                mx2 += Math.Pow(Convert.ToDouble(sp.Argument), 2);
            }
            try
            {
                a = (my / mx - mxy / mx2) / (n / mx - mx / mx2);
                b = (my / n - mxy / mx) / (mx / n - mx2 / mx);
            }
            catch
            {
            }
            points[0] = new SeriesPoint(minValue, new double[] { a + b * minValue });
            points[1] = new SeriesPoint(maxValue, new double[] { a + b * maxValue });

            mx = mx / n;
            my = my / n;
            foreach (SeriesPoint sp in series.Points)
            {
                sx += Math.Pow(Convert.ToDouble(sp.Argument) - mx, 2);
                sy += Math.Pow(sp.Values[0] - my, 2);
                corr += (Convert.ToDouble(sp.Argument) - mx) * (sp.Values[0] - my);
            }
            sx = Math.Pow(sx / n, 0.5);
            sy = Math.Pow(sy / n, 0.5);
            corr = corr / (n * sx * sy);
            r = corr;

            return points;            
        }
        public Form1()
        {
            InitializeComponent();
            chartControl1.RegisterSummaryFunction("BESTFIT", "BESTFIT", 1, null, GetPointForLinearRegression);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("MyDataTable");
            dt.Columns.Add("MyArg", typeof(double));
            dt.Columns.Add("MyData", typeof(double));
            Random rnd = new Random();
            for (double x = -2; x <= 9; x++)
            {
                dt.Rows.Add(new object[] { x, rnd.NextDouble() * 10 - 5 });                
            }

            ds.Tables.Add(dt);
            chartControl1.DataSource = ds.Tables["MyDataTable"];
            chartControl1.Series[0].ArgumentDataMember = "MyArg";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "MyData" });
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            Series BestFit = new Series("Line Of Best Fit", ViewType.Line);
            BestFit.ArgumentScaleType = ScaleType.Numerical;
            BestFit.LabelsVisibility = DefaultBoolean.False;
            this.chartControl1.Series.Add(BestFit);
            chartControl1.Series[1].ArgumentDataMember = "MyArg";
            chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "MyData" });
            this.chartControl1.Series[1].NumericSummaryOptions.SummaryFunction = "BESTFIT()";            
            this.textBox1.Text = r.ToString();

        }
    }
}
