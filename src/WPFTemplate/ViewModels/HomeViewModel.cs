

using System.Windows.Input;
using WPFTemplate.Commands;
using WPFTemplate.Commands.Home;

namespace WPFTemplate.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private int _count = 0;

        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value, "Count");
        }

        public ICommand AddCount => new AddCommand();

        public ICommand MiniCount => new MiniCommand();
    }
}