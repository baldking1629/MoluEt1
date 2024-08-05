using Microsoft.Build.Framework;
using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class RasyonUretimDataServices
    {
        private readonly string _connectionString;
        public RasyonUretimDataServices()
        {
            _connectionString = ("Data Source=192.168.1.5:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }

        public List<RasyonUretim> GetList()
        {
            List<RasyonUretim> rasyonUretimlist = new List<RasyonUretim>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select SIRKETNO,CIFTLIKNO,URETIMNO,TARIH,ACIKLAMA from CFKMT010", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            RasyonUretim rasyonUretim = new RasyonUretim();

                            rasyonUretim.SIRKETNO = reader.GetInt32(0);
                            rasyonUretim.CIFTLIKNO = reader.GetInt32(1);
                            rasyonUretim.URETIMNO = reader.GetInt32(2);


                            if (reader.IsDBNull(3)) { rasyonUretim.TARIH = null; }
                            else { rasyonUretim.TARIH = reader.GetDateTime(3); }

                            if (reader.IsDBNull(4)) { rasyonUretim.ACIKLAMA = null; }
                            else { rasyonUretim.ACIKLAMA = reader.GetString(4); }

                            using (OracleCommand command1 = new OracleCommand("Select CIFTLIKADI from CFKMT001 where CIFTLIKNO=" + rasyonUretim.CIFTLIKNO, connection))
                            {
                                using (OracleDataReader reader1 = command1.ExecuteReader())
                                {
                                    while (reader1.Read())
                                    {
                                        if (reader1.IsDBNull(0)) { rasyonUretim.CIFTLIKADI = null; }
                                        else { rasyonUretim.CIFTLIKADI = reader1.GetString(0); }
                                    }
                                }

                            }
                            rasyonUretimlist.Add(rasyonUretim);
                        }
                    }
                }
            }
            return rasyonUretimlist;
        }
        public RasyonUretim GetRasyonByID(int uretimno, int ciftlikno)
        {
            RasyonUretim rasyonUretim = new RasyonUretim();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select SIRKETNO,CIFTLIKNO,URETIMNO,TARIH,ACIKLAMA from CFKMT010 where URETIMNO=" + uretimno + " AND CIFTLIKNO=" + ciftlikno, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {



                            rasyonUretim.SIRKETNO = reader.GetInt32(0);
                            rasyonUretim.CIFTLIKNO = reader.GetInt32(1);
                            rasyonUretim.URETIMNO = reader.GetInt32(2);


                            if (reader.IsDBNull(3)) { rasyonUretim.TARIH = null; }
                            else { rasyonUretim.TARIH = reader.GetDateTime(3); }

                            if (reader.IsDBNull(4)) { rasyonUretim.ACIKLAMA = null; }
                            else { rasyonUretim.ACIKLAMA = reader.GetString(4); }

                            using (OracleCommand command1 = new OracleCommand("Select CIFTLIKADI from CFKMT001 where CIFTLIKNO=" + rasyonUretim.CIFTLIKNO, connection))
                            {
                                using (OracleDataReader reader1 = command1.ExecuteReader())
                                {
                                    while (reader1.Read())
                                    {
                                        if (reader1.IsDBNull(0)) { rasyonUretim.CIFTLIKADI = null; }
                                        else { rasyonUretim.CIFTLIKADI = reader1.GetString(0); }
                                    }
                                }

                            }

                        }
                    }
                }
            }
            return rasyonUretim;
        }

        public List<RasyonUretim> RasyonUretimAra(string searchTerm)
        {
            List<RasyonUretim> rasyonUretimlist = new List<RasyonUretim>();


            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select * from CFKMT010 WHERE UPPER(ACIKLAMA) LIKE UPPER(:searchTerm) AND LOWER(ACIKLAMA) LIKE LOWER(:searchTerm)", connection))
                {
                    command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            RasyonUretim rasyonUretim = new RasyonUretim();

                            rasyonUretim.SIRKETNO = reader.GetInt32(0);
                            rasyonUretim.CIFTLIKNO = reader.GetInt32(1);
                            rasyonUretim.URETIMNO = reader.GetInt32(2);


                            if (reader.IsDBNull(3)) { rasyonUretim.TARIH = null; }
                            else { rasyonUretim.TARIH = reader.GetDateTime(3); }

                            if (reader.IsDBNull(4)) { rasyonUretim.ACIKLAMA = null; }
                            else { rasyonUretim.ACIKLAMA = reader.GetString(4); }

                            using (OracleCommand command1 = new OracleCommand("Select CIFTLIKADI from CFKMT001 where CIFTLIKNO=" + rasyonUretim.CIFTLIKNO, connection))
                            {
                                using (OracleDataReader reader1 = command1.ExecuteReader())
                                {
                                    while (reader1.Read())
                                    {
                                        if (reader1.IsDBNull(0)) { rasyonUretim.CIFTLIKADI = null; }
                                        else { rasyonUretim.CIFTLIKADI = reader1.GetString(0); }
                                    }
                                }

                            }
                            rasyonUretimlist.Add(rasyonUretim);
                        }
                    }
                }
            }
            return rasyonUretimlist;
        }

        public List<RasyonUretimDetay> GetRasyonUretimById(int uretimno, int ciftlikno)
        {
            List<RasyonUretimDetay> rasyonUretimDetaylist = new List<RasyonUretimDetay>();


            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("Select SIRKETNO,CIFTLIKNO,URETIMNO,SIRANO,URUNNO,MIKTAR,TARIH from CFKDT011 where URETIMNO=" + uretimno + "AND CIFTLIKNO=" + ciftlikno, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {


                        if (reader.Read() == false)
                        {
                            RasyonUretimDetay rasyonUretimDetay = new RasyonUretimDetay();
                            rasyonUretimDetay.rasyonUretim = GetRasyonByID(uretimno, ciftlikno);
                            rasyonUretimDetaylist.Add(rasyonUretimDetay);
                        }
                        else 
                        {
                            do
                            {
                                RasyonUretimDetay rasyonUretimDetay = new RasyonUretimDetay();
                                rasyonUretimDetay.SIRKETNO = reader.GetInt32(0);
                                rasyonUretimDetay.CIFTLIKNO = reader.GetInt32(1);
                                rasyonUretimDetay.URETIMNO = reader.GetInt32(2);
                                rasyonUretimDetay.SIRANO = reader.GetInt32(3);

                                if (reader.IsDBNull(4)) { rasyonUretimDetay.URUNNO = null; }
                                else { rasyonUretimDetay.URUNNO = reader.GetInt32(4); }

                                if (reader.IsDBNull(5)) { rasyonUretimDetay.MIKTAR = null; }
                                else { rasyonUretimDetay.MIKTAR = reader.GetDecimal(5); }

                                if (reader.IsDBNull(6)) { rasyonUretimDetay.TARIH = null; }
                                else { rasyonUretimDetay.TARIH = reader.GetDateTime(6); }

                                using (OracleCommand command1 = new OracleCommand("Select CIFTLIKADI from CFKMT001 where CIFTLIKNO=" + rasyonUretimDetay.CIFTLIKNO, connection))
                                {
                                    using (OracleDataReader reader1 = command1.ExecuteReader())
                                    {
                                        while (reader1.Read())
                                        {
                                            if (reader1.IsDBNull(0)) { rasyonUretimDetay.CIFTLIKADI = null; }
                                            else { rasyonUretimDetay.CIFTLIKADI = reader1.GetString(0); }
                                        }
                                    }

                                }
                                using (OracleCommand command2 = new OracleCommand("SELECT EMTIAAD FROM STOKM001 WHERE EMTIANO =" + rasyonUretimDetay.URUNNO, connection))
                                {
                                    using (OracleDataReader reader2 = command2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            if (reader2.IsDBNull(0)) { rasyonUretimDetay.URUNADI = null; }
                                            else { rasyonUretimDetay.URUNADI = reader2.GetString(0); }
                                        }
                                    }

                                }

                                using (OracleCommand command2 = new OracleCommand("SELECT ACIKLAMA FROM CFKMT010 WHERE CIFTLIKNO =" + ciftlikno + "AND URETIMNO =" + uretimno, connection))
                                {
                                    using (OracleDataReader reader2 = command2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            if (reader2.IsDBNull(0)) { rasyonUretimDetay.ACIKLAMA = null; }
                                            else { rasyonUretimDetay.ACIKLAMA = reader2.GetString(0); }
                                        }
                                    }
                                }
                                rasyonUretimDetay.rasyonUretim = GetRasyonByID(uretimno, ciftlikno);
                                rasyonUretimDetaylist.Add(rasyonUretimDetay);
                            } while (reader.Read());
                        }

                    }
                }
            }
            return rasyonUretimDetaylist;
        }

        public void RasyonUretimEkle(RasyonUretim r)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO CFKMT010 (SIRKETNO,CIFTLIKNO,URETIMNO,TARIH,ACIKLAMA) VALUES(:SIRKETNO,:CIFTLIKNO,:URETIMNO,:TARIH,:ACIKLAMA)";
            command.Parameters.Add(new OracleParameter("SIRKETNO", r.SIRKETNO));
            command.Parameters.Add(new OracleParameter("CIFTLIKNO", r.CIFTLIKNO));
            command.Parameters.Add(new OracleParameter("URETIMNO", r.URETIMNO));
            command.Parameters.Add(new OracleParameter("TARIH", r.TARIH));
            command.Parameters.Add(new OracleParameter("ACIKLAMA", r.ACIKLAMA));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void RasyonUretimGuncelle(RasyonUretim r)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE CFKMT010 SET TARIH=:TARIH, ACIKLAMA=:ACIKLAMA WHERE CIFTLIKNO=:CIFTIKNO AND URETIMNO=:URETIMNO";
            command.Parameters.Add(new OracleParameter("TARIH", r.TARIH));
            command.Parameters.Add(new OracleParameter("ACIKLAMA", r.ACIKLAMA));
            command.Parameters.Add(new OracleParameter("CIFTLIKNO", r.CIFTLIKNO));
            command.Parameters.Add(new OracleParameter("URETIMNO", r.URETIMNO));
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void RasyonUretimDetayEkle(RasyonUretimDetay r)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();

            int sirano;
            if (GetRasyonUretimById(r.URETIMNO, r.CIFTLIKNO).Count == 0)
            {
                sirano = 1;
            }
            else
            {
                sirano = GetRasyonUretimById(r.URETIMNO, r.CIFTLIKNO).Max(o => o.SIRANO) + 1;
            }
            command.CommandText = "INSERT INTO CFKDT011 (SIRKETNO,CIFTLIKNO,URETIMNO,SIRANO,URUNNO,MIKTAR,TARIH) VALUES(:SIRKETNO,:CIFTLIKNO,:URETIMNO,:SIRANO,:URUNNO,:MIKTAR,:TARIH)";
            command.Parameters.Add(new OracleParameter("SIRKETNO", r.SIRKETNO));
            command.Parameters.Add(new OracleParameter("CIFTLIKNO", r.CIFTLIKNO));
            command.Parameters.Add(new OracleParameter("URETIMNO", r.URETIMNO));
            command.Parameters.Add(new OracleParameter("SIRANO", sirano));
            command.Parameters.Add(new OracleParameter("URUNNO", r.URUNNO));
            command.Parameters.Add(new OracleParameter("MIKTAR", r.MIKTAR));
            command.Parameters.Add(new OracleParameter("TARIH", r.TARIH));


            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
