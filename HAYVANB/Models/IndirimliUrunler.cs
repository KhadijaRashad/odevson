using System.ComponentModel.DataAnnotations.Schema;

namespace HAYVANB.Models
{
    public class IndirimliUrunler
    {
        public int Id { get; set; }

        public int? UrunId { get; set; }
        [ForeignKey("UrunId")]
        public Urun Urun { get; set; }

        public double Oran { get; set; }

        public DateTime Baslangic { get; set; }

        public DateTime Bitis { get; set; }

        public bool DigerKampanya { get; set; } = true;
    }
}
