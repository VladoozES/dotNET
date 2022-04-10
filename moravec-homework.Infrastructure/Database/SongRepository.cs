using Project.Core.Domain.Model;
using Project.Core.Domain.Repositories;
using Ftsoft.Storage.EntityFramework;

namespace Project.Infrastructure.Database;

public sealed class SongRepository : EFRepository<Song>, ISongRepository
{
    public SongRepository(ProjectContext context) : base(context)
    {
    }
}