using Microsoft.ML.Data;

namespace TLOverbookingML.RoomStayCancellation.Model
{
    public class ModelOutput
    {
        [ColumnName( "PredictedLabel" )]
        public bool Prediction { get; set; }
        public float[] Score { get; set; }
    }
}
