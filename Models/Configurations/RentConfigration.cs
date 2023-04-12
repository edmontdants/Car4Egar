using Car4EgarAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4EgarAPI.Models.Configurations
{
    public class RentConfigration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> EntityBuilder)
        {
            EntityBuilder.HasKey(B => B.RentID);

            EntityBuilder.Property(B => B.Status).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            //EntityBuilder.Property(B => B.RentAmount).HasDefaultValue(0.0)
            //    .HasColumnType("money").HasMaxLength(10);

            //EntityBuilder.Property(B => B.AdditionalAmount).HasDefaultValue(0.0)
            //    .HasColumnType("money").HasMaxLength(10);

            EntityBuilder.Property(B => B.TotalAmount).HasDefaultValue(0.0)
                .HasColumnType("money").HasMaxLength(10);

            //EntityBuilder.Property(B => B.Fine).HasDefaultValue(0.0)
            //    .HasColumnType("money").HasMaxLength(10);

            //EntityBuilder.Property(B => B.StartData).IsRequired(true);

            EntityBuilder.Property(B => B.EndtData).IsRequired(false);//

            EntityBuilder.Property(B => B.ActualEndData).IsRequired(false);//

            //EntityBuilder.Property(B => B.Afforded).IsRequired(false)
            //    .HasMaxLength(20).IsUnicode();

            //EntityBuilder.Property(B => B.PromoDiscount).HasDefaultValue(5.0)
            //   .HasMaxLength(10);

            EntityBuilder.Property(B => B.MeterStart).HasDefaultValue(0.0)
               .HasMaxLength(10);

            EntityBuilder.Property(B => B.MeterEnd).HasDefaultValue(0.0)
               .HasMaxLength(10);

        }
    }
}
