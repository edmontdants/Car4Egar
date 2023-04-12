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

            //EntityBuilder.Property(B => B.Name).IsRequired(true)
            //    .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Email).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Password).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.UserName).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Role).IsRequired(true)
                .HasMaxLength(20).IsUnicode();




        }
    }
}
