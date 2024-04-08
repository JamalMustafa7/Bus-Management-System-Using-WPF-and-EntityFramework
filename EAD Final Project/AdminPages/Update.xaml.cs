using EAD_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Page
    {
        Vehicle toUpdate;
        public Update(Vehicle v)
        {
            InitializeComponent();
            this.toUpdate = v;
            numberPlate.Text = toUpdate.NumberPlateNumber;
            chasisNumber.Text = toUpdate.ChasisNumber;
            Year.Text = toUpdate.YearOfRegistration.ToString();
            foreach(ComboBoxItem item in combobox.Items)
            {
                if(item.Content.ToString()==toUpdate.VType)
                {
                    combobox.SelectedItem = item;
                    break;
                }
            }
        }
        private void myComboBox_DropDownOpened(object sender, EventArgs e)
        {
            combobox.VerticalAlignment = VerticalAlignment.Top;
        }

        private void myComboBox_DropDownClosed(object sender, EventArgs e)
        {
            combobox.VerticalAlignment = VerticalAlignment.Center;
        }

        private void UpdateVehicle(object sender, RoutedEventArgs e)
        {
            string year = Year.Text;
            try
            {
                Convert.ToInt32(year);
            }
            catch
            {
                return;
            }

            string content = (combobox.SelectedItem as ComboBoxItem).Content.ToString();
            string oldNumberPlateNumber = toUpdate.NumberPlateNumber;
            
            if(DBHandler.context.Vehicles.Find(numberPlate.Text) == null ) {

                //Making New Vehicle
                Vehicle UpdatedKey = new Vehicle { NumberPlateNumber = numberPlate.Text, ChasisNumber = chasisNumber.Text, YearOfRegistration = Convert.ToInt16(year), VType = content };
                DBHandler.context.Vehicles.Add(UpdatedKey);
                DBHandler.context.SaveChanges();
                //Updating Dependant Entries with Primary Key of Currently Inserted Vehicle
                var relatedEntities = DBHandler.context.VehicleEntries.Where(r => r.NumberPlateNumber == oldNumberPlateNumber).ToList();
                foreach (var relatedEntity in relatedEntities)
                {
                    relatedEntity.NumberPlateNumber = numberPlate.Text;
                }


                DBHandler.context.SaveChanges();
                //Deleting Old Vehicle
                Vehicle v = DBHandler.context.Vehicles.FirstOrDefault(x => x.NumberPlateNumber == oldNumberPlateNumber) as Vehicle;
                DBHandler.context.Vehicles.Remove(v);
                DBHandler.context.SaveChanges();
                MessageBox.Show("Vehicle information has been successfully updated.", "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                Admin.changePage("VV");
            }
            else if(oldNumberPlateNumber==numberPlate.Text)
            {
                toUpdate.ChasisNumber = chasisNumber.Text;
                toUpdate.YearOfRegistration = Convert.ToInt16(year);
                Vehicle UpdatedKey = new Vehicle { NumberPlateNumber = numberPlate.Text, ChasisNumber = chasisNumber.Text, YearOfRegistration = Convert.ToInt16(year), VType = content };
                toUpdate.VType = content;
                DBHandler.context.SaveChanges();
                MessageBox.Show("Vehicle information has been successfully updated.", "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                Admin.changePage("VV");
            }
            else
            {
                MessageBox.Show($"A vehicle with the number plate '{numberPlate.Text}' already exists.", "Duplicate Entry", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
