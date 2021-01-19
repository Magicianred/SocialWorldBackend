using System;
using System.Collections.Generic;
using System.Text;

namespace SocialWorld.Entities.Concrete
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public bool isActive { get; set; }

        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }

        public List<Applicant> Applicants { get; set; }
    }
}
