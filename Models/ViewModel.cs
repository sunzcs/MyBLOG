    namespace myblog.Models.ViewModel
    {
    public class ViewModel
    {
        public Me? Me { get; set; } = new();
        public Education? Education { get; set; } = new();
        public List<Skills>? Skills { get; set; } = new List<Skills>();
        public Text? Text { get; set; } = new();
        public List<Lang>? Lang { get; set; } = new();
        public List<Img>? Imgs { get; set; } = new();
        public List<Link>? Links { get; set; } = new();
        


        }


    }