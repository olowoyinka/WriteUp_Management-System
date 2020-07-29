using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Project_Management_System.Server.Helpers;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Server.Services;
using Project_Management_System.Shared.Models.UserModel;


namespace Project_Management_System.Server.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<ChatRoomDatabaseSettings>(
                configuration.GetSection(nameof(ChatRoomDatabaseSettings)));

            services.AddSingleton<IChatRoomDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ChatRoomDatabaseSettings>>().Value);

            services.AddScoped<IAccount, AccountService>();

            services.AddScoped<ITopics, TopicsService>();

            services.AddScoped<IInvitee, InviteeService>();

            services.AddScoped<IChapter, ChapterService>();

            services.AddScoped<IChatroom, ChatroomService>();

            services.AddScoped<IEditBody, EditBodyService>();

            services.AddScoped<INotification, NotificationService>();

            services.AddTransient<IEmailSender, SendGridEmailSender>();
        }
    }
}