using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace myblog.Models
{
    public class Lang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LangId { get; set; }
        public string? LangName { get; set; }
        public string? LangLevel { get; set; }


    }
}