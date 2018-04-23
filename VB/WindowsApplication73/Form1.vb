Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.XtraPivotGrid

Namespace WindowsApplication73
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			pivotGridControl1.DataSource = CreateTable(500)
			pivotGridControl1.RetrieveFields()
			pivotGridControl1.Fields("Order").Area = PivotArea.RowArea
			pivotGridControl1.Fields("Type").Area = PivotArea.ColumnArea
			pivotGridControl1.Fields("Number").Area = PivotArea.DataArea
		End Sub
		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Order", GetType(String))
			tbl.Columns.Add("Type", GetType(String))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { "Order " & i Mod 7, "Type " & i Mod 4, (i * 24) Mod 87, DateTime.Now.AddDays(i) })
			Next i
			Return tbl
		End Function
		Private mousePos As New Point()
		Private viewInfo As BaseViewInfo
		Private offset As Integer = 5

		Private Sub pivotGridControl1_CustomDrawFieldValue(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs) Handles pivotGridControl1.CustomDrawFieldValue
			If mousePos <> Point.Empty AndAlso e.Bounds.Contains(mousePos) Then
				e.Painter.DrawObject(e.Info)
				Dim rectSize As New Size(12, 12)
				Dim rectPos As New Point(e.Bounds.Right - rectSize.Width - offset, e.Bounds.Top + offset)
				Dim rect As New Rectangle(rectPos, rectSize)

				e.Graphics.FillRectangle(Brushes.Chartreuse, rect)
				e.Handled = True
			End If
		End Sub

		Private Sub pivotGridControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pivotGridControl1.MouseMove
			mousePos = Point.Empty
			Dim info As PivotGridHitInfo = pivotGridControl1.CalcHitInfo(e.Location)
			If info.HitTest = PivotGridHitTest.Value Then
				mousePos = e.Location
				Dim newVI As BaseViewInfo = info.ValueInfo.Data.ViewInfo.GetViewInfoAtPoint(e.Location)
				If (Not Object.ReferenceEquals(newVI, viewInfo)) Then
					pivotGridControl1.Invalidate(newVI.PaintBounds)
					If viewInfo IsNot Nothing Then
						pivotGridControl1.Invalidate(viewInfo.PaintBounds)
					End If
					viewInfo = newVI
				End If
			Else
				If viewInfo IsNot Nothing Then
					pivotGridControl1.Invalidate(viewInfo.PaintBounds)
				End If
				viewInfo = Nothing
			End If
		End Sub

		Private Sub pivotGridControl1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles pivotGridControl1.MouseLeave
			viewInfo = Nothing
			mousePos = Point.Empty
		End Sub

	End Class
End Namespace