namespace NServiceBus
{
    using System;
    using System.Collections.Generic;
    using Routing;

    class TimeoutManagerDestinationType
    {
        public static AddressTag CreateAddressTag(Dictionary<string, string> headers, string destination)
        {
            string routingType;
            if (!headers.TryGetValue(TimeoutManagerHeaders.DestinationType, out routingType))
            {
                routingType = Unicast;
            }
            var addressTag = routingType == Unicast
                ? AddressTag.Unicast(destination)
                : AddressTag.Multicast(Type.GetType(destination, true));

            return addressTag;
        }

        public const string Unicast = "unicast";
        public const string Multicast = "multicast";
    }
}