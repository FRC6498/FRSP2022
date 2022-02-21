using FRSP2022.Model;
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

namespace FRSP2022
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        RobotModel robot;
        public NotesWindow(RobotModel robot)
        {
            InitializeComponent();
            DataContext = this.robot;
            this.robot = robot;
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            robot.Notes = txtNotes.Text;
            Close();
        }
    }
}
