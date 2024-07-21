using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;

namespace GraduationProject.Applications.City
{
    public class CityInfoService : Repository<CityInfo>
    {
        private readonly ApplicationDbContext _context;
        public CityInfoService(
          ApplicationDbContext context,
          IHttpContextAccessor httpContextAccessor,
          IAuditColumnTransformer auditColumnTransformer) :
              base(
                  context,
                  httpContextAccessor,
                  auditColumnTransformer)
        {
            _context = context;
        }
    }
}
