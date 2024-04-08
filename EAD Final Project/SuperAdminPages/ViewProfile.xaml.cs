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

namespace EAD_Final_Project.SuperAdminPages
{
    /// <summary>
    /// Interaction logic for ViewProfile.xaml
    /// </summary>
    /// 
    public partial class ViewProfile : Page
    {
        Frame currentFrame;
        int condition;
        public ViewProfile(Frame f,int c)
        {
            InitializeComponent();
            currentFrame = f;
            condition = c;
            datagrid.ItemsSource=DBHandler.context.Users.Where(user=>user.Role<condition).ToList();
        }

        private void UpdateFrame(object sender, RoutedEventArgs e)
        {
            Update page = new Update(datagrid.SelectedItem as User);
            currentFrame.Navigate(page);
        }

        private void DeleteProfile(object sender, RoutedEventArgs e)
        {
            User u = datagrid.SelectedItem as User;
            string email =u.Email;
            MessageBoxResult result = MessageBox.Show($"{u.Name} with email {u.Email} will be deleted. Are you sure?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(result==MessageBoxResult.OK)
            {
                DBHandler.context.Users.Remove(u);
                DBHandler.context.SaveChanges();
                datagrid.ItemsSource = DBHandler.context.Users.Where(user => user.Role <condition).ToList();
            }
        }
    }
}
