using Project.Infrastructure.Database;
using MediatR;

namespace Project.Startup.Features.Song;

public class CreateNewSongCommand : IRequest<bool>
{
    public string SongName { get; set; }
    public string SongText { get; set; }
    public string SongPath { get; set; }
}

public class CreateNewSongCommandHandler : IRequestHandler<CreateNewSongCommand, bool>
{
    private readonly ProjectContext _projectContext;

    public CreateNewSongCommandHandler(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }
    
    public async Task<bool> Handle(CreateNewSongCommand request, CancellationToken cancellationToken)
    {
        var song = new Core.Domain.Model.Song()
        {
            SongName = request.SongName,
            SongText = request.SongText,
            SongPath = request.SongPath
        };

        await _projectContext.Songs.AddAsync(song, cancellationToken);
        var result = await _projectContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}