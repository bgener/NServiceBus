namespace NServiceBus.Routing
{
    using System;

    /// <summary>
    /// Represents different ways how the transport should route a given message.
    /// </summary>
    public abstract class AddressTag
    {
        /// <summary>
        /// Creates new unicast address tag for a given destination.
        /// </summary>
        public static AddressTag Unicast(string destination)
        {
            return new UnicastAddressTag(destination);
        }

        /// <summary>
        /// Creates new multicast address tag for a given message type.
        /// </summary>
        public static AddressTag Multicast(Type messageType)
        {
            return new MulticastAddressTag(messageType);
        }
    }
}