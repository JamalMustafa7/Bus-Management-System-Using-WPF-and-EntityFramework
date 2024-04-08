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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Page
    {
        User toUpdate;
        public Update(User u)
        {
            InitializeComponent();
            email.Text = u.Email;
            password.Text = u.Password;
            name.Text = u.Name;
            toUpdate = u;
            combobox.SelectedIndex = u.Role;
        }

        private void UpdateProfile(object sender, RoutedEventArgs e)
        {
            if(email.Text=="" || password.Text=="" || name.Text=="")
            {
                MessageBox.Show("All Fields Should be Filled", "Cant Add Profile", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(DBHandler.context.Users.Find(email.Text)!=null)
            {
                MessageBox.Show("User Aleady Exists with that email","Redundancy",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            if(email.Text!=toUpdate.Email)
            {
                DBHandler.context.Users.Remove(toUpdate);
                DBHandler.context.SaveChanges();
                DBHandler.context.Add(new User { Email=email.Text, Password=password.Text ,Name=name.Text,Role=combobox.SelectedIndex});
                DBHandler.context.SaveChanges();
                MessageBox.Show("User Updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                Admin.changePage("VP");
                return;
            }
            toUpdate.Email = email.Text;
            toUpdate.Password = password.Text;
            toUpdate.Name= name.Text;
            toUpdate.Role= combobox.SelectedIndex;
            DBHandler.context.SaveChanges();
            MessageBox.Show("User Updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            SuperAdmin.changePage("VP");
        }
    }
}
