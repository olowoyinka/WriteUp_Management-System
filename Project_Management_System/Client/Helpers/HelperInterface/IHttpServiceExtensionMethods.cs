using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.ViewModelResponse;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Helpers.HelperInterface
{
    public static class IHttpServiceExtensionMethods
    {
        public static async Task<T> GetHelper<T>(this IHttpService httpService, string url)
        {
            var response = await httpService.Get<T>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public static async Task<PaginationResponse<T>> GetHelper<T>(this IHttpService httpService, string url,
            PaginationRequest request, string name)
        {
            string newURL = "";

            if (url.Contains("?"))
            {
                newURL = $"{url}&page={request.Page}&quantityPerPage={request.QuantityPerPage}&name={name}";
            }
            else
            {
                newURL = $"{url}?page={request.Page}&quantityPerPage={request.QuantityPerPage}&name={name}";
            }

            var httpResponse = await httpService.Get<T>(newURL);

            var totalAmountPages = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("pagesQuantity").FirstOrDefault());

            var paginatedResponse = new PaginationResponse<T>
            {
                Response = httpResponse.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }
    }
}