using Music.DataAccess.Entities;

namespace Music.Repository.Services;

public interface IMusicRepository
{
    Guid WriteMusic(Muusic music);
    void DeleteMusic(Guid id);
    void UpdateMusic(Muusic music);
    Muusic ReadMusicById(Guid id);
    List<Muusic> ReadAllMusic();
}