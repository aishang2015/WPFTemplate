using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using WPFTemplate.Core;
using WPFTemplate.Setting;
using WPFTemplate.Windows;

namespace WPFTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private async void App_Startup(object sender, StartupEventArgs e)
        {
            await Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices(ConfigureServices)
                .Build().RunAsync();
        }

        /// <summary>
        /// 设置appsetting
        /// </summary>
        public void ConfigureAppConfiguration(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        public void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            // 启动服务，此服务作为页面的主服务
            services.AddHostedService<AppHostedService>();

            // 将整个appsetting进行绑定
            services.Configure<AppSetting>(hostContext.Configuration);

            // 注册所有窗口
            services.AddSingleton<HomeWindow>();
        }
    }
}
