
using POST.Core.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace POST.Core.Models
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Region { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public ICollection<Destination> Destinations { get; set; } = new List<Destination>();
        private Address(string Region, string Country, string City, string Street, string Number)
        {
            this.Region = Region;
            this.Country = Country;
            this.City = City;
            this.Street = Street;
            this.Number = Number;
        }
        private Address() { }
        public static Address FactoryMethod(string Region, string Country, string City, string Street, string Number)
        {
            return new Address(Region, Country, City, Street, Number);
        }
    }
}
