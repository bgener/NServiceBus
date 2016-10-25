namespace NServiceBus
{
    using System;
    using System.Collections.Generic;
    using Routing;

    class TimeoutManagerRoutingStrategy : RoutingStrategy
    {
        string timeoutManagerAddress;
        string ultimateDestination;
        string destinationType;
        DateTime deliverAt;

        public TimeoutManagerRoutingStrategy(string timeoutManagerAddress, string destination, string destinationType, DateTime deliverAt)
        {
            this.ultimateDestination = destination;
            this.destinationType = destinationType;
            this.deliverAt = deliverAt;
            this.timeoutManagerAddress = timeoutManagerAddress;
        }

        public override AddressTag Apply(Dictionary<string, string> headers)
        {
            headers[TimeoutManagerHeaders.RouteExpiredTimeoutTo] = ultimateDestination;
            headers[TimeoutManagerHeaders.DestinationType] = destinationType;
            headers[TimeoutManagerHeaders.Expire] = DateTimeExtensions.ToWireFormattedString(deliverAt);

            return new UnicastAddressTag(timeoutManagerAddress);
        }
    }
}