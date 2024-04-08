using EAD_Final_Project.GuardPages;
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
    /// Interaction logic for Guard.xaml
    /// </summary>
    public partial class Guard : Window
    {
        public Guard()
        {
            InitializeComponent();
        }

        private void vehicleIn(object sender, RoutedEventArgs e)
        {
            In guardIn = new In(); 
            frame.NavigationService.Navigate(guardIn);
        }

        private void vehicleOut(object sender, RoutedEventArgs e)
        {
            
            Out guardOut = new Out(); 
            frame.NavigationService.Navigate(guardOut);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow.GetVisible(this);
        }
    }
}
