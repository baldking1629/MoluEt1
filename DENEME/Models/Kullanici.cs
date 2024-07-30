using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.DirectoryServices.Protocols;

namespace MoluEt.Models
{
    public class Kullanici
    {
        public int SIRKETNO { get; set; }
        public int KULNO { get; set; }
        public int? KULBORDNO { get; set; }
        public string KULAD { get; set; }
        public string KULSOYAD { get; set; }
        public string? SIFRE { get; set; }
        public string? INP_USER { get; set; }
        public string? INP_DATE { get; set; }
        public string? UDP_USER { get; set; }
        public string? UDP_DATE { get; set; }
        public int? FRMGRPNO { get; set; }
        public string? JAVAHOME { get; set; }
        public string? MAILSIFRE { get; set; }
        public string? MAILKULAD { get; set; }
        public string? EFATPATH { get; set; }
    }
}
