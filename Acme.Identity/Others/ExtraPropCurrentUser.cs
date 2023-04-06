using System.Security.Claims;
using JetBrains.Annotations;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace Acme.Identity.Others
{
    public interface IExtraPropCurrentUser : ICurrentUser
    {
        [Obsolete]
        [CanBeNull]
        Guid? Id { get; }
        
        int? UserId { get; }
    }
    
    [Dependency(ReplaceServices = true)]
    public class ExtraPropCurrentUser : CurrentUser, IExtraPropCurrentUser
    {
        public ExtraPropCurrentUser(ICurrentPrincipalAccessor principalAccessor) : base(principalAccessor)
        {
        }
        public new bool IsAuthenticated => UserId.HasValue;
        private int? FindUserIdentifier()
        {
            var res = this.FindClaimValue(ClaimTypes.NameIdentifier);
            
            if (res == null || res.IsNullOrWhiteSpace())
            {
                return null;
            }
            if (int.TryParse(res, out int id))
            {
                return id;
            }

            return null;
        }
        public int? UserId => FindUserIdentifier();
    }
}