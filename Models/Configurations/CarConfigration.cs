using Car4EgarAPI.Models.Context;
using Car4EgarAPI.Models.Entities;
using Car4EgarAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4EgarAPI.Models.Configurations
{
    public class CarConfigration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> EntityBuilder)
        {
            


            EntityBuilder.HasKey(B => B.VIN);
            EntityBuilder.Property(B => B.VIN).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Color).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.LicenseNumber).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Seats).HasDefaultValue(4)
                .HasMaxLength(10).IsUnicode();

            EntityBuilder.Property(B => B.Rate).HasDefaultValue(5.0)
              .HasMaxLength(10);

            EntityBuilder.Property(B => B.Mailage).HasDefaultValue(0.0)
              .HasMaxLength(20);

            EntityBuilder.Property(B => B.CarType).IsRequired(true)
                .HasMaxLength(10).IsUnicode();

            EntityBuilder.Property(B => B.LicenseEXDate).IsRequired(true);

            EntityBuilder.Property(B => B.Year).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.AvailableForRent).IsRequired(true)
                            .IsUnicode();

            EntityBuilder.Property(B => B.ModelName).IsRequired(true)
                            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Insurance).IsRequired(true)
                            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.LocationOfRent).IsRequired(true)
                            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.BrandName).IsRequired(true)
                            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.CostPerDay).HasDefaultValue(0.0)
                .HasColumnType("money").HasMaxLength(10);

            EntityBuilder.Property(B => B.Image).IsRequired(false)
                .HasMaxLength(20480);

            EntityBuilder.Property(B => B.RegistrationDate).IsRequired(true);

            EntityBuilder.Property(B => B.GearBoxType).IsRequired(true)
                           .HasMaxLength(20).IsUnicode();


















        }
    }
}
