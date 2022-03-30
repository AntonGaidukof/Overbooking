using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TLOverbookingApplication.BookingCancellationExtraction.Entities;
using TLOverbookingApplication.Configuration;
using TLOverbookingApplication.RoomStayFactExtraction.Entities;
using TLOverbookingApplication.WebClient;

namespace TLOverbookingInfrastructure.WebClient
{
    public class WebPmsWebClient : IWebPmsWebClient
    {
        private IConfiguration _configuration;

        public WebPmsWebClient( IConfiguration configuration )
        {
            _configuration = configuration;
        }

        public Task<GetBookingCancellationRS> GetBookingCancellationsAsync( GetBookingCancellationRQ request )
        {
            string webpmsApiBaseUrl = _configuration.GetSection( ApplicationConfiguration.WebPMSApiBaseUrl ).Value;
            string getBookingCancellationUrl = _configuration.GetSection( ApplicationConfiguration.GetBookingCancellationUrl ).Value;
            string url = $"{webpmsApiBaseUrl}/{getBookingCancellationUrl}?{GetUrlParams( request )}";
            
            return GetAsync<GetBookingCancellationRS>( url );
        }

        public Task<GetRoomStayFactRS> GetRoomStayFactsAsync( GetRoomStayFactRQ request )
        {
            string webpmsApiBaseUrl = _configuration.GetSection( ApplicationConfiguration.WebPMSApiBaseUrl ).Value;
            string getBookingCancellationUrl = _configuration.GetSection( ApplicationConfiguration.GetRoomStayFactUrl ).Value;
            string url = $"{webpmsApiBaseUrl}/{getBookingCancellationUrl}?{GetUrlParams( request )}";

            return GetAsync<GetRoomStayFactRS>( url );
        }

        private string GetUrlParams<T>( T ob )
        {
            var properties = typeof( T ).GetProperties( BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static );
            var result = new StringBuilder();

            foreach ( var propertie in properties )
            {
                string value = propertie.GetValue( ob ).ToString();
                result.Append( $"{propertie.Name.ToLower()}={value}&" );
            }

            result.Remove( result.Length - 1, 1 );

            return result.ToString();
        }

        private async Task<RS> GetAsync<RS>( string url )
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

        private async Task<RS> PostAsync<RS, RQ>( string url, RQ requestData )
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
