using Project.Core.Domain.Model;
using Ftsoft.Domain.Specification;

namespace Project.Core.Domain.Specifications;

public static class 
    Specification
{
    public static ISpecification<Song> GetById(long SongId) => Specification<Song>.Create(x => x.Id == SongId);
}