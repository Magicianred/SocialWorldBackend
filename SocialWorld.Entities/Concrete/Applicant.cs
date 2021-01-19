using System;
using System.Collections.Generic;
using System.Text;

namespace SocialWorld.Entities.Concrete
{
    public class Applicant
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public AppUser AppUser { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }



    }
}
