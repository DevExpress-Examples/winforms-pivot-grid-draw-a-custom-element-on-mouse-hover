<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581926/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2228)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Pivot Grid for WinForms - Draw a Custom Element When a User Hovers Over a Field Value with a Mouse

This example shows how to determine whether the mouse is hovered on [Field Value](https://docs.devexpress.com/WindowsForms/1694/controls-and-libraries/pivot-grid/ui-elements/field-value) and redraw the corresponding element. The [PivotGridControl.CustomDrawFieldValue](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CustomDrawFieldValue) event occurs before painting the field value, total header, grand total header, or data field header. The [PivotGridControl.CalcHitInfo](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CalcHitInfo(System.Drawing.Point)) method call handles the `MouseMove` event to determine whether the Field Value is hovered.

## Files to Review

* [Form1.cs](./CS/WindowsApplication73/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication73/Form1.vb))
* [Program.cs](./CS/WindowsApplication73/Program.cs) (VB: [Program.vb](./VB/WindowsApplication73/Program.vb))

## Documentation

- [Custom Draw for Pivot Grid](https://docs.devexpress.com/WindowsForms/1817/controls-and-libraries/pivot-grid/appearance/custom-draw)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-pivot-grid-draw-a-custom-element-on-mouse-hover&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-pivot-grid-draw-a-custom-element-on-mouse-hover&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
