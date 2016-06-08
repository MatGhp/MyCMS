using Microsoft.AspNet.Identity.EntityFramework;

namespace MyCMS.DomainClasses
{
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
    }
}
