using Car4EgarAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4EgarAPI.Models.Configurations
{
    public class CostesConfigration : IEntityTypeConfiguration<Costes>
    {
        public void Configure(EntityTypeBuilder<Costes> EntityBuilder)
        {
            EntityBuilder.HasKey(B => B.ID);

            EntityBuilder.Property(B => B.Description).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Amount).HasDefaultValue(0.0)
                .HasColumnType("money").HasMaxLength(10);

        }
    }
}
