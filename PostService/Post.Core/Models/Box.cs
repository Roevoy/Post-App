
using POST.Core.Abstractions;
using System.Text.Json.Serialization;

namespace POST.Core.Models
{
    public class Box
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public double Weight { get; set; }
        public Size Size { get; set; }
        public Guid ShipmentId { get; set; }
        [JsonIgnore]
        public Shipment Shipment { get; set; }
        private Box(string Description, double Weight, Size Size, Guid ShipmentId) 
        {
            this.Description = Description;
            this.Weight = Weight;
            this.Size = Size;
            this.ShipmentId = ShipmentId;
        }
        private Box() { }
        public static Box FactoryMethod (string Description, double Weight, Size Size, Guid ShipmentId)
        {
            return new Box(Description, Weight, Size, ShipmentId);
        }
    }
}
