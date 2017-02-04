using System.Web;

namespace hbehr.Extensions
{
    public static class HttpExtensions
    {
        /// <summary>
        /// Determines whether the specified HTTP request is an AJAX request.
        /// </summary>
        /// <param name="request">The HTTP request.</param><exception cref="T:System.ArgumentNullException">The <paramref name="request"/> parameter is null.</exception>
        /// <returns>
        /// true if the specified HTTP request is an AJAX request; otherwise, false.
        /// </returns>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request?.Headers?["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
