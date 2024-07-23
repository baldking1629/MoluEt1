using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class HayvanNeviDataServices
    {
        private readonly string _connectionString;

        public HayvanNeviDataServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }

        public List<HayvanNevi> GetList()
        {
            List<HayvanNevi> hayvanlist = new List<HayvanNevi>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT020", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HayvanNevi h = new HayvanNevi();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.NEVI_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.NEVI_ADI = null; }
                            else { h.NEVI_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { h.BESI_GURUBU = null; }
                            else { h.BESI_GURUBU = reader.GetInt32(3); }

                            if (reader.IsDBNull(4)) { h.ACIKLAMA = null; }
                            else { h.ACIKLAMA = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { h.INP_USER = null; }
                            else { h.INP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { h.INP_DATE = null; }
                            else { h.INP_DATE = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { h.UDP_USER = null; }
                            else { h.UDP_USER = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { h.UDP_DATE = null; }
                            else { h.UDP_DATE = reader.GetString(8); }
                            hayvanlist.Add(h);
                        }
                    }
                }
            }
            return hayvanlist;
        }

        public HayvanNevi GetHayvanNeviById(int id)
        {
            HayvanNevi h = new HayvanNevi();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT020 where NEVI_NO=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            h.SIRKETNO = reader.GetInt32(0);
                            h.NEVI_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.NEVI_ADI = null; }
                            else { h.NEVI_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { h.BESI_GURUBU = null; }
                            else { h.BESI_GURUBU = reader.GetInt32(3); }

                            if (reader.IsDBNull(4)) { h.ACIKLAMA = null; }
                            else { h.ACIKLAMA = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { h.INP_USER = null; }
                            else { h.INP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { h.INP_DATE = null; }
                            else { h.INP_DATE = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { h.UDP_USER = null; }
                            else { h.UDP_USER = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { h.UDP_DATE = null; }
                            else { h.UDP_DATE = reader.GetString(8); }
                        }
                    }
                }
            }
            return h;
        }

        public void HayvanNeviEkle(HayvanNevi h)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            int nevino = GetList().Max(o => o.NEVI_NO) + 1;
            command.CommandText = $"INSERT INTO CFKTT020 (SIRKETNO,NEVI_NO,NEVI_ADI,ACIKLAMA) VALUES(1,{nevino},'{h.NEVI_ADI}','{h.ACIKLAMA}')";
            command.ExecuteNonQuery();
        }

        public void HayvanNeviGuncelle(HayvanNevi h, int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE CFKTT020 SET NEVI_ADI = '{h.NEVI_ADI}', ACIKLAMA = '{h.ACIKLAMA}' where NEVI_NO={id}";
            command.ExecuteNonQuery();
        }

        public void HayvanNeviSil(int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM CFKTT020 WHERE NEVI_NO={id}";
            command.ExecuteNonQuery();
        }

        public List<HayvanNevi> HayvanNeviAra(string searchTerm)
        {
            List<HayvanNevi> hayvanlist = new List<HayvanNevi>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT020 WHERE UPPER(NEVI_ADI) LIKE UPPER(:searchTerm) AND LOWER(NEVI_ADI) LIKE LOWER(:searchTerm)", connection))
                {
                    command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HayvanNevi h = new HayvanNevi();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.NEVI_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.NEVI_ADI = null; }
                            else { h.NEVI_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { h.BESI_GURUBU = null; }
                            else { h.BESI_GURUBU = reader.GetInt32(3); }

                            if (reader.IsDBNull(4)) { h.ACIKLAMA = null; }
                            else { h.ACIKLAMA = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { h.INP_USER = null; }
                            else { h.INP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { h.INP_DATE = null; }
                            else { h.INP_DATE = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { h.UDP_USER = null; }
                            else { h.UDP_USER = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { h.UDP_DATE = null; }
                            else { h.UDP_DATE = reader.GetString(8); }
                            hayvanlist.Add(h);
                        }
                    }
                }
            }
            return hayvanlist;
        }
    }
}
