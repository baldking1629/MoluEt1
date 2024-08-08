using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class HayvanDataServices
    {
        private readonly string _connectionString;
        public HayvanDataServices()
        {
            _connectionString = ("Data Source=192.168.1.5:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }

        public List<Hayvan> GetList()
        {
            List<Hayvan> hayvanList = new List<Hayvan>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("Select SIRKETNO,CIFTLIKNO,KUPE_NO,ACIKLAMA,BESIGRUP,TIPI,NEVI,IRK from CFKMT002", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hayvan h = new Hayvan();
                            if (reader.IsDBNull(0)) { h.SIRKETNO = null; }
                            else { h.SIRKETNO = reader.GetInt32(0); }

                            if (reader.IsDBNull(1)) { h.CIFTLIKNO = null; }
                            else { h.CIFTLIKNO = reader.GetInt32(1); }

                            if (reader.IsDBNull(2)) { h.KUPE_NO = null; }
                            else { h.KUPE_NO = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { h.ACIKLAMA = null; }
                            else { h.ACIKLAMA = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { h.BESIGRUP = null; }
                            else { h.BESIGRUP = reader.GetInt32(4); }

                            if (reader.IsDBNull(5)) { h.TIPI = null; }
                            else { h.TIPI = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { h.NEVI = null; }
                            else { h.NEVI = reader.GetInt32(6); }

                            if (reader.IsDBNull(7)) { h.IRK = null; }
                            else { h.IRK = reader.GetInt32(7); }

                            
                            using (OracleCommand command1 = new OracleCommand("Select CIFTLIKADI from CFKMT001 where CIFTLIKNO=" + h.CIFTLIKNO, connection))
                            {
                                using (OracleDataReader reader1 = command1.ExecuteReader())
                                {
                                    while (reader1.Read())
                                    {
                                        if (reader1.IsDBNull(0)) { h.CIFTLIKADI = null; }
                                        else { h.CIFTLIKADI = reader1.GetString(0); }
                                    }
                                }
                            }
                            if (h.BESIGRUP != null)
                            {
                                using (OracleCommand command2 = new OracleCommand("SELECT ACIKLAMA FROM CFKTT003 WHERE BESIGRUP =" + h.BESIGRUP, connection))
                                {
                                    using (OracleDataReader reader2 = command2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            if (reader2.IsDBNull(0)) { h.BESIGRUPACIKLAMA = null; }
                                            else { h.BESIGRUPACIKLAMA = reader2.GetString(0); }
                                        
                                        }
                                    }
                                }
                            }
                            hayvanList.Add(h);
                        }
                    }
                }
            }
            return hayvanList;
        }

        public Hayvan GetHayvanById()
        {
            Hayvan h = new Hayvan();
            //buraya plsql komutları gelecek
            return h;
        }
    }
}
