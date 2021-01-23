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
    public class ApplicantManager : GenericManager<Applicant>, IApplicantService
    {
        private readonly IGenericDal<Applicant> _genericDal;
        public ApplicantManager(IGenericDal<Applicant> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }


        public async Task<List<Applicant>> GetAllApplicantsByJobId(int id)
        {
            return await _genericDal.GetAllByFilter(I => I.JobId == id);
        }
    }
}
