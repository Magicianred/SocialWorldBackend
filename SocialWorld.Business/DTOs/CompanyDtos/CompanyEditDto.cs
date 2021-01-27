using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.DTOs.CompanyDtos
{
    public class CompanyEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Explanation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoString { get; set; }
    }
}
