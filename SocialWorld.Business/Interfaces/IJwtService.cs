using SocialWorld.Business.Settings;
using SocialWorld.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser, List<AppRole> roles);
    }
}
