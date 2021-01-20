using SocialWorld.Business.Interfaces;
using SocialWorld.DataAccess.Interfaces;
using SocialWorld.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.Concrete
{
    public class JobManager : GenericManager<Job>, IJobService
    {
        public JobManager(IGenericDal<Job> genericDal) : base(genericDal)
        {
        }
    }
}
