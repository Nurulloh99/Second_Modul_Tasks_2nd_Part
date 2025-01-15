using System.Text.Json;
using Muusic.DataAccess.MusicService;

namespace Muusic.Repository.MusicRepository;

public class MusicRepository : IMusicRepository
{
    private string _path;
    private List<Music> _musics;

    public MusicRepository()
    {
        _musics = new List<Music>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _musics = ReadAllMusics();  
    }

    public void SaveData()
    {
        var fileJson = JsonSerializer.Serialize(_musics);
        File.WriteAllText(_path, fileJson);
    }

    public Guid WriteMusic(Music music)
    {
        _musics.Add(music);
        SaveData();
        return Guid.NewGuid();
    }

    public List<Music> ReadAllMusics()
    {
        var musicResult = File.ReadAllText(_path);
        var musicJson = JsonSerializer.Deserialize<List<Music>>(musicResult);
        return musicJson;
    }

    public Music ReadById(Guid musicId)
    {
        var musicById =  _musics.FirstOrDefault(mz => mz.Id == musicId);

        if(musicById == null)
        {
            throw new Exception("ID EXEPTION BECAUSE OF NULL");
        }

        return musicById;
    }

    public void RemoveMusic(Guid musicId)
    {
        var removingMusic = ReadById(musicId);
        _musics.Remove(removingMusic);
        SaveData();
    }

    public void UpdateMusic(Music music)
    {
        var updatingMusic = ReadById(music.Id);
        var index = _musics.IndexOf(updatingMusic);
        _musics[index] = music;
        SaveData();
    }
}
