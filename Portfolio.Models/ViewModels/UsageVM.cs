using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models.ViewModels
{
    public class UsageVM
    {
     
        public IEnumerable<Usage> Usages {  get; set; }

    }
    public class Usage
    {
        public string Guest { get; set; }
        public DateTime DateTime {  get; set; } // keep for printout!
        public string Date {  get; set; }
        public string Time {  get; set; }
        public GuestAction GuestAction { get; set; }
        public string Project { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
    }
}
