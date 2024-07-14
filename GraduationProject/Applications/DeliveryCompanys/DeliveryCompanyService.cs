using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Applications.DeliveryCompanys
{
    public class DeliveryCompanyService  : Repository<DeliveryCompany> ,IDeliveryCompanyService 
    {
        private readonly ApplicationDbContext _context;
        public DeliveryCompanyService(
            ApplicationDbContext context,
             IHttpContextAccessor httpContextAccessor,
             IAuditColumnTransformer auditColumnTransformer):base(context,
                    httpContextAccessor,
                    auditColumnTransformer)
        {
            _context = context;
        }

        public async Task<List<DeliveryCompany>> GetAllDeliveryCompaniesAsync()
        {
            return await _context.DeliveryCompany.ToListAsync();
        }

        public async Task<DeliveryCompany> GetDeliveryCompanyByIdAsync(int id)
        {
            return await _context.DeliveryCompany.FindAsync(id);
        }

        public async Task<DeliveryCompany> AddDeliveryCompanyAsync(DeliveryCompany deliveryCompany) 
        {
            _context.DeliveryCompany.Add(deliveryCompany);
            await _context.SaveChangesAsync();
            return deliveryCompany;
        }

        public async Task<DeliveryCompany> UpdateDeliveryCompanyAsync(DeliveryCompany deliveryCompany)
        {
            _context.Entry(deliveryCompany).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return deliveryCompany;
        }

        public async Task<bool> DeleteDeliveryCompanyByRowGuidAsync(Guid? rowGuid)
        {
            var deliveryCompany = await _context.DeliveryCompany.FirstOrDefaultAsync(dc => dc.RowGuid == rowGuid);
            if (deliveryCompany == null)
            {
                return false;
            }

            _context.DeliveryCompany.Remove(deliveryCompany);
            await _context.SaveChangesAsync();
            return true;
        }
        public IQueryable<DeliveryCompany> GetAllDeliveryCompanies()
        {
            return _context.DeliveryCompany.AsQueryable();
        }

        public Task<bool> DeleteDeliveryCompanyAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}