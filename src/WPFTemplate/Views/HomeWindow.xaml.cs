using System.Windows;
using WPFTemplate.Data;
using WPFTemplate.ViewModels;

namespace WPFTemplate.Views
{
    /// <summary>
    /// HomeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeWindow : Window
    {
        private readonly AppDbContext _appDbContext;

        public HomeWindow(AppDbContext appDbContext,
            HomeViewModel homeViewModel)
        {
            InitializeComponent();
            DataContext = homeViewModel;
        }
    }
}
