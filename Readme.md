<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581926/22.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2228)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Pivot Grid for WinForms - How to draw a custom element when a user hovering over Field Value with a mouse

This example shows how to determine whether the mouse is hovered on [Field Value](https://docs.devexpress.com/WindowsForms/1694/controls-and-libraries/pivot-grid/ui-elements/field-value) and redraw the corresponding element. The [PivotGridControl.CustomDrawFieldValue](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CustomDrawFieldValue) event occurs before painting the field value, total header, grand total header, or data field header. The [PivotGridControl.CalcHitInfo](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CalcHitInfo(System.Drawing.Point)) method call handles the `MouseMove` event to determine whether the Field Value is hovered.

## Files to Review

* [Form1.cs](./CS/WindowsApplication73/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication73/Form1.vb))
* [Program.cs](./CS/WindowsApplication73/Program.cs) (VB: [Program.vb](./VB/WindowsApplication73/Program.vb))

## Documentation

- [Custom Draw for Pivot Grid](https://docs.devexpress.com/WindowsForms/1817/controls-and-libraries/pivot-grid/appearance/custom-draw)
