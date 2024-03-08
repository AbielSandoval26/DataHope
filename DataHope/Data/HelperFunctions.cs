using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace DataHope.Data
{
    public class HelperFunctions
    {
        public static async Task<string> GetAuthenticatedUserEmail(AuthenticationStateProvider authenticationStateProvider)
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                //_authMessage = $"{user.Identity.Name} is authenticated.";
                //_claims = user.Claims;
                return user.FindFirst(c => c.Type == "emails")?.Value;
            }
            return null;
        }

        public static string GetAuthenticatedUserEmail(AuthenticationState authState)
        {
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                //_authMessage = $"{user.Identity.Name} is authenticated.";
                //_claims = user.Claims;

                var test = user.FindFirst(c => c.Type == "emails")?.Value;
                return user.FindFirst(c => c.Type == "emails")?.Value;
            }
            return null;
        }
    }
}
