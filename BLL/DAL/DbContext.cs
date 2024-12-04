#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public partial class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Member - SubscriptionPlan relation
            modelBuilder.Entity<SubscriptionPlan>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.SubscriptionPlans)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            // Payment - Member relation
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            // Session - Trainer relation
            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            // Schedule - Member & Session relation
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}