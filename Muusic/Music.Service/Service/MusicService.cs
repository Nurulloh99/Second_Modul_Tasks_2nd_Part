using Music.DataAccess.Entities;
using Music.Repository.Services;
using Music.Service.DTOs;

namespace Music.Service.Service;

public class MusicService : IMusicService
{
    private readonly IMusicRepository _musicRepo;

    public MusicService()
    {
        _musicRepo = new MusicRepository();
    }

    private Muusic ConvertToEntity(MusicDto musicDto)
    {
        return new Muusic()
        {
            Id = musicDto.Id ?? Guid.NewGuid(),
            Name = musicDto.Name,
            MB = musicDto.MB,
            AuthorName = musicDto.AuthorName,
            Description = musicDto.Description,
            QuentityLikes = musicDto.QuentityLikes,
        };
    }

    private MusicDto ConvertToEntity(Muusic music)
    {
        return new MusicDto()
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }


    public Guid AddMusic(MusicDto musicDto)
    {
        var music = ConvertToEntity(musicDto);
        var musicRes = _musicRepo.WriteMusic(music);
        return musicRes;
    }

    public void DeleteMusic(Guid id)
    {
        _musicRepo.DeleteMusic(id);
    }

    public List<MusicDto> GetAllMusic()
    {
        var getAllMusics = _musicRepo.ReadAllMusic();
        var musicResult = getAllMusics.Select(mz => ConvertToEntity(mz)).ToList();
        return musicResult;
    }

    public List<MusicDto> GetAllMusicAboveSize(double minSizeMB)
    {
        var musics = GetAllMusic();
        var musicResult = musics.Where(mz => mz.MB > minSizeMB).ToList();
        return musicResult;
    }

    public List<MusicDto> GetAllMusicBelowSize(double maxSizeMB)
    {
        var musics = GetAllMusic();
        var musicResult = musics.Where(mz => mz.MB < maxSizeMB).ToList();
        return musicResult;
    }

    public List<MusicDto> GetAllMusicByAuthorName(string authorName)
    {
        var musics = GetAllMusic();
        var musicResult = musics.Where(mz => mz.AuthorName.ToLower() == authorName.ToLower()).ToList();
        return musicResult;
    }

    public List<string> GetAllUniqueAuthors()
    {
        var musics = GetAllMusic();

        var names = new List<string>();

        foreach (var music in musics)
        {
            var count = musics.Count(mz => mz.AuthorName == music.AuthorName);

            if (count == 1) names.Add(music.AuthorName);
        }

        return names;
    }

    public List<MusicDto> GetLowMostLikedMusic(int count)
    {
        int counter = 0;

        var musics = GetAllMusic();

        var maxLikedMusic = musics.Max(mz => mz.QuentityLikes);

        //var musicResults = musics.Where(mz => mz.QuentityLikes > maxLikedMusic - 10 || mz.QuentityLikes < maxLikedMusic + 10).ToList();

        var musicResults = musics.OrderBy(mz => mz.QuentityLikes).ThenBy(mz => mz.Name).Take(count).ToList();

        return musicResults;
    }

    public MusicDto GetMostLikedMusic()
    {
        var musics = GetAllMusic();
        var maxLikedMusic = musics.Max(mz => mz.QuentityLikes);
        var result = musics.FirstOrDefault(mz => mz.QuentityLikes == maxLikedMusic);

        if (result == null)
        {
            throw new Exception("No any music");
        }

        return result;
    }

    public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
    {
        var musics = GetAllMusic();
        var musicsResult = musics.Where(mz => mz.Description.Contains(keyword)).ToList();
        return musicsResult;
    }

    public MusicDto GetMusicByName(string name)
    {
        var musics = GetAllMusic();
        var musicResult = musics.FirstOrDefault(mz => mz.Name == name);

        if (musicResult == null)
        {
            throw new Exception($"No any kind of music with this {musicResult} name");
        }

        return musicResult;
    }

    public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        var musics = GetAllMusic();
        var musicResult = musics.Where(mz => mz.QuentityLikes < maxLikes && mz.QuentityLikes > minLikes).ToList();
        return musicResult;
    }

    public List<MusicDto> GetTopMostLikedMusic(int count)
    {
        var musics = GetAllMusic();
        var musicResult = musics.OrderByDescending(mz => mz.QuentityLikes).ThenBy(mz => mz.Name).Take(count).ToList();
        return musicResult;
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        var musics = GetAllMusic();
        var musicsSizeWithTheSameAuthor = musics.Where(mz => mz.AuthorName == authorName).Sum(mz => mz.MB);
        return musicsSizeWithTheSameAuthor;
    }

    public void UpdateMusic(MusicDto musicDto)
    {
        _musicRepo.UpdateMusic(ConvertToEntity(musicDto));
    }

    public MusicDto GetMusicById(Guid id)
    {
        var musics = GetAllMusic();
        var musicById = musics.FirstOrDefault(mz => mz.Id == id);

        if (musicById == null)
        {
            throw new Exception("No any music with this ID");
        }

        return musicById;
    }
}
