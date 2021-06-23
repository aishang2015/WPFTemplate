using WPFTemplate.ViewModels;

namespace WPFTemplate.Commands.Home
{
    public class MiniCommand : BaseCommand<HomeViewModel>
    {
        public MiniCommand() : base((obj) =>
        {
            obj.Count--;
        })
        { }
    }
}
