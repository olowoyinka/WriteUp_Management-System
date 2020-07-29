using Blazor.FileReader;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Project_Management_System.Client.AuthService;
using Project_Management_System.Client.Helpers.HelperInterface;
using Project_Management_System.Client.Helpers.HelperService;
using Project_Management_System.Client.Respository.RespositoryInterface;
using Project_Management_System.Client.Respository.RespositoryService;
using System.Threading.Tasks;

namespace Project_Management_System.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            ConfigureServices(builder.Services);          

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddBaseAddressHttpClient();

            services.AddScoped<IAccount, AccountService>();

            services.AddScoped<ITopics, TopicsService>();

            services.AddScoped<IChapter, ChapterService>();

            services.AddScoped<IInvitee, InviteeService>();

            services.AddScoped<INotification, NotificationService>();

            services.AddScoped<IChatroom, ChatroomService>();

            services.AddScoped<IEditBody, EditBodyService>();

            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<JWTAuthenticationProvider>();

            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationProvider>()
            );

            services.AddScoped<ILoginService, JWTAuthenticationProvider>(
               provider => provider.GetRequiredService<JWTAuthenticationProvider>()
                );

            services.AddOptions();

            services.AddAuthorizationCore();

            services.AddFileReaderService(options =>
            {
                options.UseWasmSharedBuffer = true;
            });
        }
    }
}