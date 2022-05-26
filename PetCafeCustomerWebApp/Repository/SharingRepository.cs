using Microsoft.EntityFrameworkCore;
using PetCafeCustomerWebApp.Data;
using PetCafeCustomerWebApp.Interfaces;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.Repository
{
    public class SharingRepository : ISharingRepository
    {
        private readonly ApplicationDbContext _context;

        public SharingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Sharing sharing)
        {
            _context.Add(sharing);
            return Save();
        }

        public bool Delete(Sharing sharing)
        {
            _context.Remove(sharing);
            return Save();
        }

        public async Task<IEnumerable<Sharing>> GetAll() //return list 
        {
            return await _context.Sharings.ToListAsync();
        }

        public async Task<Sharing> GetByIdAsync(int id) //return single item / one to many relationship (join and inclue)
        {
            return await _context.Sharings.Include(i => i.VisitTime).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Sharing>> GetDogByDay(string day) //goin to dog > VisitTime > day
        {
            return await _context.Sharings.Where(c => c.VisitTime.Day.Contains(day)).ToListAsync();
        }

        public Task<IEnumerable<Sharing>> GetSharingByDay(string day)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Sharing sharing)
        {
            _context.Update(sharing);
            return Save();
        }
    }
}
