using System.Threading.Tasks;
using Acme.Identity.Others;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Security.Encryption;

namespace Acme.Identity.IdentityUser
{
    public class IdentityDataSetContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly IStringEncryptionService _stringEncryptionService;

        public IdentityDataSetContributor(IRepository<User, int> userRepository,
            IStringEncryptionService stringEncryptionService)
        {
            _userRepository = userRepository;
            _stringEncryptionService = stringEncryptionService;
        }
        
        public async Task SeedAsync(DataSeedContext context)
        {
            var passwordHashed = _stringEncryptionService.Encrypt("admin");
            var admin = new User("admin", passwordHashed, Consts.RolConsts.Administrador,"admin@gmail.com")
            {
                Name = "Administrador",
                Surname = "Surname",
            };
            
            if (!await _userRepository.AnyAsync(user => user.UserName == admin.UserName))
            {
                await _userRepository.InsertAsync(admin, true);
            }
        }
    }
}