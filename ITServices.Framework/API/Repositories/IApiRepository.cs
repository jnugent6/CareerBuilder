

using System.Net.Http;
using System.Threading.Tasks;

namespace ITServices.Framework.API.Repositories
{
    public interface IApiRepository
    {
        Task<string> GetAsync(string apiEndPoint);
    }
}
