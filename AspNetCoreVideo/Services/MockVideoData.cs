using AspNetCoreVideo.Entities;
using AspNetCoreVideo.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreVideo.Services
{
    public class MockVideoData : IVideoData
    {
        private List<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>()
            {
                new Video { Id = 1, Title = "Shrek", Genre = Genres.Fantasy },
                new Video { Id = 2, Title = "Berserker", Genre = Genres.Action },
                new Video { Id = 3, Title = "Taxi driver", Genre = Genres.Drama },
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

        public void Add(Video newVideo)
        {
            newVideo.Id = _videos.Max(v => v.Id) + 1;
            _videos.Add(newVideo);
        }
    }
}
