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
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        public CaptchaWindow()
        {
            InitializeComponent();
            CaptchaTbl.Text = AutorizationHelper.captcha;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaTb.Text == AutorizationHelper.captcha)
            {
                MessageBox.Show("Вы не робот");

                // Возвращаем результат диалового окна
                DialogResult = true;
            }
            else 
            { 
                MessageBox.Show("Вы робот");
                // Возвращаем результат диалового окна
                DialogResult= true;
            }
        }
    }
}
