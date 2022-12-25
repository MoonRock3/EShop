using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimirzinEShop.Areas.Identity.Data
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<EShopUser>
    {
        public void Configure(EntityTypeBuilder<EShopUser> builder)
        {
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Address).IsRequired();
            builder.Property(u => u.Phone).IsRequired();
        }
    }
}