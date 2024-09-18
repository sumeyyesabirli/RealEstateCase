using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        public static int GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            return IsAuthenticated(httpContextAccessor) ? Convert.ToInt32(GetClaimsPrincipal(httpContextAccessor).Claims.First(i => i.Type == "userId")?.Value) : 0;
        }
    }
}
