using EAD_Final_Project.Models;
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
    /// Interaction logic for ViewVehicles.xaml
    /// </summary>
    public partial class ViewVehicles : Page
    {
        Frame currentFrame;
        public ViewVehicles(Frame f)
        {
            InitializeComponent();
            datagrid.ItemsSource = DBHandler.context.Vehicles.ToList();
            currentFrame = f;
        }

        private void DeleteVehicle(object sender, RoutedEventArgs e)
        {
            Vehicle v = datagrid.SelectedItem as Vehicle;
            MessageBoxResult result = MessageBox.Show($"Vehicle with Number plate {v.NumberPlateNumber} will be deleted. Are you sure?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK)
            {
                //var relatedEntries = DBHandler.context.VehicleEntries.Where(entry => entry.NumberPlateNumber == v.NumberPlateNumber).ToList();
                //Already Handled in Cascade in Sql Table Schema
                //// Delete related entries first
                //foreach (var entry in relatedEntries)
                //{
                //    DBHandler.context.VehicleEntries.Remove(entry);
                //}
                // Now delete the vehicle itself
                DBHandler.context.Vehicles.Remove(v);
                DBHandler.context.SaveChanges();
                datagrid.ItemsSource=DBHandler.context.Vehicles.ToList();
            }
            else
            {
                return;
            }

        }

        private void UpdateFrame(object sender, RoutedEventArgs e)
        {
            Update page = new Update(datagrid.SelectedItem as Vehicle);
            currentFrame.Navigate(page);
        }
    }
}
