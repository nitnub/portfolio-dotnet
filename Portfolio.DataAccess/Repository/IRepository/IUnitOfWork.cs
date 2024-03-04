using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProjectRepository Project {  get; }
        IVideoRepository Video { get; }
        IBiographyRepository Biography { get; }
        ILogoRepository Logo { get; }
        IProjectLogoRepository ProjectLogo { get; }
        IGuestActionRepository GuestAction { get; }
        void Save();
    }
}
