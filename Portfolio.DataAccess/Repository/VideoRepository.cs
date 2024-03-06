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
    internal class VideoRepository(ApplicationDbContext db) : Repository<Video>(db), IVideoRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(Video video)
        {
            _db.Videos.Update(video);
            _db.SaveChanges();
        }
    }
}
