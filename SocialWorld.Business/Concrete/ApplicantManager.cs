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
        public ApplicantManager(IGenericDal<Applicant> genericDal) : base(genericDal)
        {
        }
    }
}
