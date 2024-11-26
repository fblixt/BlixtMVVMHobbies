using BlixtMVVMHobbies.ViewModels;
using System.Windows;

namespace BlixtMVVMHobbies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HobbiesViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new HobbiesViewModel();
            DataContext = _viewModel;
            Loaded += HobbiesView_Loaded;
        }

        private async void HobbiesView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}