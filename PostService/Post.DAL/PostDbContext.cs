﻿using Microsoft.EntityFrameworkCore;
using POST.Core.Abstractions;
using POST.Core.Models;

namespace POST.DAL
{
    public class PostDbContext: DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Box> Boxes { get; set; } 
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Slot> Slots { get; set; }
        
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
                .HasIndex(Address => new { Address.City, Address.Street });
            modelBuilder.Entity<Address>()
                .HasMany(adr => adr.Destinations)
                .WithOne(dest => dest.Address)
                .HasForeignKey(dest => dest.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Box>()
                .HasKey(box => box.Id);

            modelBuilder.Entity<Client>()
                .HasKey(client => client.Id);
            modelBuilder.Entity<Client>()
                .HasIndex(client => client.Phone);
            modelBuilder.Entity<Client>()
                .HasIndex(client => new { client.FirstName, client.SecondName });

            modelBuilder.Entity<Employee>()
                .HasKey(Employee => Employee.Id);
            modelBuilder.Entity<Employee>()
                .HasIndex(employee => new { employee.FirstName, employee.SecondName });
            modelBuilder.Entity<Employee>()
                .HasIndex(Employee => Employee.DepartmentId);

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
            modelBuilder.Entity<Shipment>()
                .HasOne(Shipment => Shipment.Sender)
                .WithMany(Sender => Sender.SentShipments)
                .HasForeignKey(Shipment => Shipment.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Shipment>()
                .HasOne(Shipment => Shipment.Receiver)
                .WithMany (Receiver => Receiver.ExpectedShipments)
                .HasForeignKey (Shipment => Shipment.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Slot>()
                .HasKey(slot => slot.Id);

            modelBuilder.Entity<ParcelLocker>()
                .HasMany(ParcelLocker => ParcelLocker.Slots)
                .WithOne(Slot => Slot.ParcelLocker)
                .HasForeignKey(Slot => Slot.ParcelLockerId);

            modelBuilder.Entity<Destination>()
                .HasKey (destination => destination.Id);
            modelBuilder.Entity<Destination>()
                .HasDiscriminator<string>("DestinationType")
                .HasValue<Department>("Department")
                .HasValue<ParcelLocker>("ParcelLocker");
        }
    }
}
