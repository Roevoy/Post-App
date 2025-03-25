using Post.Core.Abstractions;
using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class Shipment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public State State { get; set; } = State.Preparing;
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid DepartmentSenderId { get; set; }
        virtual public Department DepartmentSender {  get; set; }
        public Guid DestinationId { get; set; }
        public Destination Destination { get; set; }
        public ICollection<Box> Boxes { get; set; }
        public Shipment(string Description, Guid SenderId, Guid DepartmentSenderId, Guid DestinationId, ICollection<Box> boxes,
           Guid? ReceiverId = null) 
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
