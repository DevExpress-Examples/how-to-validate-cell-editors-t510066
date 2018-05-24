Public NotInheritable Class MainPage
    Inherits Page

    Private Sub GridSpinEditColumn_Validate(sender As Object, e As DevExpress.UI.Xaml.Grid.Native.GridCellValidationEventArgs)
        Dim discontinued As Boolean = DirectCast(e.Row, Product).Discontinued
        If discontinued Then
            Dim discount As Double = 100 - (Convert.ToDouble(e.Value) * 100) / Convert.ToDouble(e.CellValue)
            If Not (discount > 0 AndAlso discount <= 30) Then
                e.Handled = True
                e.IsValid = False
                e.ErrorType = DevExpress.UI.Xaml.Editors.Native.ErrorType.Critical
                If discount < 0 Then
                    e.ErrorContent = String.Format("The price cannot be greater than ${0}", Convert.ToDouble(e.CellValue))
                    Return
                End If
                e.ErrorContent = String.Format("The discount cannot be greater than 30% (${0}). Please correct the price.", Convert.ToDouble(e.CellValue) * 0.7)
                e.Handled = True
            End If
        End If

    End Sub
End Class
