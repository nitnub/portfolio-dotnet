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
    internal class BiographyRepository(ApplicationDbContext db) : Repository<Biography>(db), IBiographyRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(Biography biography)
        {
            _db.Biographies.Update(biography);
            _db.SaveChanges();
        }
    }
}
