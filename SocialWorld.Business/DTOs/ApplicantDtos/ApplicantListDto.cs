using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.DTOs.ApplicantDtos
{
    public class ApplicantListDto
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
    }
}
