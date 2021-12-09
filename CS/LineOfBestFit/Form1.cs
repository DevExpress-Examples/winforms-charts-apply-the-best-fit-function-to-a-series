using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace LineOfBestFit {
    public partial class Form1 : Form {
        public static double r;
        private string tag = "BestFit";

        public void GetPointForLinearRegression(Series series) {
            var points = new SeriesPoint[2];
            double mx = 0d;
            double my = 0d;
            double mxy = 0d;
            double mx2 = 0d;
            double sx = 0d;
            double sy = 0d;
            double a = 0d;
            double b = 0d;
            double corr = 0d;
            double minValue = double.MaxValue;
            double maxValue = double.MinValue;
            int n = chartControl1.Series[0].Points.Count;
            foreach (SeriesPoint sp in chartControl1.Series[0].Points) {
                if (Convert.ToDouble(sp.Argument) < minValue) {
                    minValue = Convert.ToDouble(sp.Argument);
                }
                if (Convert.ToDouble(sp.Argument) > maxValue) {
                    maxValue = Convert.ToDouble(sp.Argument);
                }
                mx += Convert.ToDouble(sp.Argument);
                my += sp.Values[0];
                mxy += Convert.ToDouble(sp.Argument) * sp.Values[0];
                mx2 += Math.Pow(Convert.ToDouble(sp.Argument), 2);
            }
            try {
                a = (my / mx - mxy / mx2) / (n / mx - mx / mx2);
                b = (my / n - mxy / mx) / (mx / n - mx2 / mx);
            } catch {
            }
            points[0] = new SeriesPoint(minValue, new double[] { a + b * minValue });
            points[1] = new SeriesPoint(maxValue, new double[] { a + b * maxValue });
            mx = mx / n;
            my = my / n;
            foreach (SeriesPoint sp in series.Points) {
                sx += Math.Pow(Convert.ToDouble(sp.Argument) - mx, 2);
                sy += Math.Pow(sp.Values[0] - my, 2);
                corr += (Convert.ToDouble(sp.Argument) - mx) * (sp.Values[0] - my);
            }
            sx = Math.Pow(sx / n, 0.5d);
            sy = Math.Pow(sy / n, 0.5d);
            corr = corr / (n * sx * sy);
            r = corr;
            series.Points.Clear();
            series.Points.AddRange(points);
        }

        public Form1() {
            InitializeComponent();

            var dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            for (int i = 1; i <= 10; i++)
                dt.Rows.Add(i, i * 2);

            chartControl1.DataSource = dt;
            chartControl1.Series[0].ArgumentDataMember = "ProductID";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "Quantity" });
        }

        private void button1_Click(object sender, EventArgs e) {
            var BestFit = new Series("Line Of Best Fit", ViewType.Line);
            BestFit.ArgumentScaleType = ScaleType.Numerical;
            BestFit.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            BestFit.Tag = tag;
            this.chartControl1.Series.Add(BestFit);
            textBox1.Text = r.ToString();
            chartControl1.BoundDataChanged += chartControl1_BoundDataChanged;
        }

        private void chartControl1_BoundDataChanged(object sender, EventArgs e) {
            foreach (Series series in chartControl1.Series) {
                if ((string)series.Tag == tag) {
                    GetPointForLinearRegression(series);
                }
            }
        }
    }
}