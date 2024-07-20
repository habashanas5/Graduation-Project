using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;

namespace GraduationProject.Applications.SalesSummaryByDays
{
    public class SalesSummaryByDayService : Repository<SalesSummaryByDay>
    {
        private readonly ApplicationDbContext _context;
        public SalesSummaryByDayService(
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
