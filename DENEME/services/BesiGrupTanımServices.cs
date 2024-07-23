using DENEME.Models;
using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt
{
    public class BesiGrupTanımServices
    {
        private readonly string _connectionString;

        public BesiGrupTanımServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }
        public List<BesiGrup> GetList()
        {
            List<BesiGrup> BesiGruplist = new List<BesiGrup>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT003", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BesiGrup h = new BesiGrup();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.BESIGRUP = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.ACIKLAMA = null; }
                            else { h.ACIKLAMA = reader.GetString(2); }

                            BesiGruplist.Add(h);

                        }
                    }
                }
            }
            return BesiGruplist;
        }
        public BesiGrup GetBesiGrupById(int id)
        {
            BesiGrup h = new BesiGrup();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT003 where BESIGRUP=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            h.SIRKETNO = reader.GetInt32(0);
                            h.BESIGRUP = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.ACIKLAMA = null; }
                            else { h.ACIKLAMA = reader.GetString(2); }

               

                        }
                    }
                }
            }
            return h;
        }

        public void BesiGrupEkle(BesiGrup h)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            int besigrup = GetList().Max(o => o.BESIGRUP) + 1;
            command.CommandText = $"INSERT INTO CFKTT003 (SIRKETNO,BESIGRUP,ACIKLAMA) VALUES(1,{besigrup},'{h.ACIKLAMA}')";
            command.ExecuteNonQuery();
        }




        public void BesiGrupGuncelle(BesiGrup h, int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE CFKTT003 SET ACIKLAMA = '{h.ACIKLAMA}' WHERE BESIGRUP = {id}";
            command.ExecuteNonQuery();
        }

        public void BesiGrupSil(int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM CFKTT003 WHERE BESIGRUP={id}";
            command.ExecuteNonQuery();
        }

        public List<BesiGrup> BesiAra(string searchTerm)
        {
            List<BesiGrup> BesiGruplist = new List<BesiGrup>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("SELECT * FROM CFKTT003 WHERE UPPER(ACIKLAMA) LIKE UPPER(:searchTerm) AND LOWER(ACIKLAMA) LIKE LOWER(:searchTerm)", connection))
                {
                    
                    command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BesiGrup h = new BesiGrup
                            {
                                SIRKETNO = reader.GetInt32(0),
                                BESIGRUP = reader.GetInt32(1),
                                ACIKLAMA = reader.IsDBNull(2) ? null : reader.GetString(2)
                            };

                            BesiGruplist.Add(h);
                        }
                    }
                }
            }

            return BesiGruplist;
        }



    }
}
