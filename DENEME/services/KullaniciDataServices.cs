using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class KullaniciDataServices
    {
        private readonly string _connectionString;
        public KullaniciDataServices()
        {
            _connectionString = ("Data Source=192.168.1.5:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }

        public List<Kullanici> GetList()
        {
            List<Kullanici> kullanicilist = new List<Kullanici>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select SIRKETNO,KULAD,SIFRE from TANTT050", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kullanici k = new Kullanici();

                            k.SIRKETNO = reader.GetInt32(0);
                            k.KULAD = reader.GetString(1);

                            if (reader.IsDBNull(2)) { k.SIFRE = null; }
                            else { k.SIFRE = reader.GetString(2); }
                            
                            kullanicilist.Add(k);

                        }
                    }
                }
            }
            return kullanicilist;
        }
    }
}
