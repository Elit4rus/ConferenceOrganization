using ConferenceOrganization.AppData;
using ConferenceOrganization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ConferenceOrganization.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrganizatorPage.xaml
    /// </summary>
    public partial class OrganizatorPage : Page
    {

        public OrganizatorPage()
        {
            InitializeComponent();
            GenerateGreeting();
        }
        private void GenerateGreeting()
        {
            string greeting = string.Empty;

            // 1. Определение времени работы
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            if (new TimeSpan(5,0,0) < currentTime && currentTime <= new TimeSpan(11, 0, 0))
            {
                greeting = "Доброе утро!\n";
            }
            else if (new TimeSpan(11, 1, 0) < currentTime && currentTime <= new TimeSpan(18, 0, 0))
            {
                greeting = "Добрый день!\n";
            }
            else if (new TimeSpan(18, 1, 0) < currentTime && currentTime <= new TimeSpan(24, 0, 0))
            {
                greeting = "Добрый вечер!\n";
            }
            else 
            {
                greeting = "Доброй ночи!\n";
            }

            // 2. Определение пола пользователя
            greeting += AutorizationHelper.currentUser.GenderID == 1 ? " Mrs" : " Ms";

            //if (AutorizationHelper.currentUser.GenderID==1)
            //{

            //}

            // 3. Извлечение имени и отчества из полного имени пользователя
            string[] name = AutorizationHelper.currentUser.FullName.Split(' ');
            greeting += $"{name[1]} {name[2]}";
            GreetingTbl.Text = greeting; // Доброе утро! Mrs Иван Иванович
        }
    }
}
