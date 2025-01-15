using Music.Service.DTOs;

namespace Music.Service.Service;

public interface IMusicService
{
    Guid WriteMusic(MusicDtoWithID music);
    MusicDtoWithID ReadMusicById(Guid MusicId);
    List<MusicDtoWithID> ReadAllMusics();
    void RemoveMusic(Guid musicId);
    void UpdateMusic(MusicDtoWithID music);
    List<MusicDtoWithID> GetAllMusicByAuthorName(string name);
    MusicDtoWithID GetMostLikedMusic();
    MusicDtoWithID GetMusicByName(string name);
    List<MusicDtoWithID> GetAllMusicAboveSize(double minSize);
    List<MusicDtoWithID> GetAllMusicBelowSize(double maxSize);
    List<MusicDtoWithID> GetTopMostLikedMusic(int count);
    List<MusicDtoWithID> GetMusicByDescriptionKeyword(string keyword);
    List<MusicDtoWithID> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}