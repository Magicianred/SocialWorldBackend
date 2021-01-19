using System;
using System.Collections.Generic;
using System.Text;

namespace SocialWorld.Entities.Concrete
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
        public List<Company> Companies { get; set; }
        public List<Applicant> Applicants { get; set; }
    }
}
