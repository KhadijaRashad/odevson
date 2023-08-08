using System.ComponentModel.DataAnnotations.Schema;

namespace HAYVANB.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        public string MusteriId { get; set; }
        [ForeignKey("MusteriId")]
        public ApplicationUser ApplicationUser { get; set; }

        public double ToplamUcret { get; set; }

        public double Indirim { get; set; }

        public double KargoUcret { get; set; }

        public string KargoFirma { get; set; }

        public DateTime SiparisTarihi { get; set; }

        public DateTime GondermeTarihi { get; set; }

        public DateTime TeslimTarihi { get; set; }

        public DateTime IadeTarihi { get; set; }

        public SiparisDurumu SiparisDurumu { get; set; }

        public OdemeDurumu OdemeDurumu { get; set; }

        public string SiparisKodu { get; set; }

        public string Aciklama { get; set; }

    }

    public enum SiparisDurumu
    {
        Hazirlaniyor,
        KargoyaVerildi,
        TeslimEdildi,
        IadeEdildi
    }

    public enum OdemeDurumu
    {
        KrediKarti,
        Eft,
        Havale,
        KapidaOdeme,
        Onaylanmadi
    }
}