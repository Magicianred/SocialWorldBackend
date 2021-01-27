using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.DTOs.JobDtos
{
    public class JobListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public string PhotoString { get; set; }
        public int JobTypeId { get; set; }
        public int CompanyId { get; set; }
    }
}
