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
    /// Interaction logic for Out.xaml
    /// </summary>
    public partial class Out : Page
    {
        public Out()
        {
            InitializeComponent();
            datagrid.ItemsSource = DBHandler.context.VehicleEntries.Where(x => x.Status == "in").ToList();
        }

        private void ChangeStatus(object sender, RoutedEventArgs e)
        {
            int id = (datagrid.SelectedItem as VehicleEntry).Id;
            DBHandler.setOutTime(id);
            datagrid.ItemsSource = DBHandler.context.VehicleEntries.Where(x => x.Status == "in").ToList();
        }
    }
}
