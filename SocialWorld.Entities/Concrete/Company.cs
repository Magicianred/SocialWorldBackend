﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialWorld.Entities.Concrete
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Explanation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoString { get; set; }


        public bool isActive { get; set; } = true;

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Job> Jobs { get; set; }

    }
}
