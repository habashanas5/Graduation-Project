using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;

namespace GraduationProject.Applications.LogErrors
{
    public class LogErrorService : Repository<LogError>
    {
        public LogErrorService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IAuditColumnTransformer auditColumnTransformer) :
                base(
                    context,
                    httpContextAccessor,
                    auditColumnTransformer)
        {
        }

        public async Task CollectErrorDataAsync(string? exceptionMessage, string? stackTrace, string? additionalInfo)
        {
            var data = new LogError
            {
                ExceptionMessage = exceptionMessage,
                StackTrace = stackTrace,
                AdditionalInfo = additionalInfo
            };

            await AddAsync(data);
        }

        public void PurgeAllData()
        {
            _context.LogError.RemoveRange(_context.LogError);
            _context.SaveChanges();
        }

    }
}
