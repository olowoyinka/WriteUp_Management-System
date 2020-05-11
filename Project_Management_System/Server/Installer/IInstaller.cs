using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Management_System.Server.Installer
{
    public interface IInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
