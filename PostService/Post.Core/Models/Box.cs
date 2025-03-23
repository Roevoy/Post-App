
using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class Box
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public double Weight { get; set; }
        public Size Size { get; set; }
        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public Box(string Description, double Weight, Size Size, Guid ShipmentId) 
        {
            this.Description = Description;
            this.Weight = Weight;
            this.Size = Size;
            this.ShipmentId = ShipmentId;
        }
        public Box() { }
    }
}
