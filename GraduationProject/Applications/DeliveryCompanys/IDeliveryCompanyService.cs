using GraduationProject.Models.Entities;

namespace GraduationProject.Applications.DeliveryCompanys
{
    public interface IDeliveryCompanyService
    {
        Task<List<DeliveryCompany>> GetAllDeliveryCompaniesAsync();
        Task<DeliveryCompany> GetDeliveryCompanyByIdAsync(int id);
        Task<DeliveryCompany> AddDeliveryCompanyAsync(DeliveryCompany deliveryCompany);
        Task<DeliveryCompany> UpdateDeliveryCompanyAsync(DeliveryCompany deliveryCompany);
        Task<bool> DeleteDeliveryCompanyAsync(int id);
        IQueryable<DeliveryCompany> GetAllDeliveryCompanies();
        Task<DeliveryCompany> GetByRowGuidAsync(Guid? rowGuid);
        Task<bool> DeleteDeliveryCompanyByRowGuidAsync(Guid? rowGuid);
    }
}
