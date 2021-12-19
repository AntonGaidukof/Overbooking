using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TLOverbookingApplication.WebClient;

namespace TLOverbookingInfrastructure.WebClient
{
    public class WebPmsWebClient : IWebPmsWebClient
    {
        public async Task<RS> GetAsync<RS>( string url )
        {
            WebRequest request = WebRequest.Create( url );
            request.Method = "GET";

            WebResponse response = await request.GetResponseAsync();
            RS responseData = default;

            using ( Stream stream = response.GetResponseStream() )
            {
                using ( StreamReader reader = new StreamReader( stream ) )
                {
                    string responseJson = reader.ReadToEnd();
                    responseData = JsonSerializer.Deserialize<RS>( responseJson );
                }
            }

            response.Close();
            return responseData;
        }

        public async Task<RS> PostAsync<RS, RQ>( string url, RQ requestData )
        {
            WebRequest request = WebRequest.Create( url );
            string jsonRequestData = JsonSerializer.Serialize( requestData );
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes( jsonRequestData );

            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = byteArray.Length;
           
            using ( Stream dataStream = request.GetRequestStream() )
            {
                dataStream.Write( byteArray, 0, byteArray.Length );
            }

            WebResponse response = await request.GetResponseAsync();
            RS responseData = default;
            
            using ( Stream stream = response.GetResponseStream() )
            {
                using ( StreamReader reader = new StreamReader( stream ) )
                {
                    string responseJson = reader.ReadToEnd();
                    responseData = JsonSerializer.Deserialize<RS>( responseJson );
                }
            }
            
            response.Close();
            return responseData;
        }
    }
}
