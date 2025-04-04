﻿using Microsoft.EntityFrameworkCore;
using Post.Core.Models;
using POST.Core.Abstractions;
using POST.Core.Models;

namespace POST.DAL
{
    public class PostDbContext: DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Destination> Destinations { get; set; } 
        public DbSet<Shipment> Shipments { get; set; }
        
        public PostDbContext(DbContextOptions<PostDbContext> options)
                : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .HasKey(address => address.Id);
            modelBuilder.Entity<Address>()
                .HasIndex(address => address.City);
            modelBuilder.Entity<Address>()
                .HasMany(adr => adr.Destinations)
                .WithOne(dest => dest.Address)
                .HasForeignKey(dest => dest.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shipment>()
                .HasKey(Shipment => Shipment.Id);
            modelBuilder.Entity<Shipment>()
                .HasMany(Shipment => Shipment.Boxes)
                .WithOne(Box => Box.Shipment)
                .HasForeignKey(Box => Box.ShipmentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Shipment>()
                .HasOne(Shipment => Shipment.Destination)
                .WithMany(Destination => Destination.ExceptedShipments)
                .HasForeignKey(Shipment => Shipment.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Shipment>()
                .HasOne(Shipment=> Shipment.DepartmentSender)
                .WithMany(Department => Department.SentShipments)
                .HasForeignKey(Shipment => Shipment.DepartmentSenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Destination>()
                .HasKey (destination => destination.Id);
            modelBuilder.Entity<Destination>()
                .HasDiscriminator<string>("DestinationType")
                .HasValue<Department>("Department")
                .HasValue<ParcelLocker>("ParcelLocker")
                .HasValue<HomeDelivery>("HomeDelivery");

            modelBuilder.Entity<ParcelLocker>()
                .HasMany(ParcelLocker => ParcelLocker.Slots)
                .WithOne(Slot => Slot.ParcelLocker)
                .HasForeignKey(Slot => Slot.ParcelLockerId);

        }
    }
}
