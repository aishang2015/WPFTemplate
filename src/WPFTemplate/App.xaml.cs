using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Windows;
using WPFTemplate.Core;
using WPFTemplate.Data;
using WPFTemplate.Setting;
using WPFTemplate.Views;

namespace WPFTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private async void App_Startup(object sender, StartupEventArgs e)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices(ConfigureServices)
                .UseSerilog(ConfigureLogger)
                .Build();

            // 初始化数据库
            using (var serviceScope = host.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            await host.RunAsync();
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
        public void ConfigureServices(
            HostBuilderContext hostContext,
            IServiceCollection services)
        {
            // 启动服务，此服务作为页面的主服务
            services.AddHostedService<AppHostedService>();

            // 将整个appsetting进行绑定
            services.Configure<AppSetting>(hostContext.Configuration);

            // 添加ef
            services.AddDatabase<AppDbContext>(hostContext.Configuration);

            // 注册所有窗口
            services.AddTransient<HomeWindow>();
        }

        /// <summary>
        /// 配置日志
        /// </summary>
        public void ConfigureLogger(
            HostBuilderContext context,
            IServiceProvider serviceProvider,
            LoggerConfiguration loggerConfiguration)
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log-all-.txt");
            string logFormat = @"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3} {SourceContext:l}] {Message:lj}{NewLine}{Exception}";
            loggerConfiguration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(serviceProvider)
                    .Enrich.FromLogContext()
                    .WriteTo.Logger(config =>
                    {
                        config.WriteTo.File(logPath,
                            restrictedToMinimumLevel: LogEventLevel.Debug,
                            outputTemplate: logFormat,
                            rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true,
                            shared: true,
                            fileSizeLimitBytes: 10_000_000);
                    });
        }
    }
}
