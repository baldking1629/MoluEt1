using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class AsiDataServices
    {
        private readonly string _connectionString;
        public AsiDataServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }

        public List<Asi> GetList()
        {
            List<Asi> asilist = new List<Asi>();


            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT021", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asi asi = new Asi();
                            asi.SIRKETNO = reader.GetInt32(0);
                            asi.ASI_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { asi.ASI_ADI = null; }
                            else { asi.ASI_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { asi.YAP_AY = null; }
                            else { asi.YAP_AY = reader.GetInt32(3); }

                            if (reader.IsDBNull(4)) { asi.ACIKLAMA = null; }
                            else { asi.ACIKLAMA = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { asi.INP_USER = null; }
                            else { asi.INP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { asi.INP_DATE = null; }
                            else { asi.INP_DATE = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { asi.UDP_USER = null; }
                            else { asi.UDP_USER = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { asi.UDP_DATE = null; }
                            else { asi.UDP_DATE = reader.GetString(8); }

                            if (reader.IsDBNull(9)) { asi.ASI_BEDELI = null; }
                            else { asi.ASI_BEDELI = reader.GetDecimal(9); }


                            asilist.Add(asi);

                        }
                    }
                }
            }


            return asilist;
        }

        public Asi GetAsiById(int id)
        {
            Asi asi = new Asi();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT021 where ASI_NO=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            asi.SIRKETNO = reader.GetInt32(0);
                            asi.ASI_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { asi.ASI_ADI = null; }
                            else { asi.ASI_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { asi.YAP_AY = null; }
                            else { asi.YAP_AY = reader.GetInt32(3); }

                            if (reader.IsDBNull(4)) { asi.ACIKLAMA = null; }
                            else { asi.ACIKLAMA = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { asi.INP_USER = null; }
                            else { asi.INP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { asi.INP_DATE = null; }
                            else { asi.INP_DATE = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { asi.UDP_USER = null; }
                            else { asi.UDP_USER = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { asi.UDP_DATE = null; }
                            else { asi.UDP_DATE = reader.GetString(8); }

                            if (reader.IsDBNull(9)) { asi.ASI_BEDELI = null; }
                            else { asi.ASI_BEDELI = reader.GetDecimal(9); }

                        }
                    }
                }
            }


            return asi;
        }
        public void AsiEkle(Asi asi)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            int asino = GetList().Max(o => o.ASI_NO) + 1;
            command.CommandText = $"INSERT INTO CFKTT021 (SIRKETNO,ASI_NO,ASI_ADI,YAP_AY,ACIKLAMA) VALUES(1,{asino},'{asi.ASI_ADI}', {asi.YAP_AY}, '{asi.ACIKLAMA}')";
            command.ExecuteNonQuery();
        }

        public void AsiGuncelle(Asi asi, int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE CFKTT021 SET ASI_ADI = '{asi.ASI_ADI}',YAP_AY = {asi.YAP_AY},ACIKLAMA = '{asi.ACIKLAMA}' where ASI_NO={id}";
            command.ExecuteNonQuery();
        }

        public void AsiSil(int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM CFKTT021 WHERE ASI_NO={id}";
            command.ExecuteNonQuery();
        }
        public List<Asi> AsiAra(string searchTerm)
        {
            List<Asi> asilist = new List<Asi>();


            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT021 WHERE UPPER(ASI_ADI) LIKE UPPER(:searchTerm) AND LOWER(ASI_ADI) LIKE LOWER(:searchTerm)", connection))
                {
                    command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asi asi = new Asi();
                            asi.SIRKETNO = reader.GetInt32(0);
                            asi.ASI_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { asi.ASI_ADI = null; }
                            else { asi.ASI_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { asi.YAP_AY = null; }
                            else { asi.YAP_AY = reader.GetInt32(3); }

                            if (reader.IsDBNull(4)) { asi.ACIKLAMA = null; }
                            else { asi.ACIKLAMA = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { asi.INP_USER = null; }
                            else { asi.INP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { asi.INP_DATE = null; }
                            else { asi.INP_DATE = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { asi.UDP_USER = null; }
                            else { asi.UDP_USER = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { asi.UDP_DATE = null; }
                            else { asi.UDP_DATE = reader.GetString(8); }

                            if (reader.IsDBNull(9)) { asi.ASI_BEDELI = null; }
                            else { asi.ASI_BEDELI = reader.GetDecimal(9); }


                            asilist.Add(asi);

                        }
                    }
                }
            }


            return asilist;
        }
    }
}
