using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using unittesting.Entities;

namespace unittesting.Configuration
{
        public class OrderConfiguration : IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.ToTable("Orders");
                builder.HasKey(Order => Order.Id);
                builder.HasIndex(Order => Order.Id).IsUnique();
                builder.Property(Order => Order.Code).HasMaxLength(6);
            }
        }
    }
