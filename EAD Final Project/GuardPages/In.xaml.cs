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

namespace EAD_Final_Project.GuardPages
{
    /// <summary>
    /// Interaction logic for In.xaml
    /// </summary>
    public partial class In : Page
    {
        public In()
        {
            InitializeComponent();
            combobox.ItemsSource=DBHandler.context.Vehicles.ToList();
            combobox.SelectedItem= DBHandler.context.Vehicles.ToArray()[0];
        }

        private void AddVehicleEntry(object sender, RoutedEventArgs e)
        {
            if(combobox.SelectedItem!=null)
            {
                DBHandler.AddEntry(combobox.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Select a valid value");
            }
        }
    }
}
