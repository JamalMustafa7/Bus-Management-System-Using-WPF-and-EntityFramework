using EAD_Final_Project.Models;
using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EAD_Final_Project.AdminPages
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {
        List<VehicleEntry> currentEntries;
        public Reports()
        {
            InitializeComponent();
            currentEntries = DBHandler.context.VehicleEntries.ToList();
            datagrid1.ItemsSource =currentEntries;
            combobox.SelectionChanged += HandleChange;
        }
        private void HandleTextChange(object sender, EventArgs e)
        {
            
            string text = t1.Text;
            if(text!="")
            {
                currentEntries=currentEntries.Where(entry => entry.NumberPlateNumber.StartsWith(text)).ToList();
                datagrid1.ItemsSource = currentEntries;
            }
            else
            {
                HandleChange(sender, e);
            }

            
        }
        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of OpenFileDialog
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = "datagrid_export"; // Default file name

            // Show the dialog and check if the user clicked OK
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Export data from the data grid to Excel
                ExportDataToExcel(datagrid1, filePath);

                MessageBox.Show("Data exported successfully!");
            }
        }

        private void ExportDataToExcel(DataGrid dataGrid, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Data");

            // Copy data from the data grid to Excel
            for (int i = 0; i < datagrid1.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = datagrid1.Columns[i].Header;
                for (int j = 0; j < datagrid1.Items.Count; j++)
                {
                    var vehicleEntry = (VehicleEntry)dataGrid.Items[j];
                    worksheet.Cells[i + 2, 1].Value = vehicleEntry.NumberPlateNumber;
                    worksheet.Cells[i + 2, 2].Value = vehicleEntry.In;
                    worksheet.Cells[i + 2, 3].Value = vehicleEntry.Out;
                    worksheet.Cells[i + 2, 4].Value = vehicleEntry.Status;
                }
            }

            // Save the Excel package to the specified file path
            excelPackage.SaveAs(new FileInfo(filePath));
        }
        private void HandleChange(object sender, EventArgs e)
        {
            ComboBoxItem item=combobox.SelectedItem as ComboBoxItem;
            int option=Convert.ToInt32(item.Tag);
            switch (option)
            {
                case 0:
                    currentEntries = DBHandler.context.VehicleEntries.ToList();
                    try
                    {

                        datagrid1.ItemsSource = currentEntries;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 1:
                    DateTime oneMonthAgo = DateTime.Now.AddMonths(-1); // Get the date one month ago
                    currentEntries = DBHandler.context.VehicleEntries.Where(entry => entry.In >= oneMonthAgo)
                        .ToList();
                    datagrid1.ItemsSource = currentEntries;

                    break;
                case 2:
                    DateTime weekAgo=DateTime.Now.AddDays(-7);
                    currentEntries = DBHandler.context.VehicleEntries.Where(entry => entry.In >= weekAgo).ToList();
                    datagrid1.ItemsSource = currentEntries;
                    break;
                case 3:
                    DateTime minutesAgo = DateTime.Now.AddMinutes(-10);
                    currentEntries = DBHandler.context.VehicleEntries.Where(entry => entry.In >= minutesAgo).ToList();
                    datagrid1.ItemsSource = currentEntries;
                    break;

            }
        }
    }
}
