using Microsoft.Extensions.DependencyInjection;
using System;
using WPFTemplate.ViewModels;

namespace WPFTemplate.Commands.Home
{
    public class AddCommand : BaseCommand<HomeViewModel>
    {
        public AddCommand() : base((obj) =>
        {
            obj.Count++;
        })
        { }
    }
}
