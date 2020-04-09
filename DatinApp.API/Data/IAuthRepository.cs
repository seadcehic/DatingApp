using System.Threading.Tasks;
using DatinApp.API.Models;

namespace DatinApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register (User user,string password);
         Task<User> Login (string username,string password);
         Task<bool> UserExist (string username);


    }
}