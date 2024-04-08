using EAD_Final_Project.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EAD_Final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Window obj=new Window();
        static TextBox e=new TextBox();
        static PasswordBox pass=new PasswordBox();
        public MainWindow()
        {
            InitializeComponent();
            obj = this;
            e = email;
            pass = password;
        }
        public static void GetVisible(Window w)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to Logout?", "Confirmation", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                w.Close();
                e.Text = "";
                pass.Password = "";
                obj.Show();
            }
            else
            {
                return;
            }
        }
        private void Login(object sender, RoutedEventArgs e)
        {

            (int role,User u)=DBHandler.FindUser(email.Text);
            if (u != null)
            {
                if (password.Password == u.Password)
                {
                    //MessageBox.Show($"Logged in as {role}");
                    this.Hide();
                    Window obj=null;
                    switch(role)
                    {
                        case 0:
                            obj = new Guard();
                            break;
                        case 1:
                            obj = new Admin();
                            break;
                        case 2:
                            obj = new SuperAdmin();
                            break;
                    }
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }

            }
            else
            {
                MessageBox.Show($"No User Found with email {email.Text}");

            }
        }
    }
}