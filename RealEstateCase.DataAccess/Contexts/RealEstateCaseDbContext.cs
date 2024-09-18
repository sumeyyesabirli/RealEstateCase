﻿using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealEstateCase.Core.Entities;
using RealEstateCase.Core.Helper;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Contexts
{
    public class RealEstateCaseDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;    

        public RealEstateCaseDbContext(DbContextOptions<RealEstateCaseDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;       
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Product)
                .WithMany(p => p.Favorites)
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>().HasKey(p => new { p.UserId, p.RoleId, p.Id });
            modelBuilder.Entity<UserRole>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedById).IsRequired(); 
            });
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            try
            {
                TrackChanges();
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        // Değişiklikleri izlemek ve audit işlemleri
        private void TrackChanges()
        {
            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                if (entry.Entity is not BaseEntity entity) continue;

                var userId = ClaimHelper.GetUserId(_httpContextAccessor);

                switch (entry.State)
                {
                    case EntityState.Added:
                        ApplyConceptsForAddedEntity(entry,userId);
                        break;
                    case EntityState.Modified:
                        ApplyConceptsForUpdatedEntity(entry, userId);
                        break;
                    case EntityState.Deleted:
                        ApplyConceptsForDeletedEntity(entry, userId);
                        break;
                }
            }
        }

        // Yeni eklenen entity için yapılan işlemler
        protected virtual void ApplyConceptsForAddedEntity(EntityEntry entry, int? userId)
        {
            if (entry.Entity is BaseEntity entity)
            {
                entity.IsDeleted = false;
                entity.IsActive = true;
                entity.CreatedDate = DateTime.Now;
                entity.CreatedById = userId; // CreatedById ayarlanıyor
            }
        }

        // Güncellenen entity için yapılan işlemler
        protected virtual void ApplyConceptsForUpdatedEntity(EntityEntry entry, int? userId)
        {
            if (entry.Entity is BaseEntity entity)
            {
                entity.IsDeleted = false;
                entity.IsActive = true;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedById = userId;
            }
        }

        // Silinen entity için yapılan işlemler (soft delete)
        protected virtual void ApplyConceptsForDeletedEntity(EntityEntry entry, int? userId)
        {
            if (entry.Entity is BaseEntity entity)
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedById = userId;
                entry.State = EntityState.Modified;
            }
        }
    }
}
