using Microsoft.AspNetCore.Mvc;
using Music.Service.DTOs;
using Music.Service.Service;

namespace Muusic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController()
        {
            _musicService = new MusicService();
        }

        [HttpPost("AddMusic")]

        public Guid AddMusic(MusicDto musicDto)
        {
            return _musicService.AddMusic(musicDto);
        }


        [HttpPut("UpdateMusic")]

        public void UpdateMusic(MusicDto musicDto)
        {
            _musicService.UpdateMusic(musicDto);
        }


        [HttpDelete("DeleteMusic/{id}")]

        public void DeleteMusic(Guid id)
        {
            _musicService.DeleteMusic(id);
        }


        [HttpGet("GetAllMusic")]

        public List<MusicDto> GetAllMusic()
        {
            return _musicService.GetAllMusic();
        }


        [HttpGet("GetMusicById/{id}")]

        public MusicDto GetMusicById(Guid id)
        {
            return _musicService.GetMusicById(id);
        }


        [HttpGet("GetAllMusicByAuthorName")]

        public List<MusicDto> GetAllMusicByAuthorName(string name)
        {
            return _musicService.GetAllMusicByAuthorName(name);
        }


        [HttpGet("GetMostLikedMusic")]
        public MusicDto GetMostLikedMusic()
        {
            return _musicService.GetMostLikedMusic();
        }


        [HttpGet("GetMusicByName")]
        public MusicDto GetMusicByName(string name)
        {
            return _musicService.GetMusicByName(name);
        }


        [HttpGet("GetAllMusicAboveSize")]
        public List<MusicDto> GetAllMusicAboveSize(double minSizeMB)
        {
            return _musicService.GetAllMusicAboveSize(minSizeMB);
        }


        [HttpGet("GetAllMusicBelowSize")]
        public List<MusicDto> GetAllMusicBelowSize(double maxSizeMB)
        {
            return _musicService.GetAllMusicBelowSize(maxSizeMB);
        }


        [HttpGet("GetTopMostLikedMusic")]
        public List<MusicDto> GetTopMostLikedMusic(int count)
        {
            return _musicService.GetLowMostLikedMusic(count);
        }


        [HttpGet("GetLowMostLikedMusic")]
        public List<MusicDto> GetLowMostLikedMusic(int count)
        {
            return _musicService.GetLowMostLikedMusic(count);
        }


        [HttpGet("GetMusicByDescriptionKeyword")]
        public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
        {
            return _musicService.GetMusicByDescriptionKeyword(keyword);
        }


        [HttpGet("GetMusicWithLikesInRange")]
        public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
        {
            return _musicService.GetMusicWithLikesInRange(minLikes, maxLikes);
        }


        [HttpGet("GetAllUniqueAuthors")]
        public List<string> GetAllUniqueAuthors()
        {
            return _musicService.GetAllUniqueAuthors();
        }


        [HttpGet("GetTotalMusicSizeByAuthor")]
        public double GetTotalMusicSizeByAuthor(string authorName)
        {
            return _musicService.GetTotalMusicSizeByAuthor(authorName);
        }


    }
}
