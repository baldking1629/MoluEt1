using System.Data;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;

public class OracleDataService
{
    private readonly string _connectionString;

    public OracleDataService(IConfiguration configuration)
    {
        _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
    }

    public DataTable GetData()
    {
        DataTable dataTable = new DataTable();

        using (OracleConnection connection = new OracleConnection(_connectionString))
        {
            connection.Open();
            using (OracleCommand command = new OracleCommand("SELECT * FROM CFKTT003", connection))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
        }

        return dataTable;
    }

    public DataTable GetDataIrkTanım()
    {
        DataTable dataTable = new DataTable();

        using (OracleConnection connection = new OracleConnection(_connectionString))
        {
            connection.Open();
            using (OracleCommand command = new OracleCommand("SELECT * FROM CFKTT005", connection))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
        }

        return dataTable;
    }

}
