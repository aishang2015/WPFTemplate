using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTemplate.Core
{
    public static class ServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}
