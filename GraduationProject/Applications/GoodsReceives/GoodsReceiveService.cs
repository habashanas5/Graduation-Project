using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Applications.GoodsReceives
{
    public class GoodsReceiveService : Repository<GoodsReceive>
    {
        public GoodsReceiveService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IAuditColumnTransformer auditColumnTransformer) :
                base(
                    context,
                    httpContextAccessor,
                    auditColumnTransformer)
        {
        }
    }
}