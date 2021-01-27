using SocialWorld.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.Business.Interfaces
{
    public interface IApplicantService : IGenericService<Applicant>
    {
        Task<List<Applicant>> GetAllApplicantsByJobId(int id);
        Task<List<Applicant>> GetUserApplications(int id);
    }

}
