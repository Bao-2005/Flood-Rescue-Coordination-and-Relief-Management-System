using FloodRescueManagementSystem.Entities.Group5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Repositories.Group5.EntitiesConfiguration
{
    public class FloodRescueDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<RescueTeam> RescueTeams { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ReliefItem> ReliefItems { get; set; }
        public DbSet<RescueRequest> RescueRequests { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<DistributionLog> DistributionLogs { get; set; }
        public FloodRescueDbContext(DbContextOptions<FloodRescueDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // =======================
            // 1. USER ACCOUNT
            // =======================
            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("System.UserAccount");

                entity.HasKey(e => e.UserAccountID);

                entity.Property(e => e.UserName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Password)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.Phone)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.EmployeeCode)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                      .IsRequired();
            });

            // =======================
            // 2. RESCUE TEAMS
            // =======================
            modelBuilder.Entity<RescueTeam>(entity =>
            {
                entity.ToTable("rescue_teams");

                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.TeamName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Status)
                      .HasMaxLength(50)
                      .HasDefaultValue("READY");

                entity.Property(e => e.UpdatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.CurrentLatitude)
                      .HasColumnType("decimal(9,6)");

                entity.Property(e => e.CurrentLongitude)
                      .HasColumnType("decimal(9,6)");

                entity.HasOne(e => e.Leader)
                      .WithMany(u => u.LedTeams)
                      .HasForeignKey(e => e.LeaderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =======================
            // 3. VEHICLES
            // =======================
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles");

                entity.HasKey(e => e.VehicleId);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Type)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Status)
                      .HasMaxLength(50)
                      .HasDefaultValue("AVAILABLE");

                entity.Property(e => e.Capacity)
                      .IsRequired();

                entity.HasOne(e => e.Manager)
                      .WithMany()
                      .HasForeignKey(e => e.ManagerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =======================
            // 4. RELIEF ITEMS
            // =======================
            modelBuilder.Entity<ReliefItem>(entity =>
            {
                entity.ToTable("relief_items");

                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Unit)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.StockQuantity)
                      .HasDefaultValue(0);

                entity.Property(e => e.WarehouseLocation)
                      .HasMaxLength(255);

                entity.Property(e => e.LastUpdated)
                      .HasDefaultValueSql("GETDATE()");
            });

            // =======================
            // 5. RESCUE REQUESTS
            // =======================
            modelBuilder.Entity<RescueRequest>(entity =>
            {
                entity.ToTable("rescue_requests");

                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.ImageUrl)
                      .HasMaxLength(500);

                entity.Property(e => e.AddressText)
                      .HasMaxLength(255);

                entity.Property(e => e.Priority)
                      .HasMaxLength(50)
                      .HasDefaultValue("MEDIUM");

                entity.Property(e => e.Status)
                      .HasMaxLength(50)
                      .HasDefaultValue("PENDING");

                entity.Property(e => e.Latitude)
                      .HasColumnType("decimal(9,6)");

                entity.Property(e => e.Longitude)
                      .HasColumnType("decimal(9,6)");

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Citizen)
                      .WithMany()
                      .HasForeignKey(e => e.CitizenId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Verifier)
                      .WithMany()
                      .HasForeignKey(e => e.VerifierId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =======================
            // 6. MISSIONS
            // =======================
            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("missions");

                entity.HasKey(e => e.MissionId);

                entity.Property(e => e.StartedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Request)
                      .WithMany()
                      .HasForeignKey(e => e.RequestId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Team)
                      .WithMany()
                      .HasForeignKey(e => e.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Vehicle)
                      .WithMany()
                      .HasForeignKey(e => e.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Assigner)
                      .WithMany()
                      .HasForeignKey(e => e.AssignedBy)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =======================
            // 7. DISTRIBUTION LOGS
            // =======================
            modelBuilder.Entity<DistributionLog>(entity =>
            {
                entity.ToTable("distribution_logs");

                entity.HasKey(e => e.LogId);

                entity.Property(e => e.QuantityDistributed)
                      .IsRequired();

                entity.Property(e => e.RecipientLocation)
                      .HasMaxLength(255);

                entity.Property(e => e.DistributedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Mission)
                      .WithMany()
                      .HasForeignKey(e => e.MissionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Item)
                      .WithMany()
                      .HasForeignKey(e => e.ItemId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
