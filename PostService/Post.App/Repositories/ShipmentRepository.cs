using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Post.Core.Abstractions;
using Post.Core.Abstractions.Repositories;
using POST.Core.Models;
using POST.DAL;
using System.Runtime.CompilerServices;

namespace Post.App.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly PostDbContext _postDbContext;
        public ShipmentRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }
        public async Task<Guid> Add(Shipment shipment)
        {
            await _postDbContext.AddAsync(shipment);
            await _postDbContext.SaveChangesAsync();
            return shipment.Id;
        }

        public async Task<bool> AddBox(Guid shipmentId, Box box)
        {
            var shipment = await GetById(shipmentId);
            shipment.Boxes.Add(box);
            await _postDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBox(Guid shipmentId, Guid boxId)
        {
            var shipment = await GetById(shipmentId);
            var box = shipment.Boxes.Where(box => box.Id == boxId).FirstOrDefault();
            if (box == null) throw new KeyNotFoundException($"The box with ID {boxId} is not found in the shipment {shipmentId}.");
            shipment.Boxes.Remove(box);
            await _postDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var shipment = await GetById(id);
            _postDbContext.Shipments.Remove(shipment);
            await _postDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Shipment>> GetAll(CancellationToken cancellationToken)
        {
            return await _postDbContext.Shipments.ToListAsync(cancellationToken);
        }

        public async Task<Shipment> GetById(Guid id)
        {
            var shipment = await _postDbContext.Shipments.FindAsync(id);
            if (shipment == null) throw new KeyNotFoundException($"The shipment with ID {id} is not found.");
            return shipment;
        }

        public async Task<bool> SetState(Guid shipmentId, State state)
        {
            var shipment = await GetById(shipmentId);
            shipment.State = state;
            await _postDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ICollection<Box>> GetAllBoxex(Guid shipmentId, CancellationToken cancellationToken)
        {
            var shipment = await GetById(shipmentId);
            return shipment.Boxes.ToList();
        }
    }
}
