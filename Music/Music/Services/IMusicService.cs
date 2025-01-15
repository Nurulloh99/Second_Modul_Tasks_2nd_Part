using Music.Services.DTOs;

namespace Music.Services;

public interface IMusicService
{
    BaseMusicDto AddMusic(MusicGetDto music);
    void DeleteMusic(Guid id);
    void UpdateMusic(MusicGetDto music);
    BaseMusicDto GetMudsicById(Guid id);
    List<BaseMusicDto> GetAllMusics();
    List<BaseMusicDto> GetAllMusicsByAuthorName(string name);
    BaseMusicDto GetMostLikedMusic();
    BaseMusicDto GetMusicByName(string name);
    List<BaseMusicDto> GetAllMusicsAboveSize(double minSize);
    List<BaseMusicDto> GetAllMusicBeloveSize(double minSize);
    List<BaseMusicDto> GetTopMostLikedMusic(int count);
    List<BaseMusicDto> GetMusicByDescriptionKeyword(string keyword);
    List<BaseMusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}
