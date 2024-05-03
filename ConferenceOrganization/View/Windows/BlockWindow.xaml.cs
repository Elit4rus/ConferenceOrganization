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
    /// Логика взаимодействия для BlockWindow.xaml
    /// </summary>
    public partial class BlockWindow : Window
    {
        int count = 0;
        public BlockWindow()
        {
            InitializeComponent();
            this.IsEnabled = false;
            BlockSystemHelper.timer.Tick += Timer_Tick;
            BlockSystemHelper.timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count==5)
            {
                BlockSystemHelper.timer.Stop();
                DialogResult = true;
                Close();
            }
        }
    }
}
