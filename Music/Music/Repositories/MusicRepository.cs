using System.Text.Json;
using Music.DataAccess.Entities;

namespace Music.Repositories;

public class MusicRepository : IMusicRepository
{
    public string _path = "../../../DataAccess/Data/Musics.json";
    private List<Mussic> _musics;

    public MusicRepository()
    {
        _musics = new List<Mussic>();

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

    public List<Mussic> ReadAllMusics()
    {
        var musicReasult = File.ReadAllText(_path);
        var musicJson = JsonSerializer.Deserialize<List<Mussic>>(musicReasult);
        return musicJson;
    }

    public Mussic ReadMusicById(Guid musicId)
    {
        foreach (var music in _musics)
        {
            if (music.Id == musicId)
            {
                return music;
            }
        }

        return null;
    }

    public void RemoveMusic(Guid musicId)
    {
        var removingMusic = ReadMusicById(musicId);
        _musics.Remove(removingMusic);
        SaveData();
    }

    public void UpdateMusic(Mussic music)
    {
        var updatingMusic = ReadMusicById(music.Id);
        var index = _musics.IndexOf(updatingMusic);
        _musics[index] = music;
        SaveData();
    }

    public Guid WriteMusic(Mussic music)
    {
        _musics.Add(music);
        SaveData();
        return music.Id;
    }
}
