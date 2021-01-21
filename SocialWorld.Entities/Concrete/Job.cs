using System;
using System.Collections.Generic;
using System.Text;

namespace SocialWorld.Entities.Concrete
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastEdit { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;

        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }


        public List<Applicant> Applicants { get; set; }
    }
}
