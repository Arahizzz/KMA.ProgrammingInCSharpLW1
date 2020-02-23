using System.Windows;
using KMA.ProgrammingInCSharp.LW1Polishchuk.ViewModels;

namespace KMA.ProgrammingInCSharp.LW1Polishchuk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}