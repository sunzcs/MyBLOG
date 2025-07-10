using System.Collections.Generic;
using myblog.Models;

namespace myblog.Models.ViewModel
{
    public class ViewModel
    {
        public List<User> User { get; set; }
        public List<Education> Education { get; set; }
        public List<SLang> SLang { get; set; }
        public List<Lang> Lang { get; set; }
        public List<Skills> Skills { get; set; }
        

    }
}
