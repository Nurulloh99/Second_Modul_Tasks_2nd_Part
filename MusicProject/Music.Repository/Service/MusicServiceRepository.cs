using System.Text.Json;
using Music.DataAccess.Entities;

namespace Music.Repository.Service;

public class MusicServiceRepository : IMusicServiceRepository
{
    private string _path;
    private List<MusicProps> _musics;

    public MusicServiceRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Musics.json");
        _musics = new List<MusicProps>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _musics = ReadAllMusics();
    }

    public void SaveData()
    {
        var musicJson = JsonSerializer.Serialize(_musics);
        File.WriteAllText(_path, musicJson);
    }

    public List<MusicProps> ReadAllMusics()
    {
        var musicResult = File.ReadAllText(_path);
        var musicJson = JsonSerializer.Deserialize<List<MusicProps>>(musicResult);
        return musicJson;
    }

    public MusicProps ReadMusicById(Guid musicId)
    {
        var musicById = _musics.FirstOrDefault(music => music.Id == musicId);
        return musicById;
    }

    public void RemoveMusic(Guid musicId)
    {
        var findMusic = ReadMusicById(musicId);
        _musics.Remove(findMusic);
        SaveData();
    }

    public void UpdateMusic(MusicProps music)
    {
        var findMusic = ReadMusicById(music.Id);
        var index = _musics.IndexOf(findMusic);
        _musics[index] = music;
        SaveData();
    }

    public Guid WriteMusic(MusicProps music)
    {
        _musics.Add(music);
        SaveData();
        return music.Id;
    }
}
