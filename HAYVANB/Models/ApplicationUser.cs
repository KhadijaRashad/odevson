using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HAYVANB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public string Adres { get; set; }

        public string Sehir { get; set; }
        [NotMapped]
        public string AdSoyad
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }
    }
}

