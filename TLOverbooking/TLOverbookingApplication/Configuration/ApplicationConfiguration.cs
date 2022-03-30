namespace TLOverbookingApplication.Configuration
{
    public static class ApplicationConfiguration
    {
        public static readonly string DBConnectionString = "TLOverbookingConnection";
        public static readonly string WebPMSApiBaseUrl = "ApiUrl:WebPMSApiBaseUrl";
        public static readonly string GetBookingCancellationUrl = "ApiUrl:GetWebPMSApiBookingCancellationUrl";
        public static readonly string GetRoomStayFactUrl = "ApiUrl:GetRoomStayFactUrl";
    }
}
