using Post.Core.Abstractions;
using POST.Core.Abstractions;
using System.Text.Json.Serialization;

namespace POST.Core.Models
{
    public class Shipment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public State State { get; set; } = State.Preparing;
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid DepartmentSenderId { get; set; }
        [JsonIgnore]
        virtual public Department DepartmentSender {  get; set; }
        public Guid DestinationId { get; set; }
        [JsonIgnore]
        public Destination Destination { get; set; }
        public ICollection<Box> Boxes { get; set; } = new List<Box>();
        private Shipment(string Description, Guid SenderId, Guid DepartmentSenderId, Guid DestinationId, Guid ReceiverId) 
        {
            this.Description = Description;
            this.SenderId = SenderId;
            this.ReceiverId = ReceiverId;
            this.DepartmentSenderId = DepartmentSenderId;
            this.DestinationId = DestinationId;
        }
        private Shipment() { }
        public static Shipment FactoryMethod(string Description, Guid SenderId, Guid DepartmentSenderId, Guid DestinationId, Guid ReceiverId)
        {
            return new Shipment(Description, SenderId, DepartmentSenderId, DestinationId, ReceiverId);
        }
        public static Shipment FactoryMethod(string Description, Guid SenderId, Guid DepartmentSenderId, Guid DestinationId)
        {
            Guid ReceiverId = Guid.Empty;
            return new Shipment(Description, SenderId, DepartmentSenderId, DestinationId, ReceiverId);
        }
    }
}
