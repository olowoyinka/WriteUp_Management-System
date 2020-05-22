using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Project_Management_System.Client.AuthService
{
    public static class IJSRuntimeExtensions
    {
        public static ValueTask SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeVoidAsync("localStorage.setItem", key, content);

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>("localStorage.getItem", key);

        public static ValueTask RemoveItem(this IJSRuntime js, string key)
            => js.InvokeVoidAsync("localStorage.removeItem", key);

        public static ValueTask ModalClose(this IJSRuntime js)
            =>  js.InvokeVoidAsync("CloseModal");

        public static ValueTask<bool> RemoveModal(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeAsync<bool>("CloseModal", title, message, sweetAlertMessageType.ToString());
        }

        public static ValueTask<bool> Confirm(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeAsync<bool>("CustomConfirm", title, message, sweetAlertMessageType.ToString());
        }

    }

    public enum SweetAlertMessageType
    {
        question, warning, error, success, info
    }
}