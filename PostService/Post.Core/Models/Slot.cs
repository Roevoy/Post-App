using POST.Core.Abstractions;
using POST.Core.Models;


namespace POST.Core.Models
{
    public class Slot
    {
        public bool isAvailable { get; set; } = true;
        public Guid Id { get; set; } = Guid.NewGuid();
        public Size Size { get; set; }
        public Guid ParcelLockerId { get; set; }
        public ParcelLocker ParcelLocker { get; set; }
        public Slot(Size size, Guid parcelLockerId)
        {
            Size = size;
            ParcelLockerId = parcelLockerId;
        }
        public Slot() { }
    }
}
