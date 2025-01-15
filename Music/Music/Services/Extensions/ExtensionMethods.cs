using Music.Services.DTOs;

namespace Music.Services.Extensions;

public static class ExtensionMethods
{
    public static int GetTotalLikesOfMusics(this List<BaseMusicDto> musics)
    {
        var musicSize = 0;

        foreach (var music in musics)
        {
            musicSize += music.QuentityLikes;
        }

        return musicSize;
    }


    public static double MBtoGB(this BaseMusicDto music)
    {
        var musicSize = music.MB * 1024;
        return musicSize;
    }
}
