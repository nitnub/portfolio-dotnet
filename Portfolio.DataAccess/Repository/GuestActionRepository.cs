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
    internal class GuestActionRepository : Repository<GuestAction>, IGuestActionRepository
    {

        private ApplicationDbContext _db;
        public GuestActionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GuestAction guestAction)
        {
            _db.GuestActions.Update(guestAction);
            _db.SaveChanges();
        }
    }
}
