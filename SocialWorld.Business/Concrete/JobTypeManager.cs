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
    public class JobTypeManager : GenericManager<JobType>, IJobTypeService
    {
        public JobTypeManager(IGenericDal<JobType> genericDal) : base(genericDal)
        {
        }
    }
}
