namespace Muusic.Service;

public interface IMusicSrvice
{
    Guid AddMusic(MusicSrvice music);
    MusicSrvice GetById(Guid musicId);
    List<MusicSrvice> GetAllMusics();
    void RemoveMusic(Guid musicId);
    void UpdateMusic(MusicSrvice music);
    List<MusicSrvice> GetAllMusicByAuthorName(string name);
    MusicSrvice GetMostLikedMusic();
    MusicSrvice GetMusicByName(string name);
    List<MusicSrvice> GetAllMusicAboveSize(double minSize);
    List<MusicSrvice> GetAllMusicBelowSize(double maxSize);
    List<MusicSrvice> GetTopMostLikedMusic(int count);
    List<MusicSrvice> GetMusicByDescriptionKeyword(string keyword);
    List<MusicSrvice> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}