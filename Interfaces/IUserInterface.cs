using SimpleAppMvc.Models;

namespace SimpleAppMvc.Interface
{
    public interface IUserInterface
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> GetDetailUser(int userId);
        Task<UserModel> UpdateUser(UserModel user);
        Task<UserModel> DeleteUser(int userId);
    }
}