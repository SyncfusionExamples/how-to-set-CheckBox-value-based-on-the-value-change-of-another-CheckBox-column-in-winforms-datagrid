# How to set checkbox value based on the value change on another checkbox column in WinForms DataGrid (SfDataGrid)

## Change checkbox column value
You can set the value for a check box in one check box column when enabling or disabling it in another check box column using the [SfDataGrid.CellCheckBoxClick](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html?_ga=2.182698278.1225195101.1667794112-766490130.1650530957&_gl=1*1b0r2rr*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2Nzk4NTI1Mi4yOTMuMS4xNjY3OTg2NzkyLjAuMC4w) and [SfDataGrid.CurrentCellActivating](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html?_ga=2.182698278.1225195101.1667794112-766490130.1650530957&_gl=1*6vbrpv*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2Nzk4NTI1Mi4yOTMuMS4xNjY3OTg2ODQ4LjAuMC4w) events.

## C# 

```C#
this.sfDataGrid1.CellCheckBoxClick += sfDataGrid1_CellCheckBoxClick;
this.sfDataGrid1.CurrentCellActivating += sfDataGrid1_CurrentCellActivating;
 
void sfDataGrid1_CurrentCellActivating(object sender, CurrentCellActivatingEventArgs e)
{
    if (e.DataColumn.GridColumn.MappingName == "ClosedStatus")
        e.Cancel = true;
}
 
void sfDataGrid1_CellCheckBoxClick(object sender, CellCheckBoxClickEventArgs e)
{
 
    if (e.Column.MappingName == "ClosedStatus")
        e.Cancel = true;
 
    if (e.Column.MappingName == "IsClosed")
    {
        (e.Record as OrderInfo).ClosedStatus = e.NewValue == CheckState.Checked;
    }
}
```

## VB

```VB
AddHandler Me.sfDataGrid1.CellCheckBoxClick, AddressOf sfDataGrid1_CellCheckBoxClick
AddHandler Me.sfDataGrid1.CurrentCellActivating, AddressOf sfDataGrid1_CurrentCellActivating
 
Private Sub sfDataGrid1_CurrentCellActivating(ByVal sender As Object, ByVal e As CurrentCellActivatingEventArgs)
    If e.DataColumn.GridColumn.MappingName = "ClosedStatus" Then
        e.Cancel = True
    End If
End Sub
 
Private Sub sfDataGrid1_CellCheckBoxClick(ByVal sender As Object, ByVal e As CellCheckBoxClickEventArgs)
 
    If e.Column.MappingName = "ClosedStatus" Then
        e.Cancel = True
    End If
 
    If e.Column.MappingName = "IsClosed" Then
        TryCast(e.Record, OrderInfo).ClosedStatus = e.NewValue = CheckState.Checked
    End If
End Sub
```
