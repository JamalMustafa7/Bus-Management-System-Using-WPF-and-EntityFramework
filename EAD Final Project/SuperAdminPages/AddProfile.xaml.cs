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

namespace EAD_Final_Project.SuperAdminPages
{
    /// <summary>
    /// Interaction logic for AddProfile.xaml
    /// </summary>
    public partial class AddProfile : Page
    {
        public AddProfile(int items)
        {
            InitializeComponent();
            ComboBoxItem item = new ComboBoxItem();
            item.Content = "Guard";
            item.Tag = 0;
            combobox.Items.Add(item);
            if (items == 2)
            {
                item = new ComboBoxItem();
                item.Content = "Admin";
                item.Tag = 1;
                combobox.Items.Add(item);

            }
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            if (email.Text == "" || password.Text == "" || name.Text == "")
            {
                MessageBox.Show("All Fields Should be Filled", "Cant Add Profile", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            User exixts = DBHandler.context.Users.Find(email.Text) as User;
            if (exixts == null)
            {
                User newUser = new User { Email = email.Text, Password = password.Text, Name = name.Text, Role = Convert.ToInt32((combobox.SelectedItem as ComboBoxItem).Tag) };
                DBHandler.context.Users.Add(newUser);
                DBHandler.context.SaveChanges();
                MessageBox.Show($"User Added with Role {newUser.Role}", "Added User", MessageBoxButton.OK, MessageBoxImage.Information);
                email.Text = "";
                password.Text = "";
                name.Text = "";
                combobox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Email Should Be Unique", "Redundent Email", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
