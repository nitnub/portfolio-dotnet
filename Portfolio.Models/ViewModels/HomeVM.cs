using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models.ViewModels
{
    public class HomeVM
    {
        public Biography Biography { get; set; }
        public List<Project> Projects { get; set; }
    }
}
