using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class IlIlceDataServices
    {
        private readonly string _connectionString;

        public IlIlceDataServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }
        public List<Ulke> GetUlkeList()
        {
            List<Ulke> ulkelist = new List<Ulke>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from TANTT006", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ulke u = new Ulke();
                            u.ULKENO = reader.GetInt32(1);
                            if (reader.IsDBNull(2)) { u.ULKEAD = null; }
                            else { u.ULKEAD = reader.GetString(2); }
                            ulkelist.Add(u);
                        }
                    }
                }
            }
            return ulkelist;
        }
        public List<Il> GetIlList()
        {
            List<Il> illist = new List<Il>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from TANTT005", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Il u = new Il();
                            u.ILNO = reader.GetInt32(1);
                            if (reader.IsDBNull(2)) { u.ILAD = null; }
                            else { u.ILAD = reader.GetString(2); }
                            u.ULKENO = reader.GetInt32(3);

                            illist.Add(u);
                        }
                    }
                }
            }
            return illist;
        }
        public List<Ilce> GetIlceList(int id)
        {
            List<Ilce> ilcelist = new List<Ilce>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from TANTT205 where ILNO=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ilce u = new Ilce();
                            u.ILNO = reader.GetInt32(2);
                            if (reader.IsDBNull(4)) { u.ILCEAD = null; }
                            else { u.ILCEAD = reader.GetString(4); }
                            u.ULKENO = reader.GetInt32(1);
                            u.ILCENO = reader.GetInt32(3);

                            ilcelist.Add(u);
                        }
                    }
                }
            }
            return ilcelist;
        }

    }
}
