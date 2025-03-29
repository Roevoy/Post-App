using POST.Core.Abstractions;
using System.Text.Json.Serialization;

namespace POST.Core.Models
{
    public class Slot
    {
        public int Number { get; set; }
        public bool IsOpen { get; set; } = false;
        public Guid ShipmentId { get; set; } = Guid.Empty;
        public Guid Id { get; set; } = Guid.NewGuid();
        public Size Size { get; set; }
        public Guid ParcelLockerId { get; set; }
        [JsonIgnore]
        public ParcelLocker ParcelLocker { get; set; }
        private Slot(int number, Size size, Guid parcelLockerId)
        {
            Number = number;
            Size = size;
            ParcelLockerId = parcelLockerId;
        }
        private Slot() { }
        public static Slot FactoryMethod(int number, Size size, Guid parcelLockerId)
        {
            return new Slot(number, size, parcelLockerId);
        }
    }
}
