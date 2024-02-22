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
    public class LogoRepository : Repository<Logo>, ILogoRepository
    {

        private ApplicationDbContext _db;
        public LogoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Logo logo)
        {
            _db.Logos.Update(logo);
            _db.SaveChanges();
        }
    }
}
