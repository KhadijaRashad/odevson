namespace HAYVANB.Models
{
    public class Kampanya
    {
        public int Id { get; set; }

        public string Ad { get; set; }  //IND25, KARGO

        public DateTime Baslangic { get; set; } //23.11

        public DateTime Bitis { get; set; }//25.11

        public double IndirimOran { get; set; }//100

        public double MinimumDeger { get; set; }//5
    }
}
