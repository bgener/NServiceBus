namespace NServiceBus
{
    static class TimeoutManagerHeaders
    {
        public const string Expire = "NServiceBus.Timeout.Expire";
        public const string RouteExpiredTimeoutTo = "NServiceBus.Timeout.RouteExpiredTimeoutTo";
        public const string DestinationType = "NServiceBus.Timeout.DestinationType";
        public const string ClearTimeouts = "NServiceBus.ClearTimeouts";
    }
}