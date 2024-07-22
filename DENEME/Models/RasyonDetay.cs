using System.Security.Principal;

namespace MoluEt.Models
{
    public class RasyonDetay
    {
        public int SIRKETNO { get; set; }
        public int CIFTLIKNO { get; set; }
        public int URUNNO { get; set; }
        public int SIRANO { get; set; }
        public int? EMTIANO { get; set; }
        public decimal? MIKTAR { get; set; }
        public decimal? FIYAT { get; set; }
        public string? INP_USER { get; set; }
        public string? INP_DATE { get; set; }
        public string? UDP_USER { get; set; }
        public string? UDP_DATE { get; set; }
        public string? URUNADI { get; set; }
        public string? EMTIAADI { get; set; }
        public string? CIFTLIKADI { get; set; }

        public decimal? BRMMIKTAR { get; set; }
        public string? ACIKLAMA { get; set; }
    }
}
