using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_API.Models;

namespace POS_API.IDataRepository.Users
{
    public interface IUsersRepository : IDisposable
    {
        IEnumerable<User> GetAllUsers();
        List<User> GetUserById(int id);
    }
}
