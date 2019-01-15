using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto2List.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.Data.Maps
{
    public class NotaTarefaMap : IEntityTypeConfiguration<NotaTarefa>
    {
        public void Configure(EntityTypeBuilder<NotaTarefa> builder)
        {
            builder.ToTable("NotaTarefa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");

        }
    }
}
