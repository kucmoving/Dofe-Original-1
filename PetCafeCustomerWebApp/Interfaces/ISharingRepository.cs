using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.Interfaces
{
    public interface ISharingRepository
    {
        Task<IEnumerable<Sharing>> GetAll();
        Task<Sharing> GetByIdAsync(int id);
        Task<IEnumerable<Sharing>> GetSharingByDay(string day);
        bool Add(Sharing sharing);
        bool Update(Sharing sharing);
        bool Delete(Sharing sharing);
        bool Save();
    }
}