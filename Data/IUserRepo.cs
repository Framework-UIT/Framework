using System.Collections.Generic;
using Framework.Models;
namespace Framework.Data
{
    public interface IUserRepo
    {
        User Authenticate(string username, string pasword);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string pasword);

    }
}