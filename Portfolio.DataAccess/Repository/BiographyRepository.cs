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
    internal class BiographyRepository : Repository<Biography>, IBiographyRepository
    {

        private ApplicationDbContext _db;
        public BiographyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Biography biography)
        {
            //project.VideoCount = 0;
            _db.Biographies.Update(biography);
            _db.SaveChanges();
        }
    }
}
