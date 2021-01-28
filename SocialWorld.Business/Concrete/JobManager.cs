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
        private readonly IGenericDal<Job> _genericDal;
        public JobManager(IGenericDal<Job> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Job>> GetAllActiveJobsAsync()
        {
            return await _genericDal.GetAllByFilter(I => I.isActive == true && I.Company.isActive==true);
        }

        public async Task<List<Job>> GetAllJobsByCompanyId(int id)
        {
            return await _genericDal.GetAllByFilter(I => I.isActive == true && I.CompanyId==id);
        }
    }
}
