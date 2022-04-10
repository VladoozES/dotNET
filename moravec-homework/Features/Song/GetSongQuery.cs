using Project.Core.Domain.Model;
using Project.Core.Domain.Repositories;
using Project.Core.Domain.Specifications;
using Ftsoft.Storage;
using Microsoft.AspNetCore.Mvc;

public class GetSongQuery : MediatR.IRequest<Song>
{
    [FromQuery]
    public long SongId { get; set; }
}

public class GetSongQueryHandler : MediatR.IRequestHandler<GetSongQuery, Song>
{
    private readonly IReadOnlyRepository<Song> _songRepository;

    public GetSongQueryHandler(IReadOnlyRepository<Song> songRepository)
    {
        _songRepository = songRepository;
    }
    
    public async Task<Song> Handle(GetSongQuery request, CancellationToken cancellationToken)
    {
        //Where( x => x.Id == songId && x.DateTime == DateTime.Today)
        //Where( x => x.Id == songId).Where(x => x.DateTime == DateTime.Today)
        // var specification = SongSpecification.GetById(request.SongId).And(SongSpecification.GetByDate(DateTime.Today));
        // List<Song> songs = new List<Song>();
        // var newSongs = songs.Where(specification).ToList();

        var specification = Specification.GetById(request.SongId);
        var song = await _songRepository.SingleOrDefaultAsync(specification, cancellationToken);
        song.SongName = "Title";
        
        await ((IRepository<Song>)_songRepository).UnitOfWork.SaveChangesAsync(cancellationToken);

        return song;
    }
}