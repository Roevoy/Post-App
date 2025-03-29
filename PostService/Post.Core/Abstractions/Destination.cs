
using POST.Core.Models;
using System.Text.Json.Serialization;

namespace POST.Core.Abstractions
{
    public abstract class Destination
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        [JsonIgnore]
        public virtual Address Address { get; set; }
        public ICollection<Shipment> ExceptedShipments { get; set; }
    }
}
