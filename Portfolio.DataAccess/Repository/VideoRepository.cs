using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Repository
{
    internal class VideoRepository : Repository<Video>, IVideoRepository
    {

        private ApplicationDbContext _db;
        public VideoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Video video)
        {
            //project.VideoCount = 0;
            _db.Videos.Update(video);
            _db.SaveChanges();
        }
    }
}
