using System;
using System.Collections.Generic;
using System.Text;

namespace SocialWorld.Entities.Concrete
{
    public class JobType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
