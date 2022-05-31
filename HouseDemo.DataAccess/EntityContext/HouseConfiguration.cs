using HouseDemo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseDemo.DataAccess.EntityContext;
public class HouseConfiguration : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    { 
        builder.HasMany(s => s.Tags)
            .WithMany(c => c.Houses)
            .UsingEntity<HouseTag>(
                j => j.HasOne(rf => rf.Tag)
                  .WithMany(f => f.HouseTags)
                  .HasForeignKey(rf => rf.FkTagId),
                j => j.HasOne(rf => rf.House)
                  .WithMany(r => r.HouseTags)
                  .HasForeignKey(rf => rf.FkHouseId),
                j => {
                    j.ToTable("HouseTags");
                    j.HasKey(t => t.HouseTagId);
                });
    }
}


