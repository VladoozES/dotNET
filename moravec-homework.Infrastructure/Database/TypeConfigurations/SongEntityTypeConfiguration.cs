using Project.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Infrastructure.Database.TypeConfigurations;

public class SongEntityTypeConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.Property(x => x.SongName).HasMaxLength(100);
        builder.Property(x => x.SongText).HasMaxLength(3999);
        builder.Property(x => x.SongPath).HasMaxLength(1000);
    }
}