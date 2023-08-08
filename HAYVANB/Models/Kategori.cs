using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HAYVANB.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kategori Adı")]
        public string Ad { get; set; }
    }
}
