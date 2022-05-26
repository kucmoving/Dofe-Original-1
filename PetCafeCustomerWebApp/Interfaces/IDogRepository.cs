using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.Interfaces
{
    public interface IDogRepository
    {
        Task<IEnumerable<Dog>> GetAll();
        Task<Dog> GetByIdAsync(int id);

        Task<Dog> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Dog>> GetDogByDay(string day);
        bool Add(Dog dog);  
        bool Update(Dog dog);   
        bool Delete(Dog dog);
        bool Save();
    }
}
