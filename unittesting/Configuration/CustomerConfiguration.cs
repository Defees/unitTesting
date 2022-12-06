using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using unittesting.Entities;

namespace unittesting.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(Customer => Customer.Id);
            builder.HasIndex(Customer => Customer.Id).IsUnique();
            builder.Property(Customers => Customers.Name).HasMaxLength(100);
        }
    }
}
