using System.Text.Json;
using Music.DataAccess.Entities;

namespace Music.Repository.Services;

public class MusicRepository : IMusicRepository
{
    private readonly string _filePath;
    private readonly string _directoryPath;

    private List<Muusic> _musics;

    public MusicRepository()
    {
        _musics = new List<Muusic>();

        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "MusicJson");
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }

        _musics = ReadAllMusic();
    }

    public void SaveData()
    {
        var musicJson = JsonSerializer.Serialize(_musics);
        File.WriteAllText(_filePath, musicJson);
    }

    public List<Muusic> ReadAllMusic()
    {
        var getAllMusics = File.ReadAllText(_filePath);
        var musicJson = JsonSerializer.Deserialize<List<Muusic>>(getAllMusics);
        return musicJson;
    }

    public Guid WriteMusic(Muusic music)
    {
        _musics.Add(music);
        SaveData();
        return music.Id;
    }

    public void DeleteMusic(Guid musicId)
    {
        var findMusic = ReadMusicById(musicId);
        _musics.Remove(findMusic);
        SaveData();
    }

    public Muusic ReadMusicById(Guid musicId)
    {
        var musicById = _musics.FirstOrDefault(mz => mz.Id == musicId);

        if (musicById == null)
        {
            throw new Exception("No any music by this ID!");
        }

        return musicById;
    }

    public void UpdateMusic(Muusic music)
    {
        var findMusic = ReadMusicById(music.Id);
        var index = _musics.IndexOf(findMusic);
        _musics[index] = music;
        SaveData();
    }
}
