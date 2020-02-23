using System.Windows.Controls;
using KMA.ProgrammingInCSharp.LW1Polishchuk.ViewModels;

namespace KMA.ProgrammingInCSharp.LW1Polishchuk.Views
{
    public partial class BirthdayView : Page
    {
        public BirthdayView()
        {
            InitializeComponent();
            DataContext = new BirthdayViewModel();
        }
    }
}