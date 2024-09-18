using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RealEstateCase.Core.Helper
{
    public static class ClaimHelper
    {

        public static bool IsAuthenticated(this IHttpContextAccessor httpContextAccessor)
        {
            var identity = GetClaimsPrincipal(httpContextAccessor).Identity;
            return identity != null && GetClaimsPrincipal(httpContextAccessor) != null && GetClaimsPrincipal(httpContextAccessor)?.Identity != null && identity.IsAuthenticated;
        }

        public static ClaimsPrincipal GetClaimsPrincipal(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext?.User;
        }

        public static int? GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                var userClaims = GetClaimsPrincipal(httpContextAccessor);

                var userIdClaim = userClaims?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim))
                {
                    throw new InvalidOperationException("User ID claim not found.");
                }

                return int.Parse(userIdClaim);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
