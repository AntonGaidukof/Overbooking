using Microsoft.ML.Data;
using System;

namespace TLOverbookingML.RoomStayCancellation.Model
{
    public class ModelInput
    {
        [ColumnName( "IsCancelled" ), LoadColumn( 0 )]
        public bool IsCancelled { get; set; }

        [ColumnName( "DuratuionInDays" ), LoadColumn( 1 )]
        public int DuratuionInDays { get; set; }

        [ColumnName( "CheckInDate" ), LoadColumn( 2 )]
        public DateTime CheckInDate { get; set; } // TODO переделать на строку "день;месяц"

        [ColumnName( "CheckOutDate" ), LoadColumn( 3 )]
        public DateTime CheckOutDate { get; set; } // TODO переделать на строку "день;месяц"

        [ColumnName( "Total" ), LoadColumn( 4 )]
        public decimal Total { get; set; }

        [ColumnName( "AdultsAmount" ), LoadColumn( 5 )]
        public int AdultsAmount { get; set; }

        [ColumnName( "ChildrenAmount" ), LoadColumn( 6 )]
        public int ChildrenAmount { get; set; }

        [ColumnName( "RoomTypeId" ), LoadColumn( 7 )]
        public long RoomTypeId { get; set; }

        [ColumnName( "RoomId" ), LoadColumn( 8 )]
        public long? RoomId { get; set; }

        [ColumnName( "RatePlanId" ), LoadColumn( 9 )]
        public long RatePlanId { get; set; }

        [ColumnName( "RoomId" ), LoadColumn( 10 )]
        public string CreationSource { get; set; }

        [ColumnName( "RatePlanId" ), LoadColumn( 11 )]
        public string PurposeKind { get; set; }

        [ColumnName( "DaysBetweenCheckInAndCanceling" ), LoadColumn( 12 )]
        public int? DaysBetweenCheckInAndCanceling { get; set; }
    }
}
