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
    public class ProjectLogoRepository(ApplicationDbContext db) : Repository<ProjectLogo>(db), IProjectLogoRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(ProjectLogo projectLogo)
        {
            _db.ProjectLogos.Update(projectLogo);
            _db.SaveChanges();
        }
    }
}
