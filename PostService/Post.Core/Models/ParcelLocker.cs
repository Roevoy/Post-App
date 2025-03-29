using POST.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace POST.Core.Models
{
    public class ParcelLocker: Destination
    {
        public bool IsAvailable { get; set; } = true;
        public ICollection<Slot> Slots { get; set; } = new List<Slot>();

        private ParcelLocker (Guid AddressId) 
        { 
            this.Id = Guid.NewGuid();
            this.AddressId = AddressId; 
            this.ExceptedShipments = new List<Shipment>();
        }
        private ParcelLocker() { }
        public static ParcelLocker FactoryMethod(Guid AddressId)
        {
            return new ParcelLocker (AddressId);
        }
    }
}
