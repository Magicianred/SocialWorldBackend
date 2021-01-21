using SocialWorld.Business.Interfaces;
using SocialWorld.DataAccess.Interfaces;
using SocialWorld.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IAppUserDal appUserDal, IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _appUserDal = appUserDal;
        }

        public async Task<AppUser> FindByEmail(string email)
        {
            return await _genericDal.GetByFilter(I => I.Email == email);
        }

        public async Task<List<AppRole>> GetRolesByEmail(string email)
        {
            return await _appUserDal.GetRolesByEmail(email);
        }
    }
}
