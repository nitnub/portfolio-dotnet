using Portfolio.DataAccess.Data;
using Portfolio.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IProjectRepository Project { get; set; }
        public IVideoRepository Video { get; set; }
        public IBiographyRepository Biography { get; set; }
        public ILogoRepository Logo { get; set; }
        public IProjectLogoRepository ProjectLogo { get; set; }
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Project = new ProjectRepository(_db);
            Video = new VideoRepository(_db);
            Biography = new BiographyRepository(_db);
            Logo = new LogoRepository(_db);
            ProjectLogo = new ProjectLogoRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
