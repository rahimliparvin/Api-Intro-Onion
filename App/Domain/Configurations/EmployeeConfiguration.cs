using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(m => m.FullName).HasMaxLength(100).IsRequired(false);
            builder.Property(m => m.Address).IsRequired().HasMaxLength(256);
            builder.Property(m => m.Age).IsRequired();
        }
    }
}
