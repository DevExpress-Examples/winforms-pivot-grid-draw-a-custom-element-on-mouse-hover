Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace WindowsApplication73

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            pivotGridControl1.DataSource = CreateTable(500)
            pivotGridControl1.RetrieveFields()
            pivotGridControl1.Fields("Order").Area = PivotArea.RowArea
            pivotGridControl1.Fields("Type").Area = PivotArea.ColumnArea
            pivotGridControl1.Fields("Number").Area = PivotArea.DataArea
        End Sub

        Private Function CreateTable(ByVal RowCount As Integer) As DataTable
            Dim tbl As DataTable = New DataTable()
            tbl.Columns.Add("Order", GetType(String))
            tbl.Columns.Add("Type", GetType(String))
            tbl.Columns.Add("Number", GetType(Integer))
            tbl.Columns.Add("Date", GetType(Date))
            For i As Integer = 0 To RowCount - 1
                tbl.Rows.Add(New Object() {"Order " & i Mod 7, "Type " & i Mod 4, i * 24 Mod 87, Date.Now.AddDays(i)})
            Next

            Return tbl
        End Function

        Private mousePos As Point = New Point()

        Private viewInfo As BaseViewInfo

        Private offset As Integer = 5

        Private Sub pivotGridControl1_CustomDrawFieldValue(ByVal sender As Object, ByVal e As PivotCustomDrawFieldValueEventArgs)
            If mousePos <> Point.Empty AndAlso e.Bounds.Contains(mousePos) Then
                e.Painter.DrawObject(e.Info)
                Dim rectSize As Size = New Size(12, 12)
                Dim rectPos As Point = New Point(e.Bounds.Right - rectSize.Width - offset, e.Bounds.Top + offset)
                Dim rect As Rectangle = New Rectangle(rectPos, rectSize)
                e.Graphics.FillRectangle(Brushes.Chartreuse, rect)
                e.Handled = True
            End If
        End Sub

        Private Sub pivotGridControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            mousePos = Point.Empty
            Dim info As PivotGridHitInfo = pivotGridControl1.CalcHitInfo(e.Location)
            If info.HitTest = PivotGridHitTest.Value Then
                mousePos = e.Location
                Dim newVI As BaseViewInfo = CType(info.ValueInfo.Data, PivotGridViewInfoData).ViewInfo.GetViewInfoAtPoint(e.Location)
                If Not ReferenceEquals(newVI, viewInfo) Then
                    pivotGridControl1.Invalidate(newVI.PaintBounds)
                    If viewInfo IsNot Nothing Then pivotGridControl1.Invalidate(viewInfo.PaintBounds)
                    viewInfo = newVI
                End If
            Else
                If viewInfo IsNot Nothing Then pivotGridControl1.Invalidate(viewInfo.PaintBounds)
                viewInfo = Nothing
            End If
        End Sub

        Private Sub pivotGridControl1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            viewInfo = Nothing
            mousePos = Point.Empty
        End Sub
    End Class
End Namespace
