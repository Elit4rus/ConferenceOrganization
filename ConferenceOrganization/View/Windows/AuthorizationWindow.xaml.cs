using ConferenceOrganization.AppData;
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

namespace ConferenceOrganization.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AutorizationHelper.CheckData(LoginTb.Text, PasswordPb.Password) == true)
            {
                // успешная авторизация
                MessageBox.Show("Пользователь успешно авторизован");
                Close();
            }
            else
            {
                if (BlockSystemHelper.IncreaseIncorrectInput()==3)
                {
                    BlockWindow blockWindow = new BlockWindow();
                    blockWindow.Show();
                }
                else
                {
                    // неуспешная авторизация
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }
    }
}
