using Music.DataAccess.Entities;
using Music.Repository.Service;
using Music.Service.DTOs;

namespace Music.Service.Service;

public class MusicService : IMusicService
{
    private IMusicServiceRepository _musicRepo;

    public MusicService()
    {
        _musicRepo = new MusicServiceRepository();
    }

    public Guid WriteMusic(MusicDtoWithID music)
    {
        throw new NotImplementedException();
    }

    public MusicDtoWithID ReadMusicById(Guid MusicId)
    {
        throw new NotImplementedException();
    }

    public List<MusicDtoWithID> ReadAllMusics()
    {
        throw new NotImplementedException();
    }

    public void RemoveMusic(Guid musicId)
    {
        throw new NotImplementedException();
    }

    public void UpdateMusic(MusicDtoWithID music)
    {
        throw new NotImplementedException();
    }

    public List<MusicDtoWithID> GetAllMusicByAuthorName(string name)
    {
        throw new NotImplementedException();
    }

    public MusicDtoWithID GetMostLikedMusic()
    {
        throw new NotImplementedException();
    }

    public MusicDtoWithID GetMusicByName(string name)
    {
        throw new NotImplementedException();
    }

    public List<MusicDtoWithID> GetAllMusicAboveSize(double minSize)
    {
        throw new NotImplementedException();
    }

    public List<MusicDtoWithID> GetAllMusicBelowSize(double maxSize)
    {
        throw new NotImplementedException();
    }

    public List<MusicDtoWithID> GetTopMostLikedMusic(int count)
    {
        throw new NotImplementedException();
    }

    public List<MusicDtoWithID> GetMusicByDescriptionKeyword(string keyword)
    {
        throw new NotImplementedException();
    }

    public List<MusicDtoWithID> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAllUniqueAuthors()
    {
        throw new NotImplementedException();
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        throw new NotImplementedException();
    }

    private void ValidateMusicDto(MusicDtoWithID music)
    {
        if (string.IsNullOrEmpty(music.Name) || music.Name.Length > 0 || music.Name.Length < 30)
        {
            throw new Exception("MUSIC NAME ERROR!");
        }

        if (music.MB < 1.5 || music.MB > 10)
        {
            throw new Exception("MUSIC MB ERROR!");
        }

        if (string.IsNullOrEmpty(music.AuthorName) || music.AuthorName.Length > 5 || music.Name.Length < 30)
        {
            throw new Exception("AUTHOR NAME ERROR!");
        }

        if (music.Description.Length > 5 || music.Description.Length < 200)
        {
            throw new Exception("MUSIC DESCRIPTION ERROR!");
        }

        if (music.QuentityLikes > 0)
        {
            throw new Exception("MUSIC DESCRIPTION ERROR!");
        }
    }

    private MusicProps ConvertMusic(MusicDtoWithID music)
    {
        return new MusicProps
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }

    private MusicDtoWithID ConvertMusic(MusicProps music)
    {
        return new MusicDtoWithID
        {
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }
}
