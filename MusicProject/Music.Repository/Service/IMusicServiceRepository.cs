using Music.DataAccess.Entities;

namespace Music.Repository.Service;

public interface IMusicServiceRepository
{
    Guid WriteMusic(MusicProps music);
    MusicProps ReadMusicById(Guid MusicId);
    List<MusicProps> ReadAllMusics();
    void RemoveMusic(Guid musicId);
    void UpdateMusic(MusicProps music);
}