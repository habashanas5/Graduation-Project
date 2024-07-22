using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CityInfo?> GetCityInfoAsync(string cityName, string country)
        {
            return await _context.CityInfo
                .FirstOrDefaultAsync(ci => ci.CityName == cityName && ci.Country == country);
        }
    }
}
