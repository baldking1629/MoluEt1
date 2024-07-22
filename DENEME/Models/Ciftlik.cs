using Oracle.ManagedDataAccess.Types;
using System.Security.Principal;

namespace MoluEt.Models
{
    public class Ciftlik
    {
        public int SIRKETNO { get; set; }
        public int CIFTLIKNO { get; set; }
        public string? CIFTLIKADI { get; set; }
        public string? ADRES { get; set; }
        public string? ILCE { get; set; }
        public string? IL { get; set; }
        public string? TELEFON { get; set; }
        public string? FAX { get; set; }
        public string? E_MAIL { get; set; }
        public string? VERGI_DAIRESI { get; set; }
        public string? VERGI_NO { get; set; }
        public string? RESIM { get; set; }
        public int? DEPONO { get; set; }
        public string? RUHSATNO { get; set; }
        public string? ISLETMENO { get; set; }
        public string? ISLETMEONAYNO { get; set; }
        public string? INP_USER { get; set; }
        public string? INP_DATE { get; set; }
        public string? UDP_USER { get; set; }
        public string? UDP_DATE { get; set; }


    }
}
