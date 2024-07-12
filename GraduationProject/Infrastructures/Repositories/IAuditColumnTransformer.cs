using GraduationProject.Data;
using GraduationProject.Models.Contracts;

namespace GraduationProject.Infrastructures.Repositories
{
    public interface IAuditColumnTransformer
    {
        Task TransformAsync(IHasAudit entity, ApplicationDbContext context);
    }
}