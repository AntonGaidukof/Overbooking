using System.Threading.Tasks;

namespace TLOverbookingApplication.WebClient
{
    public interface IWebPmsWebClient
    {
        Task<RS> PostAsync<RS, RQ>( string url, RQ request );

        Task<RS> GetAsync<RS>( string url );
    }
}
