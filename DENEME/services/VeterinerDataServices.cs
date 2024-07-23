using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class VeterinerDataServices
    {
        private readonly string _connectionString;

        public VeterinerDataServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }
        public List<Veteriner> GetList()
        {
            List<Veteriner> veterinerlist = new List<Veteriner>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT002", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Veteriner v = new Veteriner();
                            v.SIRKETNO = reader.GetInt32(0);
                            v.VET_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { v.VET_ADI = null; }
                            else { v.VET_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { v.IS_GIR_TARIH = null; }
                            else { v.IS_GIR_TARIH = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { v.ADRES = null; }
                            else { v.ADRES = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { v.ADRES_IL = null; }
                            else { v.ADRES_IL = reader.GetInt32(5); }

                            if (reader.IsDBNull(6)) { v.ADRES_ILCE = null; }
                            else { v.ADRES_ILCE = reader.GetInt32(6); }

                            if (reader.IsDBNull(7)) { v.TELEFON = null; }
                            else { v.TELEFON = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { v.TC_NO = null; }
                            else { v.TC_NO = reader.GetString(8); }

                            if (reader.IsDBNull(9)) { v.DOG_TARIH = null; }
                            else { v.DOG_TARIH = reader.GetString(9); }

                            if (reader.IsDBNull(10)) { v.INP_USER = null; }
                            else { v.INP_USER = reader.GetString(10); }

                            if (reader.IsDBNull(11)) { v.INP_DATE = null; }
                            else { v.INP_DATE = reader.GetString(11); }

                            if (reader.IsDBNull(12)) { v.UDP_USER = null; }
                            else { v.UDP_USER = reader.GetString(12); }

                            if (reader.IsDBNull(13)) { v.UDP_DATE = null; }
                            else { v.UDP_DATE = reader.GetString(13); }

                            if (reader.IsDBNull(14)) { v.ISBITIS_TARIH = null; }
                            else { v.ISBITIS_TARIH = reader.GetString(14); }

                            veterinerlist.Add(v);

                        }


                    }
                }
            }
            return veterinerlist;
        }
        public Veteriner GetVeterinerById(int id)
        {
            Veteriner v = new Veteriner();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT002 where VET_NO=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            v.SIRKETNO = reader.GetInt32(0);
                            v.VET_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { v.VET_ADI = null; }
                            else { v.VET_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { v.IS_GIR_TARIH = null; }
                            else { v.IS_GIR_TARIH = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { v.ADRES = null; }
                            else { v.ADRES = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { v.ADRES_IL = null; }
                            else { v.ADRES_IL = reader.GetInt32(5); }

                            if (reader.IsDBNull(6)) { v.ADRES_ILCE = null; }
                            else { v.ADRES_ILCE = reader.GetInt32(6); }

                            if (reader.IsDBNull(7)) { v.TELEFON = null; }
                            else { v.TELEFON = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { v.TC_NO = null; }
                            else { v.TC_NO = reader.GetString(8); }

                            if (reader.IsDBNull(9)) { v.DOG_TARIH = null; }
                            else { v.DOG_TARIH = reader.GetString(9); }

                            if (reader.IsDBNull(10)) { v.INP_USER = null; }
                            else { v.INP_USER = reader.GetString(10); }

                            if (reader.IsDBNull(11)) { v.INP_DATE = null; }
                            else { v.INP_DATE = reader.GetString(11); }

                            if (reader.IsDBNull(12)) { v.UDP_USER = null; }
                            else { v.UDP_USER = reader.GetString(12); }

                            if (reader.IsDBNull(13)) { v.UDP_DATE = null; }
                            else { v.UDP_DATE = reader.GetString(13); }

                            if (reader.IsDBNull(14)) { v.ISBITIS_TARIH = null; }
                            else { v.ISBITIS_TARIH = reader.GetString(14); }



                        }


                    }
                }
            }
            return v;
        }

        public void VeterinerEkle(Veteriner v)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            int vetno = GetList().Max(o => o.VET_NO) + 1;
            command.CommandText = $"INSERT INTO CFKTT002 (SIRKETNO,VET_NO,VET_ADI,IS_GIR_TARIH,ADRES,ADRES_IL,ADRES_ILCE,TELEFON,TC_NO,DOG_TARIH,ISBITIS_TARIH) VALUES(1,{vetno},'{v.VET_ADI}','{v.IS_GIR_TARIH}','{v.ADRES}',{v.ADRES_IL},{v.ADRES_ILCE},'{v.TELEFON}','{v.TC_NO}','{v.DOG_TARIH}','{v.ISBITIS_TARIH}')";
            command.ExecuteNonQuery();

        }

        public void VeterinerGuncelle(Veteriner v, int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE CFKTT002 SET VET_ADI = '{v.VET_ADI}',IS_GIR_TARIH = '{v.IS_GIR_TARIH}',ADRES = '{v.ADRES}',ADRES_IL = {Convert.ToInt32(v.ADRES_IL)},ADRES_ILCE = {Convert.ToInt32(v.ADRES_ILCE)},TELEFON = '{v.TELEFON}',TC_NO = '{v.TC_NO}',DOG_TARIH = '{v.DOG_TARIH}',ISBITIS_TARIH = '{v.ISBITIS_TARIH}' where VET_NO={id}";
            command.ExecuteNonQuery();
        }

        public void VeterinerSil(int id)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM CFKTT002 WHERE VET_NO={id}";
            command.ExecuteNonQuery();
        }
        public List<Veteriner> VeterinerAra(string searchTerm)
        {
            List<Veteriner> veterinerlist = new List<Veteriner>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKTT002 WHERE UPPER(VET_ADI) LIKE UPPER(:searchTerm) AND LOWER(VET_ADI) LIKE LOWER(:searchTerm)", connection))
                {
                    command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Veteriner v = new Veteriner();
                            v.SIRKETNO = reader.GetInt32(0);
                            v.VET_NO = reader.GetInt32(1);

                            if (reader.IsDBNull(2)) { v.VET_ADI = null; }
                            else { v.VET_ADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { v.IS_GIR_TARIH = null; }
                            else { v.IS_GIR_TARIH = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { v.ADRES = null; }
                            else { v.ADRES = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { v.ADRES_IL = null; }
                            else { v.ADRES_IL = reader.GetInt32(5); }

                            if (reader.IsDBNull(6)) { v.ADRES_ILCE = null; }
                            else { v.ADRES_ILCE = reader.GetInt32(6); }

                            if (reader.IsDBNull(7)) { v.TELEFON = null; }
                            else { v.TELEFON = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { v.TC_NO = null; }
                            else { v.TC_NO = reader.GetString(8); }

                            if (reader.IsDBNull(9)) { v.DOG_TARIH = null; }
                            else { v.DOG_TARIH = reader.GetString(9); }

                            if (reader.IsDBNull(10)) { v.INP_USER = null; }
                            else { v.INP_USER = reader.GetString(10); }

                            if (reader.IsDBNull(11)) { v.INP_DATE = null; }
                            else { v.INP_DATE = reader.GetString(11); }

                            if (reader.IsDBNull(12)) { v.UDP_USER = null; }
                            else { v.UDP_USER = reader.GetString(12); }

                            if (reader.IsDBNull(13)) { v.UDP_DATE = null; }
                            else { v.UDP_DATE = reader.GetString(13); }

                            if (reader.IsDBNull(14)) { v.ISBITIS_TARIH = null; }
                            else { v.ISBITIS_TARIH = reader.GetString(14); }

                            veterinerlist.Add(v);

                        }


                    }
                }
            }
            return veterinerlist;
        }
    }
}
