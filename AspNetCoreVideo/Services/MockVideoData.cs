using AspNetCoreVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVideo.Services
{
    public class MockVideoData : IVideoData
    {
        private IEnumerable<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>()
            {
                new Video { Id = 1, Title = "Shrek" },
                new Video { Id = 2, Title = "Berserker" },
                new Video { Id = 3, Title = "Taxi driver" },
            };
        }
        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }
    }
}
