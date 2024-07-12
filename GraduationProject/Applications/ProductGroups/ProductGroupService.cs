using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Applications.ProductGroups
{
    public class ProductGroupService : Repository<ProductGroup>
    {
        public ProductGroupService(
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