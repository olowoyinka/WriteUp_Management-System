using Project_Management_System.Client.Helpers.HelperService;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Helpers.HelperInterface
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<object>> Delete(string url);

        Task<HttpResponseWrapper<T>> Get<T>(string url);

        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);

        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);

        Task<HttpResponseWrapper<object>> Put<T>(string url, T data);

        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data);
    }
}