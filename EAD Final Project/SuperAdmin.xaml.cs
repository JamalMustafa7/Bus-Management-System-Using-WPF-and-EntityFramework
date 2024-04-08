using EAD_Final_Project.AdminPages;
using EAD_Final_Project.SuperAdminPages;
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
using System.Windows.Shapes;

namespace EAD_Final_Project
{
    /// <summary>
    /// Interaction logic for SuperAdmin.xaml
    /// </summary>
    public partial class SuperAdmin : Window
    {
        public static Frame SFrame { get; private set; } = new Frame();
        public SuperAdmin()
        {
            InitializeComponent();
            SFrame = frame;

        }
        
        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow.GetVisible(this);
        }
        private void AddVehicleFrame(object sender, RoutedEventArgs e)
        {
            Add page = new Add();
            frame.Navigate(page);
        }
        public static void changePage(string page)
        {
            if (page == "VV")
            {
                SFrame.Navigate(new ViewVehicles(SFrame));
            }
            else if(page =="VP")
            {
                SFrame.Navigate(new ViewProfile(SFrame,2));
            }

        }
        private void ViewVehicleFrame(object sender, RoutedEventArgs e)
        {
            ViewVehicles page = new ViewVehicles(frame);
            frame.Navigate(page);
        }

        private void ReportsFrame(object sender, RoutedEventArgs e)
        {
            Reports page = new Reports();
            frame.Navigate(page);
        }

        private void AddProfileFrame(object sender, RoutedEventArgs e)
        {
            AddProfile page=new AddProfile(2);
            frame.Navigate(page);
        }

        private void ViewProfilesFrame(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new ViewProfile(frame, 2));
        }
    }
}
