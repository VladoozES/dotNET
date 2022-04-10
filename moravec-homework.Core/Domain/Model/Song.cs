using Ftsoft.Domain;

namespace Project.Core.Domain.Model;

public class Song : BaseModel, IAggregateRoot
{
    public string SongName { get; set; }
    public string SongText { get; set; }
    public string SongPath { get; set; }
}