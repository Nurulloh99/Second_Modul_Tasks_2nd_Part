using Music.DataAccess.Entities;
using Music.Repositories;
using Music.Services.DTOs;

namespace Music.Services;

public class MusicService : IMusicService
{
    public IMusicRepository musicRepo;

    public MusicService()
    {
        musicRepo = new MusicRepository();
    }

    public BaseMusicDto AddMusic(MusicGetDto music)
    {
        ValidateMusicCreateDto(music);
        var newMusic = ConvertMusic(music);
        newMusic.Id = Guid.NewGuid();
        musicRepo.WriteMusic(newMusic);
        return ConvertMusic(newMusic);
    }

    public void DeleteMusic(Guid musicId)
    {
        musicRepo.RemoveMusic(musicId);
    }

    public List<BaseMusicDto> GetAllMusicsAboveSize(double minSize)
    {
        var musicsWithBigSize = new List<BaseMusicDto>();

        foreach (var music in GetAllMusics())
        {
            if (music.MB > minSize)
            {
                musicsWithBigSize.Add(music);
            }
        }

        return musicsWithBigSize;
    }

    public List<BaseMusicDto> GetAllMusicBeloveSize(double minSize)
    {
        var musicsWithBigSize = new List<BaseMusicDto>();

        foreach (var music in GetAllMusics())
        {
            if (music.MB < minSize)
            {
                musicsWithBigSize.Add(music);
            }
        }

        return musicsWithBigSize;
    }

    public List<BaseMusicDto> GetAllMusicsByAuthorName(string name)
    {
        var allMusics = new List<BaseMusicDto>();

        foreach (var music in GetAllMusics())
        {
            if (music.AuthorName == name)
            {
                allMusics.Add(music);
            }
        }

        return allMusics;
    }

    public List<BaseMusicDto> GetAllMusics()
    {
        var getAllMusics = musicRepo.ReadAllMusics();
        var allMusics = new List<BaseMusicDto>();

        foreach (var music in getAllMusics)
        {
            allMusics.Add(ConvertMusic(music));
        }

        return allMusics;
    }

    public List<string> GetAllUniqueAuthors()
    {
        var authors = new List<string>();
        var like = new BaseMusicDto();

        foreach (var music in GetAllMusics())
        {
            if (music.QuentityLikes > like.QuentityLikes)
            {
                authors.Add(music.AuthorName);
            }
        }

        return authors;
    }

    public BaseMusicDto GetMostLikedMusic()
    {
        var likedMusic = new BaseMusicDto();

        foreach (var music in GetAllMusics())
        {
            if (music.QuentityLikes > likedMusic.QuentityLikes)
            {
                likedMusic = music;
            }
        }

        return likedMusic;
    }

    public BaseMusicDto GetMudsicById(Guid musicId)
    {
        var music = musicRepo.ReadMusicById(musicId);
        return ConvertMusic(music);
    }




    public List<BaseMusicDto> GetMusicByDescriptionKeyword(string keyword)
    {
        var musics = new List<BaseMusicDto>();

        foreach (var music in GetAllMusics())
        {
            if (music.Description.Contains(keyword))
            {
                musics.Add(music);
            }
        }

        return musics;
    }

    public BaseMusicDto GetMusicByName(string name)
    {
        var musicName = new BaseMusicDto();

        foreach (var music in GetAllMusics())
        {
            if (object.Equals(music.Name, name))
            {
                musicName = music;
            }
        }

        return musicName;
    }

    public List<BaseMusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        var musicLikes = new List<BaseMusicDto>();

        foreach (var music in GetAllMusics())
        {
            if (music.QuentityLikes < maxLikes && music.QuentityLikes > minLikes)
            {
                musicLikes.Add(music);
            }
        }

        return musicLikes;
    }

    //public List<BaseMusicDto> GetTopMostLikedMusic(int count)
    //{
    //    var maxLikedMusic = new BaseMusicDto();
    //    var mostLikesMusics = new List<BaseMusicDto>();

    //    foreach (var music in GetAllMusics())
    //    {
    //        if (music.QuentityLikes > maxLikedMusic.QuentityLikes)
    //        {
    //            maxLikedMusic = music;
    //        }
    //    }

    //    foreach (var music in GetAllMusics())
    //    {
    //        if (maxLikedMusic.QuentityLikes == music.QuentityLikes)
    //        {
    //            mostLikesMusics.Add(music);
    //        }
    //        if(mostLikesMusics.Count == count)
    //        {
    //            return mostLikesMusics;
    //        }

    //    }

    //    return mostLikesMusics;
    //}

    public List<BaseMusicDto> GetTopMostLikedMusic(int count)
    {
        var maxLike = new BaseMusicDto();
        var mostLikedMusics = new List<BaseMusicDto>();

        foreach(var music in GetAllMusics())
        {
            if(music.QuentityLikes > maxLike.QuentityLikes)
            {
                maxLike = music;
            }
        }

        foreach (var music in GetAllMusics())
        {
            if(music.QuentityLikes == maxLike.QuentityLikes)
            {
                mostLikedMusics.Add(music);
            }

            if (mostLikedMusics.Count == count)
            {
                return mostLikedMusics;
            }
        }

        return mostLikedMusics;
    }



    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        var totalMusicSize = 0d;

        foreach (var music in GetAllMusics())
        {
            if (music.AuthorName == authorName)
            {
                totalMusicSize += music.MB;
            }
        }

        return totalMusicSize;
    }

    public void UpdateMusic(MusicGetDto music)
    {
        musicRepo.UpdateMusic(ConvertMusic(music));
    }

    private void ValidateMusicCreateDto(MusicGetDto musicDto)
    {
        if (string.IsNullOrEmpty(musicDto.Name) || musicDto.Name.Length > 20)
        {
            throw new Exception("MusicName Error!");
        }

        if (musicDto.MB < 2 || musicDto.MB > 20)
        {
            throw new Exception("MusicMemory Error!");
        }

        if (string.IsNullOrEmpty(musicDto.AuthorName) || musicDto.AuthorName.Length > 50)
        {
            throw new Exception("AuthorName Error!");
        }

        if (string.IsNullOrEmpty(musicDto.Description) || musicDto.Description.Length > 400)
        {
            throw new Exception("Description Error!");
        }

        if (musicDto.QuentityLikes < 1)
        {
            throw new Exception("QuentityLikes Error");
        }
    }

    private Mussic ConvertMusic(MusicGetDto music)
    {
        return new Mussic
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }

    private BaseMusicDto ConvertMusic(Mussic music)
    {
        return new BaseMusicDto
        {
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }
}
