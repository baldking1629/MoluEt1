using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt
{
    public class IrKTanımServices
    {
        private readonly string _connectionString;

        public IrKTanımServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }
        public List<IrkTanım> GetList()
        {
            List<IrkTanım> Irklist = new List<IrkTanım>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT005", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IrkTanım h = new IrkTanım();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.IRK_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.IRK_ADI = null; }
                            else { h.IRK_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { h.ULKE_ADI = null; }
                            else { h.ULKE_ADI = reader.GetString(3); }

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
                            Irklist.Add(h);

                        }
                    }
                }
            }
            return Irklist;
        }
        public IrkTanım GetIrkTanımById(int id)
        {
            IrkTanım h = new IrkTanım();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT005 where IRK_NO=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            h.SIRKETNO = reader.GetInt32(0);
                            h.IRK_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.IRK_ADI = null; }
                            else { h.IRK_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { h.ULKE_ADI = null; }
                            else { h.ULKE_ADI = reader.GetString(3); }

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

        public void IrkEkle(IrkTanım h)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            int irkno = GetList().Max(o => o.IRK_NO) + 1;
            command.CommandText = $"INSERT INTO CFKTT005 (SIRKETNO,IRK_NO,IRK_ADI,ULKE_ADI,ACIKLAMA) VALUES(1,{irkno},'{h.IRK_ADI}','{h.ULKE_ADI}','{h.ACIKLAMA}')";
            command.ExecuteNonQuery();
        }
        public void IrkGuncelle(IrkTanım h, int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE CFKTT005 SET IRK_ADI = '{h.IRK_ADI}', ULKE_ADI = '{h.ULKE_ADI}', ACIKLAMA = '{h.ACIKLAMA}' WHERE IRK_NO = {id}";
            command.ExecuteNonQuery(); 
        }

        public void IrkSil(int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM CFKTT005 WHERE IRK_NO={id}";
            command.ExecuteNonQuery();
        }


        public List<IrkTanım> IrkAra(string searchTerm)
        {
            List<IrkTanım> Irklist = new List<IrkTanım>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT * FROM CFKTT005 WHERE UPPER(IRK_ADI) LIKE UPPER(:searchTerm) AND LOWER(IRK_ADI) LIKE LOWER(:searchTerm)", connection))
                {
                    command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IrkTanım h = new IrkTanım();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.IRK_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { h.IRK_ADI = null; }
                            else { h.IRK_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { h.ULKE_ADI = null; }
                            else { h.ULKE_ADI = reader.GetString(3); }

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
                            Irklist.Add(h);
                        }
                    }
                }
            }
            return Irklist;
        }

    }
}

