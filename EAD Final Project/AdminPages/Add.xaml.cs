using EAD_Final_Project.Models;
using System.Windows;
using System.Windows.Controls;


namespace EAD_Final_Project.AdminPages
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
        }

        private void myComboBox_DropDownOpened(object sender, EventArgs e)
        {
            combobox.VerticalAlignment = VerticalAlignment.Top;
        }

        private void myComboBox_DropDownClosed(object sender, EventArgs e)
        {
            combobox.VerticalAlignment = VerticalAlignment.Center;
        }

        private void RegisterVehicle(object sender, RoutedEventArgs e)
        {
            string year = Year.Text;
            try
            {
                Convert.ToInt32(year);
            }
            catch {
                return;
            }

            string content = (combobox.SelectedItem as ComboBoxItem).Content.ToString();
            Vehicle v = new Vehicle { NumberPlateNumber = numberPlate.Text, ChasisNumber = chasisNumber.Text,YearOfRegistration = Convert.ToInt16(year), VType =content};
            DBHandler.context.Vehicles.Add(v);
            DBHandler.context.SaveChanges();
            MessageBox.Show("Vehicle Added");
            numberPlate.Text = "";
            chasisNumber.Text = "";
            Year.Text = "";
            combobox.SelectedIndex = 0;
        }
    }
}
