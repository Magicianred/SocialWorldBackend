using Microsoft.EntityFrameworkCore;
using SocialWorld.DataAccess.Concrete.EntityFrameworkCore.Context;
using SocialWorld.DataAccess.Interfaces;
using SocialWorld.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfJobRepository: EfGenericRepository<Job>, IJobDal
    {
    }
}
