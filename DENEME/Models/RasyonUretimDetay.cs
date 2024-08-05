namespace MoluEt.Models
{
    public class RasyonUretimDetay
    {
        public int SIRKETNO { get; set; }
        public int CIFTLIKNO { get; set; }
        public int URETIMNO { get; set; }
        public int SIRANO { get; set; }
        public int? URUNNO { get; set; }
        public decimal? MIKTAR { get; set; }
        public string? INP_USER { get; set; }
        public DateTime? INP_DATE { get; set; }
        public string? UPD_USER { get; set; }
        public DateTime? UPD_DATE { get; set; }
        public int? GIRSNO { get; set; }
        public int? CIRSNO { get; set; }
        public DateTime? TARIH { get; set; }
        public string? CIFTLIKADI { get; set; }
        public string? URUNADI { get; set; }

        public string? ACIKLAMA { get; set; }
        public RasyonUretim rasyonUretim { get; set; }
    }
}
