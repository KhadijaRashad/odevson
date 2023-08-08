using System.ComponentModel.DataAnnotations.Schema;

namespace HAYVANB.Models
{
    public class Foto
    {
        public int Id { get; set; }

        public string FotoAd { get; set; }

        public int? UrunId { get; set; }
        [ForeignKey("UrunId")]
        public Urun Urun { get; set; }
    }
}
