using Microsoft.ML;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TLOverbookingDomain.RoomStayFact;
using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public class RoomStayDataViewService : IRoomStayDataViewService
    {
        private readonly IRoomStayFactService _roomStayFactService;
        private static readonly string CSV_TRAIN_DATA_PATH = "temp/csv";

        public RoomStayDataViewService( IRoomStayFactService roomStayFactService )
        {
            _roomStayFactService = roomStayFactService;
        }

        public async Task<IDataView> GetDataViewAsync( long providerId, MLContext mlContext )
        {
            /*
             * 1) Получаем все факты
             * 2) Формируем csv файл
             * 3) Формируем IDataView
             * 4) Удаляем csv файл
             * 5) Возвращаем IDataView
             */

            var facts = await _roomStayFactService.GetAllForProviderAsync( providerId );
            var csvStrings = new StringBuilder();

            foreach ( var fact in facts )
            {
                csvStrings.AppendLine( ConvertRoomStayFactToCsvString( fact ) );
            }

            await CreateCsvFileAsync( csvStrings );

            return mlContext.Data.LoadFromTextFile<ModelInput>(
                path: CSV_TRAIN_DATA_PATH,
                hasHeader: true,
                separatorChar: '\t',
                allowQuoting: true,
                allowSparse: false );
        }

        private string ConvertRoomStayFactToCsvString( RoomStayFact rs )
        {
            return $"{rs.IsCancelled},{rs.DuratuionInDays},{rs.CheckInDate},{rs.CheckOutDate},{rs.Total},{rs.AdultsAmount},{rs.ChildrenAmount},{rs.ChildrenAmount},{rs.RoomTypeId},{rs.RoomId},{rs.RatePlanId},{0},{0},{rs.DaysBetweenCheckInAndCanceling}"; 
        }

        private async Task CreateCsvFileAsync( StringBuilder csvStrings )
        {
            string path = "temp/file.csv";
            using ( FileStream fstream = new FileStream( path, FileMode.OpenOrCreate ) )
            {
                byte[] buffer = Encoding.Default.GetBytes( csvStrings.ToString() );
                await fstream.WriteAsync( buffer, 0, buffer.Length );
            }
        }
    }
}
