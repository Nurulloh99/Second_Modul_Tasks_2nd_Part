using Muusic.DataAccess.MusicService;

namespace Muusic.Repository.MusicRepository;

public interface IMusicRepository
{
    Guid WriteMusic(Music music);
    Music ReadById(Guid musicId);
    List<Music> ReadAllMusics();
    void RemoveMusic(Guid musicId);
    void UpdateMusic(Music music);
}