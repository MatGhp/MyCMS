using Microsoft.AspNet.Identity.EntityFramework;

namespace MyCMS.DomainClasses
{
    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
