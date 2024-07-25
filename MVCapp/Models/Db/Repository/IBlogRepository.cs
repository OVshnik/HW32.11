using MVCapp.Models.Db.Entity;
using System.Threading.Tasks;

namespace MVCapp.Models.Db.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();

    }
}
