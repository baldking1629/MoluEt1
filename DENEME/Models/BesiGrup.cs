using Oracle.ManagedDataAccess.Types;
using System.ComponentModel.DataAnnotations;

namespace DENEME.Models
{
    public class BesiGrup
    {
        public int SIRKETNO { get; set; }
        public int BESIGRUP { get; set; }

        public string? ACIKLAMA { get; set; }

        public string? INP_USER { get; set; }
        public string? INP_DATE { get; set; }
        public string? UDP_USER { get; set; }
        public string? UDP_DATE { get; set; }

        public List<int> GrupNumaralari { get; set; }



    }
}
