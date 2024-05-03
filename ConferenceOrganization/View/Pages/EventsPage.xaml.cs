using ConferenceOrganization.Model;
using ConferenceOrganization.View.Windows;
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

namespace ConferenceOrganization.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        // Создаем список типа List для хранения направлений
        List<Direction> directions = App.context.Direction.ToList();
        // Создаем список типа List для хранения мероприятий
        List<Event> events = App.context.Event.ToList();

        public EventsPage()
        {
            InitializeComponent();

            // Загружаем записи из таблицы Event в ListView
            EventsLv.ItemsSource = events;
            // Добавляем пункт "Все направления" в List
            directions.Insert(0, new Direction() { Name = "Все направления"});
            // Загружаем записи из таблицы Direction в ComboBox
            DirectionsCmb.ItemsSource=directions;

        }
        private void DirectionsCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Direction selectedDirection = DirectionsCmb.SelectedItem as Direction;
            if (DirectionsCmb.SelectedIndex == 0)
            {
                EventsLv.ItemsSource = events;
            }
            else
            { 
                EventsLv.ItemsSource = events.Where(ev => ev.DirectionID == selectedDirection.DirectionID);
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.ShowDialog();
        }
    }
}
