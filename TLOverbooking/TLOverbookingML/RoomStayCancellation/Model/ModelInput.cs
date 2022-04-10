using Microsoft.ML.Data;
using System;

namespace TLOverbookingML.RoomStayCancellation.Model
{
    public class ModelInput
    {
        [ColumnName( "Id" ), LoadColumn( 0 )]
        public long Id { get; set; }

        [ColumnName( "ExternalId" ), LoadColumn( 1 )]
        public long ExternalId { get; set; }

        [ColumnName( "IsCancelled" ), LoadColumn( 2 )]
        public bool IsCancelled { get; set; }

        [ColumnName( "DuratuionInDays" ), LoadColumn( 3 )]
        public int DuratuionInDays { get; set; }

        [ColumnName( "CheckInDate" ), LoadColumn( 4 )]
        public DateTime CheckInDate { get; set; }

        [ColumnName( "CheckOutDate" ), LoadColumn( 5 )]
        public DateTime CheckOutDate { get; set; }

        [ColumnName( "Total" ), LoadColumn( 6 )]
        public decimal Total { get; set; }

        [ColumnName( "AdultsAmount" ), LoadColumn( 7 )]
        public int AdultsAmount { get; set; }

        [ColumnName( "ChildrenAmount" ), LoadColumn( 8 )]
        public int ChildrenAmount { get; set; }

        [ColumnName( "RoomTypeId" ), LoadColumn( 9 )]
        public long RoomTypeId { get; set; }

        [ColumnName( "RoomId" ), LoadColumn( 10 )]
        public long RoomId { get; set; }

        [ColumnName( "RatePlanId" ), LoadColumn( 11 )]
        public long RatePlanId { get; set; }

        [ColumnName( "ProviderId" ), LoadColumn( 12 )]
        public long ProviderId { get; set; }

        [ColumnName( "DaysBetweenCheckInAndCanceling" ), LoadColumn( 13 )]
        public int? DaysBetweenCheckInAndCanceling { get; set; }
    }
}
