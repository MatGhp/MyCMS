using MyCMS.DomainClasses;
using MyCMS.ServiceLayer.Contracts;
using Microsoft.AspNet.Identity;

namespace MyCMS.ServiceLayer
{
    public class CustomRoleStore : ICustomRoleStore
    {
        private readonly IRoleStore<CustomRole, int> _roleStore;

        public CustomRoleStore(IRoleStore<CustomRole, int> roleStore)
        {
            _roleStore = roleStore;
        }
    }
}