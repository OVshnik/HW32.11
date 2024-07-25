using MVCApp.Models.Db;
using MVCapp.Models.Db.Entity;
using System.Threading.Tasks;

namespace MVCapp.Models.Db.Repository
{
    public interface ILogRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }


}

