using Car4EgarAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car4EgarAPI.Models.Configurations
{
    public class TransactionConfigration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> EntityBuilder)
        {
            EntityBuilder.HasKey(B => B.TID);

            EntityBuilder.Property(B => B.SenderID).IsRequired(true);
            EntityBuilder.Property(B => B.RecieverID).IsRequired(true);

            EntityBuilder.Property(B => B.TypeOfTrans).IsRequired(true)
                .HasMaxLength(20).IsUnicode();

            EntityBuilder.Property(B => B.Amount).HasDefaultValue(0.0)
               .HasColumnType("money").HasMaxLength(10);

            EntityBuilder.Property(B => B.Date).IsRequired(true);   







        }
    }
}
