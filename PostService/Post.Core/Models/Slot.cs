using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class Slot
    {
        public int Number { get; set; }
        public bool IsOpen { get; set; } = false;
        public bool isAvailable { get; set; } = true;
        public Guid Id { get; set; } = Guid.NewGuid();
        public Size Size { get; set; }
        public Guid ParcelLockerId { get; set; }
        public ParcelLocker ParcelLocker { get; set; }
        public Slot(int number, Size size, Guid parcelLockerId)
        {
            Number = number;
            Size = size;
            ParcelLockerId = parcelLockerId;
        }
        public Slot() { }
    }
}
