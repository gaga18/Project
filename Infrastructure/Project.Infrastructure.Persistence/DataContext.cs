﻿using Project.Core.Application.Interfaces.Contracts;
using Project.Core.Domain.Basics;
using Project.Core.Domain.Entities;
using Project.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PersonPerson> PersonPersons { get; set; }

        private readonly IActiveUserService user;
        public DataContext(DbContextOptions<DataContext> options, IActiveUserService user)
            : base(options) => this.user = user;

        #region SaveChanges -ების გადატვირთვა
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                this.Audition(entry);

            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                this.Audition(entry);

            return base.SaveChanges();
        }
        private void Audition(EntityEntry<AuditableEntity> entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    //entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = user.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.DateUpdated = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = user.UserId;

                    // არ შეიცვლება ქვემოთ ჩამოთვლილი ველები
                    entry.Property(nameof(AuditableEntity.CreatedBy)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.DateCreated)).IsModified = false;

                    entry.Property(nameof(AuditableEntity.DeletedBy)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.DateDeleted)).IsModified = false;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;

                    // შეიცვლება მხოლოდ ქვემოთ ჩამოთვლილი ველები
                    entry.Entity.DateDeleted = DateTime.UtcNow;
                    entry.Entity.DeletedBy = user.UserId;
                    break;
            };
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new PersonPersonConfiguration());
        }
    }
}
