using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.DTOs.CompanyDtos
{
    public class CompanyAddDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int AppUserId { get; set; }
    }
}
