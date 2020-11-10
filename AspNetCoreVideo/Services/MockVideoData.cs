using AspNetCoreVideo.Entities;
using AspNetCoreVideo.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreVideo.Services
{
    public class MockVideoData : IVideoData
    {
        private IEnumerable<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>()
            {
                new Video { Id = 1, Title = "Shrek", GenreId = 6 },
                new Video { Id = 2, Title = "Berserker", GenreId = 1 },
                new Video { Id = 3, Title = "Taxi driver", GenreId = 5 },
            };
        }
        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }

        public Video Get(int id)
        {
            return _videos.FirstOrDefault(video => video.Id.Equals(id));
        }
    }
}
