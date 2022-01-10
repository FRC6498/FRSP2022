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

namespace FRSP2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RobotContext context = new RobotContext();
        RobotModel robot = new();
        public MainWindow()
        {
            InitializeComponent();
            grdMatchData.DataContext = robot;
        }

        private void ScoutingPage_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Escape:
                    OnAppClose();
                    break;
                default:
                    break;
            }
        }

        private void OnAppClose()
        {
            // dump local db
            // dump main db
            // close app
            Application.Current.Shutdown();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //context.Add(robot);
            //context.SaveChanges();
            CSVExporter.Export(robot);
        }

        private void UpdateCounter_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Grid container = button.Parent as Grid;
            IEnumerable<UIElement> children = UIElementCollectiontoIEnumerable(container.Children);
            TextBlock counter = children.Where(e => e is TextBlock).First() as TextBlock;
            int currentNum = int.Parse(counter.Text);
            if (button.Name.ToLower().Contains("decrement"))
            {
                currentNum--;
                currentNum = Math.Clamp(currentNum, 0, 200);
                counter.Text = $"{currentNum}";
            }
            else if (button.Name.ToLower().Contains("increment"))
            {
                currentNum++;
                currentNum = Math.Clamp(currentNum, 0, 200);
                counter.Text = $"{currentNum}";
            }

        }

        private IEnumerable<UIElement> UIElementCollectiontoIEnumerable(UIElementCollection uiec)
        {
            List<UIElement> collection = new();
            foreach (UIElement element in uiec)
            {
                collection.Add(element);
            }
            return collection;
        }
    }
}
