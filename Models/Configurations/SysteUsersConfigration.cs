using Car4EgarAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4EgarAPI.Models.Configurations
{
    public class SysteUsersConfigration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> EntityBuilder)
        {
            EntityBuilder.HasKey(B => B.NID);
            EntityBuilder.Property(B => B.NID).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.UserName).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Password).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Email).IsRequired(true)
                .HasMaxLength(100).IsUnicode();

            EntityBuilder.Property(B => B.Role).IsRequired(false)  //
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.IsActivated).HasDefaultValue(true);

            EntityBuilder.Property(B => B.Address).IsRequired(false)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.PhoneNumber).IsRequired(false)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Gender).IsRequired(false)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.BirthDate).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Photo).IsRequired(false)
                .HasMaxLength(400);

            EntityBuilder.Property(B => B.IdentityPhoto).IsRequired(false)
                .HasMaxLength(400);

            EntityBuilder.Property(B => B.DriverLicencePhoto).IsRequired(false)
                .HasMaxLength(400);

            EntityBuilder.Property(B => B.DriverLicenceNumber).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.DriverLicenceEXDate).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Bank_AccountNumber).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Bank_NID).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Bank_Name).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Bank_Branch).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Card_EXDate).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Card_Number).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Card_HolderName).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Card_CVC).IsRequired(false)
            .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Balance).HasDefaultValue(0.0)
                .HasColumnType("money").HasMaxLength(10).IsRequired(false);

            EntityBuilder.Property(B => B.Fine).HasDefaultValue(0.0)
               .HasColumnType("money").HasMaxLength(10).IsRequired(false);

            EntityBuilder.Property(B => B.Rate).HasDefaultValue(0.0)
               .HasColumnType("money").HasMaxLength(10).IsRequired(false);



        }
    }
}
