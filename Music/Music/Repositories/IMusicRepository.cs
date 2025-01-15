using Music.DataAccess.Entities;

namespace Music.Repositories;

public interface IMusicRepository
{
    Guid WriteMusic(Mussic music);
    Mussic ReadMusicById(Guid musicId);
    List<Mussic> ReadAllMusics();
    void RemoveMusic(Guid musicId);
    void UpdateMusic(Mussic music);
}
