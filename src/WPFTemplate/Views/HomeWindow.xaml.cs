using System.Windows;
using WPFTemplate.Data;

namespace WPFTemplate.Views
{
    /// <summary>
    /// HomeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeWindow : Window
    {
        private readonly AppDbContext _appDbContext;

        public HomeWindow(AppDbContext appDbContext)
        {
            InitializeComponent();
            _appDbContext = appDbContext;
        }
    }
}
