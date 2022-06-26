using Microsoft.ML;
using System.Threading.Tasks;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public interface IRoomStayDataViewService
    {
        Task<IDataView> GetDataViewAsync( long providerId, MLContext mlContext );
    }
}
