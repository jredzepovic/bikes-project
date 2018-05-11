using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bikes_project.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalEquipment>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdBikeNavigation)
                    .WithMany(p => p.AdditionalEquipment)
                    .HasForeignKey(d => d.IdBike)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionalEquipment_Bike");
            });

            modelBuilder.Entity<AdvertType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Bike>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.TireSize).HasMaxLength(20);

                entity.HasOne(d => d.IdBikeConditionNavigation)
                    .WithMany(p => p.Bike)
                    .HasForeignKey(d => d.IdBikeCondition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bike_BikeCondition");

                entity.HasOne(d => d.IdBikeTypeNavigation)
                    .WithMany(p => p.Bike)
                    .HasForeignKey(d => d.IdBikeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bike_BikeType");

                entity.HasOne(d => d.IdCountyNavigation)
                    .WithMany(p => p.Bike)
                    .HasForeignKey(d => d.IdCounty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bike_County");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Bike)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bike_User");
            });

            modelBuilder.Entity<BikeAdvertType>(entity =>
            {
                entity.HasKey(e => new { e.IdBike, e.IdAdvertType })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Bike_AdvertType");

                entity.HasOne(d => d.IdAdvertTypeNavigation)
                    .WithMany(p => p.BikeAdvertType)
                    .HasForeignKey(d => d.IdAdvertType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdvertType");

                entity.HasOne(d => d.IdBikeNavigation)
                    .WithMany(p => p.BikeAdvertType)
                    .HasForeignKey(d => d.IdBike)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bike");
            });

            modelBuilder.Entity<BikeCondition>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<BikeType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CellPhone)
                    .IsRequired()
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Oib)
                    .IsRequired()
                    .HasColumnName("OIB")
                    .HasColumnType("nchar(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("char(64)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("nchar(20)");

                entity.HasOne(d => d.IdCountyNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdCounty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_County");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });
        }
    }
}
