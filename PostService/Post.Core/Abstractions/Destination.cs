
using POST.Core.Models;

namespace POST.Core.Abstractions
{
    public abstract class Destination
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public ICollection<Shipment> ExceptedShipments { get; set; }
    }
}
