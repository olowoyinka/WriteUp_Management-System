using System;
using System.Threading.Tasks;

namespace Project_Management_System.Client.AuthService
{
    public interface ILoginService
    {
        Task Login(string token, DateTime expiry = default);

        Task Logout();
    }
}
