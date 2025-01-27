using Music.Service.DTOs;

namespace Music.Service.Service;

public interface IMusicService
{
    Guid AddMusic(MusicDto musicDto);
    void DeleteMusic(Guid id);
    List<MusicDto> GetAllMusic();
    void UpdateMusic(MusicDto musicDto);
    MusicDto GetMusicById(Guid id);
    List<MusicDto> GetAllMusicByAuthorName(string name);
    MusicDto GetMostLikedMusic();
    MusicDto GetMusicByName(string name);
    List<MusicDto> GetAllMusicAboveSize(double minSizeMB);
    List<MusicDto> GetAllMusicBelowSize(double maxSizeMB);
    List<MusicDto> GetTopMostLikedMusic(int count);
    List<MusicDto> GetLowMostLikedMusic(int count);
    List<MusicDto> GetMusicByDescriptionKeyword(string keyword);
    List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}