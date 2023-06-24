using Application.Interfaces;
using System.Security.Claims;

namespace Inventory.Mvc.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public string? UserProfilePicture => _httpContextAccessor.HttpContext?.User?.FindFirstValue("ProfilePicture");
    }
}
