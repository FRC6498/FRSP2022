using FRSP2022.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FRSP2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RobotModel robot = new();
        NotesWindow notesPage;
        public MainWindow()
        {
            InitializeComponent();
            grdMatchData.DataContext = robot;
        }

        private void ScoutingPage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
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
            // close app
            Application.Current.Shutdown();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            CSVExporter.Export(robot);
            // reset
            StartPosition pos = robot.StartPos;
            robot = new RobotModel();
            robot.StartPos = pos;
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

        private void btnNotes_Click(object sender, RoutedEventArgs e)
        {
            notesPage = new NotesWindow(robot);
            notesPage.Show();
        }
    }
}
