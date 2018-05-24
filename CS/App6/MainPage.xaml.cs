using DevExpress.UI.Xaml.Grid.Native;
using System;
using Windows.UI.Xaml.Controls;

namespace App6
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private void GridSpinEditColumn_Validate(object sender, GridCellValidationEventArgs e)
        {
            bool discontinued = ((Product)e.Row).Discontinued;
            if (discontinued)
            {
                double discount = 100 - (Convert.ToDouble(e.Value) * 100) / 
                    Convert.ToDouble(e.CellValue);
                if (!(discount > 0 && discount <= 30))
                {
                    e.Handled = true;
                    e.IsValid = false;
                    e.ErrorType = DevExpress.UI.Xaml.Editors.Native.ErrorType.Critical;
                    if (discount < 0)
                    {
                        e.ErrorContent = string.Format("The price cannot be greater than ${0}",
                                                    Convert.ToDouble(e.CellValue));
                        return;
                    }
                    e.ErrorContent = string.Format(
                       "The discount cannot be greater than 30% (${0}). Please correct the price.",
                       Convert.ToDouble(e.CellValue) * 0.7);
                    e.Handled = true;
                }
            }
        }
    }
}
