using ConferenceOrganization.Model;
using ConferenceOrganization.View.Pages;
using ConferenceOrganization.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace ConferenceOrganization.AppData
{
    internal class AutorizationHelper
    {
        public static User currentUser;
        public static string captcha;
        public static bool CheckData(string login, string password)
        {
            // НАВИГАЦИЯ
            // Получаем одну запись по условиям по таблицам БД
            currentUser = App.context.User.FirstOrDefault(u => u.Login == login && u.Password == password);

            // продолжение
            if (currentUser!=null)
            {
                // Генерируем капчу
                if (GenerateCaptcha() == true)
                {
                    // Загружаем страницы
                    switch (currentUser.RoleID)
                    {
                        case 1:
                            // загрузка страницы
                            FrameHelper.mainFrame.Navigate(new ParticipiantPage());
                            break;
                        case 2:
                            FrameHelper.mainFrame.Navigate(new ModeratorPage());
                            break;
                        case 3:
                            FrameHelper.mainFrame.Navigate(new JuryPage());
                            break;
                        case 4:
                            FrameHelper.mainFrame.Navigate(new OrganizatorPage());
                            break;
                    }
                    return true;
                }
                // Иначе, то...
                else 
                {
                    MessageBox.Show("Капча введена не правильно");
                }
            }

            return false;
        }
        public static bool GenerateCaptcha()
        {
            // Создаем генератор случайных чисел
            Random random = new Random();

            // Очищаем поле с капчей
            captcha = string.Empty; // captcha = "";

            for (int i = 1; i <= 4; i++)
            {
                // Генерируем число и конвертируем его в символ
                char character = Convert.ToChar(random.Next(65, 91));

                // Складываем символы
                captcha += character;
            }

            // Открываем окно
            CaptchaWindow captchaWindow = new CaptchaWindow();
            if (captchaWindow.ShowDialog()==true)
            {
                return true;
            }
            return false;
        }
    }
}
