using Microsoft.EntityFrameworkCore;
using SimpleAppMvc.Data;
using SimpleAppMvc.Interface;
using SimpleAppMvc.Models;

namespace SimpleAppMvc.Repositories
{
    public class UserRepository : IUserInterface
    {
        private readonly SimpleAppMvcContext _context;
        public UserRepository(SimpleAppMvcContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                var data = await _context.Users.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<UserModel> GetDetailUser(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if(user == null)
                    throw new NullReferenceException();
                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<UserModel> DeleteUser(int userId)
        {
            try
            {
                var user = await GetDetailUser(userId);
                if (user == null)
                    throw new NullReferenceException();
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}