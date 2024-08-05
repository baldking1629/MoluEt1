using System.Security.Principal;

namespace MoluEt.Models
{
    public class RasyonUretim
    {
        public int SIRKETNO { get; set; }
        public int CIFTLIKNO { get; set; }
        public int URETIMNO { get; set; }
        public DateTime? TARIH { get; set; }
        public string? ACIKLAMA { get; set; }
        public string? INP_USER { get; set; }
        public DateTime? INP_DATE { get; set; }
        public string? UPD_USER { get; set; }
        public DateTime? UPD_DATE { get; set; }
        public string? CIFTLIKADI { get; set; }
       


    }
}
