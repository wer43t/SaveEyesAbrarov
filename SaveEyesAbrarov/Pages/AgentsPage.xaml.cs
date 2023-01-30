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
        public AgentsPage()
        {
            InitializeComponent();

            Agents = DbAccess.GetAgents();
            DataContext = this;
        }
    }
}
