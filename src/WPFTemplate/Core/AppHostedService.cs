using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPFTemplate.Setting;
using WPFTemplate.Utils;

namespace WPFTemplate.Core
{
    public class AppHostedService : IHostedService
    {
        private readonly ILogger _logger;

        private readonly IServiceProvider _serviceProvider;

        private readonly AppSetting _setting;

        public AppHostedService(
            ILogger<AppHostedService> logger,
            IServiceProvider serviceProvider,
            IOptions<AppSetting> settingOptions)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _setting = settingOptions.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("程序启动！");
            ShowStartupWindow();
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("程序终止！");
            await Task.CompletedTask;
        }

        private void ShowStartupWindow()
        {
            var startUpWindowType = ReflectionUtil.GetAssemblyTypes(_setting.StartupWindow)
                .FirstOrDefault();
            var mainWindow = _serviceProvider.GetRequiredService(startUpWindowType) as Window;
            mainWindow.Show();
        }
    }
}
