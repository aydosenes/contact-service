using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.CodeFirst
{
    public class TestMapping //: IEntityTypeConfiguration<Test>
    {
        //public void Configure(EntityTypeBuilder<Test> builder)
        //{
        //    builder.HasKey(b => b.Id);
        //    builder.Property(b => b.Id).UseIdentityColumn();
        //    builder.Property(b => b.TestNo).IsRequired().HasMaxLength(10);
        //    builder.Property(b => b.TestName).IsRequired().HasMaxLength(20);
        //}

    }
}
