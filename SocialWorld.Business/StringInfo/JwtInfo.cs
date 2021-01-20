using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.StringInfo
{
    public class JwtInfo
    {
        public const string Issuer = "https://localhost";
        public const string Audience = "http://localhost";
        public const string SecurityKey = "oguzhanoguzhan11";
        public const int TokenExpiration = 30;
    }
}
