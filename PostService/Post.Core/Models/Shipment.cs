using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class Shipment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public Guid SenderId { get; set; }
        virtual public Client Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public Client Receiver {  get; set; }
        public Guid DepartmentSenderId { get; set; }
        virtual public Department DepartmentSender {  get; set; }
        public Guid DestinationId { get; set; }
        public Destination Destination { get; set; }
        public ICollection<Box> Boxes { get; set; } = new List<Box>();
        public Shipment(string Description, Guid SenderId, Guid DepartmentSenderId, 
           Guid ReceiverId, Guid DestinationId) 
        {
            this.Description = Description;
            this.SenderId = SenderId;
            this.ReceiverId = ReceiverId;
            this.DepartmentSenderId = DepartmentSenderId;
            this.DestinationId = DestinationId;
        }
        public Shipment() { }
    }
}
