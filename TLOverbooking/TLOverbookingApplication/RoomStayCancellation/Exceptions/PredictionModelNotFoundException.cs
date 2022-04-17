using System;

namespace TLOverbookingApplication.RoomStayCancellation.Exceptions
{
    public class PredictionModelNotFoundexception : Exception
    {
        public PredictionModelNotFoundexception( string message )
            :base( message )
        { }
    }
}
