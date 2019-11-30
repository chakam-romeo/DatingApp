using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public Task<User> getUser(int Id)
        {
           var user = _context.Users.Include( p => p.Photos).FirstOrDefaultAsync(u => u.Id == Id);
           return user;
        }

        public async Task<IEnumerable<User>> getUsers()
        {
            var users = await  _context.Users.Include( p => p.Photos).ToListAsync();
           return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}