using Datn.Domain.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Infrastructure.Database.Configuration
{
    public class CartDetailConfig : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Cart).WithMany(x=>x.CartDetails).HasForeignKey(x=>x.CartId);
            builder.HasOne(x => x.Product).WithMany(x => x.CartDetails).HasForeignKey(x => x.ProductId);
        }
    }
}
