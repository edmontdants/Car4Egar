using Car4EgarAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4EgarAPI.Models.Configurations
{
    public class BorrowerConfigration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> EntityBuilder)
        {
            EntityBuilder.HasKey(B => B.NID);
            EntityBuilder.Property(B => B.NID).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Name).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Address).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Email).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Password).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            //EntityBuilder.Property(B => B.Type).IsRequired(true)
            //    .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.PhoneNumber).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Bank_CardNumber).IsRequired(false)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Bank_ExpireDate).IsRequired(false)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Bank_CSC).IsRequired(false)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.PhoneNumber).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Photo).IsRequired(false)
                .HasMaxLength(20480);

            EntityBuilder.Property(B => B.Balance).HasDefaultValue(0.0)
                .HasColumnType("money").HasMaxLength(10);

            EntityBuilder.Property(B => B.Fine).HasDefaultValue(0.0)
               .HasColumnType("money").HasMaxLength(10);

            EntityBuilder.Property(B => B.Rate).HasDefaultValue(5.0)
               .HasMaxLength(10);



        }
    }
}
