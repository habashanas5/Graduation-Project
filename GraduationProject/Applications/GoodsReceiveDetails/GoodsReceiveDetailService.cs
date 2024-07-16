using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;

namespace GraduationProject.Applications.GoodsReceiveDetails
{
    public class GoodsReceiveDetailService: Repository<GoodsReceiveDetail>
    {
        public GoodsReceiveDetailService(
        ApplicationDbContext context,
        IHttpContextAccessor httpContextAccessor,
        IAuditColumnTransformer auditColumnTransformer) :
        base
            (context,
            httpContextAccessor, 
            auditColumnTransformer)
        
        {
        }
    }
}
