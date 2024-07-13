using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Applications.DeliveryCompanys
{
    public class DeliveryCompanyService : Repository<DeliveryCompany>
    {
        public DeliveryCompanyService(
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