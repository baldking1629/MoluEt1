using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class YemlemeOgunDataServices
    {
        private readonly string _connectionString;

        public YemlemeOgunDataServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }


        public List<YemlemeOgun> GetList()
        {
            List<YemlemeOgun> yemlemelist = new List<YemlemeOgun>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT004", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            YemlemeOgun y = new YemlemeOgun();
                            y.SIRKETNO = reader.GetInt32(0);
                            y.OGUNSIRA = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { y.ACIKLAMA = null; }
                            else { y.ACIKLAMA = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { y.INP_USER = null; }
                            else { y.INP_USER = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { y.INP_DATE = null; }
                            else { y.INP_DATE = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { y.UDP_USER = null; }
                            else { y.UDP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { y.UDP_DATE = null; }
                            else { y.UDP_DATE = reader.GetString(6); }
                            yemlemelist.Add(y);

                        }


                    }
                }
            }
            return yemlemelist;
        }

        public YemlemeOgun GetYemlemeOgunForId(int id)
        {
            YemlemeOgun y = new YemlemeOgun();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT004 where OGUNSIRA=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            y.SIRKETNO = reader.GetInt32(0);
                            y.OGUNSIRA = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { y.ACIKLAMA = null; }
                            else { y.ACIKLAMA = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { y.INP_USER = null; }
                            else { y.INP_USER = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { y.INP_DATE = null; }
                            else { y.INP_DATE = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { y.UDP_USER = null; }
                            else { y.UDP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { y.UDP_DATE = null; }
                            else { y.UDP_DATE = reader.GetString(6); }

                        }


                    }
                }
            }
            return y;
        }

        public void YemlemeOgunEkleme(YemlemeOgun y)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            int ogunsira = GetList().Max(o => o.OGUNSIRA) + 1;
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO CFKTT004 (SIRKETNO,OGUNSIRA,ACIKLAMA) VALUES(1,{ogunsira},'{y.ACIKLAMA}')";
            command.ExecuteNonQuery();
        }

        public void YemlemeOgunGuncelle(YemlemeOgun y, int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE CFKTT004 SET ACIKLAMA='{y.ACIKLAMA}' where OGUNSIRA={id}";
            command.ExecuteNonQuery();
        }
        public void YemlemeOgunSil(int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM CFKTT004 WHERE OGUNSIRA={id}";
            command.ExecuteNonQuery();
        }

        public List<YemlemeOgun> YemlemeOgunAra(string searchTerm)
        {
            List<YemlemeOgun> yemlemelist = new List<YemlemeOgun>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT004 WHERE UPPER(ACIKLAMA) LIKE UPPER(:searchTerm) AND LOWER(ACIKLAMA) LIKE LOWER(:searchTerm)", connection))
                {
                    command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            YemlemeOgun y = new YemlemeOgun();
                            y.SIRKETNO = reader.GetInt32(0);
                            y.OGUNSIRA = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { y.ACIKLAMA = null; }
                            else { y.ACIKLAMA = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { y.INP_USER = null; }
                            else { y.INP_USER = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { y.INP_DATE = null; }
                            else { y.INP_DATE = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { y.UDP_USER = null; }
                            else { y.UDP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { y.UDP_DATE = null; }
                            else { y.UDP_DATE = reader.GetString(6); }
                            yemlemelist.Add(y);

                        }


                    }
                }
            }
            return yemlemelist;
        }
    }
}
