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
    internal class ProjectRepository(ApplicationDbContext db) : Repository<Project>(db), IProjectRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(Project project)
        {
            _db.Projects.Update(project);
            _db.SaveChanges();
        }
    }
}
