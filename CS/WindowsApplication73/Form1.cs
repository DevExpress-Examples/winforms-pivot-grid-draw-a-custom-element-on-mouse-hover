using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;

namespace WindowsApplication73
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pivotGridControl1.DataSource = CreateTable(500);
            pivotGridControl1.RetrieveFields();
            pivotGridControl1.Fields["Order"].Area = PivotArea.RowArea;
            pivotGridControl1.Fields["Type"].Area = PivotArea.ColumnArea;
            pivotGridControl1.Fields["Number"].Area = PivotArea.DataArea;
        }
        private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Order", typeof(string));
            tbl.Columns.Add("Type", typeof(string));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { "Order "+ i % 7 , "Type " + i % 4, (i * 24) % 87 , DateTime.Now.AddDays(i) });
            return tbl;
        }
        Point mousePos = new Point();
        BaseViewInfo viewInfo;
        int offset = 5;

        private void pivotGridControl1_CustomDrawFieldValue(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs e)
        {
            if (mousePos != Point.Empty && e.Bounds.Contains(mousePos))
            {
                e.Painter.DrawObject(e.Info);
                Size rectSize = new Size(12, 12);
                Point rectPos = new Point(e.Bounds.Right - rectSize.Width  - offset, e.Bounds.Top + offset);
                Rectangle rect = new Rectangle(rectPos, rectSize);

                e.Graphics.FillRectangle(Brushes.Chartreuse, rect);
                e.Handled = true;
            }
        }

        private void pivotGridControl1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = Point.Empty;
            PivotGridHitInfo info = pivotGridControl1.CalcHitInfo(e.Location);
            if (info.HitTest == PivotGridHitTest.Value)
            {
                mousePos = e.Location;
                BaseViewInfo newVI = ((PivotGridViewInfoData)info.ValueInfo.Data).ViewInfo.GetViewInfoAtPoint(e.Location);
                if (!object.ReferenceEquals(newVI, viewInfo))
                {
                    pivotGridControl1.Invalidate(newVI.PaintBounds);
                    if (viewInfo != null)
                        pivotGridControl1.Invalidate(viewInfo.PaintBounds);
                    viewInfo = newVI;
                }
            }
            else
            {
                if (viewInfo != null)
                    pivotGridControl1.Invalidate(viewInfo.PaintBounds);
                viewInfo = null;
            }
        }

        private void pivotGridControl1_MouseLeave(object sender, EventArgs e)
        {
            viewInfo = null;
            mousePos = Point.Empty;
        }

    }
}
