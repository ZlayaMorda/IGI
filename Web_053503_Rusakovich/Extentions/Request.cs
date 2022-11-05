using Microsoft.AspNetCore.Http;

namespace Web_053503_Rusakovich.Extentions
{
    public static class Request
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.Headers["x-requested-with"].Equals("XMLHttpRequest");
        }
    }
}
