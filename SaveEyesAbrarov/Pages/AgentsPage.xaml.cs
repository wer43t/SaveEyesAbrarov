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
using SaveEyesAbrarov.Data;

namespace SaveEyesAbrarov.Pages
{
    /// <summary>
    /// Логика взаимодействия для AgentsPage.xaml
    /// </summary>
    public partial class AgentsPage : Page
    {
        public List<Agent> Agents { get; set; }
        public List<Agent> showedAgents { get; set; }

        private Dictionary<string, Func<Agent, object>> Sortings;


        private int startIndex;
        private int separator; 
        public AgentsPage()
        {
            InitializeComponent();

            Agents = DbAccess.GetAgents();
            DataContext = this;


            Sortings = new Dictionary<string, Func<Agent, object>>
            {
                { "Сначала старые", x => x.Title },//reverse
                { "Сначала новые", x => x.Title },
                { "А-Я", x => x.Discount },
                { "Я-А", x => x.Discount }, // reverse
                { "Приоритет ↑", x => x.Discount},
                { "Приоритет ↓", x => x.Discount}//reverse
            };

            startIndex = 0;
        }

        private void GoPagination()
        {

            if (startIndex < showedAgents.Count)
            {
                int test = (showedAgents.Count / (separator + startIndex)) > 0 ? separator : showedAgents.Count % separator;
                var search = showedAgents.GetRange(startIndex, test);
                lvAgents.ItemsSource = search;
                lblPages.Content = $"{startIndex + test} из {showedAgents.Count}";
            }
        }

        private void btnGoPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (startIndex != 0)
                startIndex -= Convert.ToInt32((cmBox.SelectedItem as ComboBoxItem).Content.ToString());
            GoPagination();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            if (startIndex + Convert.ToInt32((cmBox.SelectedItem as ComboBoxItem).Content.ToString()) < Agents.Count)
                startIndex += Convert.ToInt32((cmBox.SelectedItem as ComboBoxItem).Content.ToString());
            GoPagination();
        }

        private void cmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmBox.Text != "")
            {
                separator = Convert.ToInt32((cmBox.SelectedItem as ComboBoxItem).Content.ToString());
                startIndex = 0;
                GoPagination();
            }
        }
    }
}
