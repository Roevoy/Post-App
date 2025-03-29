using POST.Core.Abstractions;
using POST.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Core.Models
{
    public class HomeDelivery : Destination
    {
        public Guid RecipientId { get; set; }
        private HomeDelivery(Guid RecipientId, Guid AddressId) 
        {
            this.Id = Guid.NewGuid();
            this.AddressId = AddressId;
            this.RecipientId = RecipientId;
            this.ExceptedShipments = new List<Shipment>();
        }
        private HomeDelivery() { }
        public static HomeDelivery FactoryMethod(Guid RecipientId, Guid AddressId)
        {
            return new HomeDelivery(RecipientId, AddressId);
        }
    }
}
