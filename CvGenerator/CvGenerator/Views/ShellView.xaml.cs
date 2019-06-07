using System.Windows;
using System.Windows.Controls;
using CvGenerator.Models;
using CvGenerator.ViewModels;

namespace CvGenerator.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        ShellViewModel shellViewModel;
        public ShellView()
        {
            InitializeComponent();
            shellViewModel = new ShellViewModel();
            base.DataContext = shellViewModel;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            shellViewModel.SelectedItem((PersonModel)item.SelectedItem);
        }
    }
}
