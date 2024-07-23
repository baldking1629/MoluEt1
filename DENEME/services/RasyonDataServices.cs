using Microsoft.AspNetCore.Mvc;
using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;

namespace MoluEt.services
{
    public class RasyonDataServices
    {
        private readonly string _connectionString;

        public RasyonDataServices()
        {
            _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
        }

        public List<Rasyon> GetList()
        {
            List<Rasyon> rasyonlist = new List<Rasyon>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("Select * from CFKMT003", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rasyon h = new Rasyon();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.CIFTLIKNO = reader.GetInt32(1);
                            h.URUNNO = reader.GetInt32(2);




                            if (reader.IsDBNull(3)) { h.MIKTAR = null; }
                            else { h.MIKTAR = reader.GetDecimal(3); }

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

                            if (reader.IsDBNull(9)) { h.TARIH = null; }
                            else { h.TARIH = reader.GetString(9); }

                            if (reader.IsDBNull(10)) { h.TUTAR = null; }
                            else { h.TUTAR = reader.GetDecimal(10); }
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
                            using (OracleCommand command2 = new OracleCommand("SELECT EMTIAAD FROM STOKM001 WHERE EMTIANO =" + h.URUNNO, connection))
                            {
                                using (OracleDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        if (reader2.IsDBNull(0)) { h.URUNACIKLAMA = null; }
                                        else { h.URUNACIKLAMA = reader2.GetString(0); }
                                    }
                                }

                            }

                            rasyonlist.Add(h);
                        }

                    }
                }



            }
            return rasyonlist;
        }

        public List<Rasyon> GetRasyonById(int id, int ciftlikno)
        {
            List<Rasyon> rasyonlist = new List<Rasyon>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("Select * from CFKMT003 where CIFTLIKNO=" + ciftlikno + " AND URUNNO=" + id, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rasyon h = new Rasyon();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.CIFTLIKNO = reader.GetInt32(1);
                            h.URUNNO = reader.GetInt32(2);




                            if (reader.IsDBNull(3)) { h.MIKTAR = null; }
                            else { h.MIKTAR = reader.GetDecimal(3); }

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

                            if (reader.IsDBNull(9)) { h.TARIH = null; }
                            else { h.TARIH = reader.GetString(9); }

                            if (reader.IsDBNull(10)) { h.TUTAR = null; }
                            else { h.TUTAR = reader.GetDecimal(10); }
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
                            using (OracleCommand command2 = new OracleCommand("SELECT EMTIAAD FROM STOKM001 WHERE EMTIANO =" + h.URUNNO, connection))
                            {
                                using (OracleDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        if (reader2.IsDBNull(0)) { h.URUNACIKLAMA = null; }
                                        else { h.URUNACIKLAMA = reader2.GetString(0); }
                                    }
                                }

                            }

                            rasyonlist.Add(h);
                        }

                    }
                }



            }
            return rasyonlist;
        }
        public List<RasyonDetay> GetListRasyonDetayById(int id, int ciftlikno)
        {
            List<RasyonDetay> rasyonlist = new List<RasyonDetay>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("Select * from CFKDT003 where URUNNO=" + id + "AND CIFTLIKNO=" + ciftlikno, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RasyonDetay h = new RasyonDetay();
                            h.SIRKETNO = reader.GetInt32(0);
                            h.CIFTLIKNO = reader.GetInt32(1);
                            h.URUNNO = reader.GetInt32(2);

                            h.SIRANO = reader.GetInt32(3);


                            if (reader.IsDBNull(4)) { h.EMTIANO = null; }
                            else { h.EMTIANO = reader.GetInt32(4); }

                            if (reader.IsDBNull(5)) { h.MIKTAR = null; }
                            else { h.MIKTAR = reader.GetDecimal(5); }

                            if (reader.IsDBNull(6)) { h.FIYAT = null; }
                            else { h.FIYAT = reader.GetDecimal(6); }

                            if (reader.IsDBNull(5)) { h.INP_USER = null; }
                            else { h.INP_USER = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { h.INP_DATE = null; }
                            else { h.INP_DATE = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { h.UDP_USER = null; }
                            else { h.UDP_USER = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { h.UDP_DATE = null; }
                            else { h.UDP_DATE = reader.GetString(8); }


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
                            using (OracleCommand command2 = new OracleCommand("SELECT EMTIAAD FROM STOKM001 WHERE EMTIANO =" + h.EMTIANO, connection))
                            {
                                using (OracleDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        if (reader2.IsDBNull(0)) { h.EMTIAADI = null; }
                                        else { h.EMTIAADI = reader2.GetString(0); }
                                    }
                                }

                            }
                            using (OracleCommand command2 = new OracleCommand("SELECT MIKTAR,ACIKLAMA FROM CFKMT003 WHERE URUNNO =" + h.URUNNO + "AND CIFTLIKNO=" + ciftlikno, connection))
                            {
                                using (OracleDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        if (reader2.IsDBNull(0)) { h.BRMMIKTAR = null; }
                                        else { h.BRMMIKTAR = reader2.GetDecimal(0); }
                                        if (reader2.IsDBNull(1)) { h.ACIKLAMA = null; }
                                        else { h.ACIKLAMA = reader2.GetString(1); }
                                    }
                                }

                            }
                            using (OracleCommand command2 = new OracleCommand("SELECT EMTIAAD FROM STOKM001 WHERE EMTIANO =" + h.URUNNO, connection))
                            {
                                using (OracleDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        if (reader2.IsDBNull(0)) { h.URUNADI = null; }
                                        else { h.URUNADI = reader2.GetString(0); }
                                    }
                                }

                            }
                            rasyonlist.Add(h);
                        }
                    }
                }
            }
            return rasyonlist;
        }

        public void RasyonEkle(Rasyon r)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO CFKMT003 (SIRKETNO,CIFTLIKNO,URUNNO,MIKTAR,ACIKLAMA) VALUES(1,{r.CIFTLIKNO},{r.URUNNO},{r.MIKTAR},'{r.ACIKLAMA}')";
            command.ExecuteNonQuery();
        }
        public void RasyonDetayEkle(RasyonDetay r)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            int sirano;
            if (GetListRasyonDetayById(r.URUNNO, r.CIFTLIKNO).Count == 0)
            {
                sirano = 1;
            }
            else
            {
                sirano = GetListRasyonDetayById(r.URUNNO, r.CIFTLIKNO).Max(o => o.SIRANO) + 1;
            }

            command.CommandText = $"INSERT INTO CFKDT003 (SIRKETNO,CIFTLIKNO,URUNNO,SIRANO,EMTIANO,MIKTAR) VALUES(1,{r.CIFTLIKNO},{r.URUNNO},{sirano},{r.EMTIANO},{r.MIKTAR})";
            command.ExecuteNonQuery();
        }
        public void RasyonDetaySil(int ciftlikno,int urunno, int sirano)
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM CFKDT003 WHERE CIFTLIKNO={ciftlikno} AND URUNNO={urunno} AND SIRANO={sirano}";
            command.ExecuteNonQuery();
        }
        public List<Ciftlik> CiftlikGetir()
        {
            List<Ciftlik> ciftliklist = new List<Ciftlik>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT * FROM CFKMT001", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ciftlik? ciftlik = new Ciftlik();

                            ciftlik.SIRKETNO = reader.GetInt32(0);
                            ciftlik.CIFTLIKNO = reader.GetInt32(1);
                            if (reader.IsDBNull(2)) { ciftlik.CIFTLIKADI = null; }
                            else { ciftlik.CIFTLIKADI = reader.GetString(2); }

                            if (reader.IsDBNull(3)) { ciftlik.ADRES = null; }
                            else { ciftlik.ADRES = reader.GetString(3); }

                            if (reader.IsDBNull(4)) { ciftlik.ILCE = null; }
                            else { ciftlik.ILCE = reader.GetString(4); }

                            if (reader.IsDBNull(5)) { ciftlik.IL = null; }
                            else { ciftlik.IL = reader.GetString(5); }

                            if (reader.IsDBNull(6)) { ciftlik.TELEFON = null; }
                            else { ciftlik.TELEFON = reader.GetString(6); }

                            if (reader.IsDBNull(7)) { ciftlik.FAX = null; }
                            else { ciftlik.FAX = reader.GetString(7); }

                            if (reader.IsDBNull(8)) { ciftlik.E_MAIL = null; }
                            else { ciftlik.E_MAIL = reader.GetString(8); }

                            if (reader.IsDBNull(9)) { ciftlik.VERGI_DAIRESI = null; }
                            else { ciftlik.VERGI_DAIRESI = reader.GetString(9); }

                            if (reader.IsDBNull(10)) { ciftlik.VERGI_NO = null; }
                            else { ciftlik.VERGI_NO = reader.GetString(10); }

                            if (reader.IsDBNull(11)) { ciftlik.RESIM = null; }
                            else { ciftlik.RESIM = reader.GetString(11); }

                            if (reader.IsDBNull(12)) { ciftlik.DEPONO = null; }
                            else { ciftlik.DEPONO = reader.GetInt32(12); }

                            if (reader.IsDBNull(13)) { ciftlik.RUHSATNO = null; }
                            else { ciftlik.RUHSATNO = reader.GetString(13); }

                            if (reader.IsDBNull(14)) { ciftlik.ISLETMENO = null; }
                            else { ciftlik.ISLETMENO = reader.GetString(14); }

                            if (reader.IsDBNull(15)) { ciftlik.ISLETMEONAYNO = null; }
                            else { ciftlik.ISLETMEONAYNO = reader.GetString(15); }

                            if (reader.IsDBNull(16)) { ciftlik.INP_USER = null; }
                            else { ciftlik.INP_USER = reader.GetString(16); }

                            if (reader.IsDBNull(17)) { ciftlik.INP_DATE = null; }
                            else { ciftlik.INP_DATE = reader.GetString(17); }

                            if (reader.IsDBNull(18)) { ciftlik.UDP_USER = null; }
                            else { ciftlik.UDP_USER = reader.GetString(18); }

                            if (reader.IsDBNull(19)) { ciftlik.UDP_DATE = null; }
                            else { ciftlik.UDP_DATE = reader.GetString(19); }
                            ciftliklist.Add(ciftlik);
                        }

                    }
                }
            }

            return ciftliklist;
        }
        public List<Urun> UrunGetir()
        {
            List<Urun> urunList = new List<Urun>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT * FROM STOKM001 where EMTIANO BETWEEN 500009 AND 500011", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            Urun urun = new Urun();


                            urun.EMTIANO = reader.GetInt32(1);
                            urun.EMTIAAD = reader.GetString(2);


                            if (reader.IsDBNull(3)) { urun.YABADI = null; }
                            else { urun.YABADI = reader.GetString(3); }


                            urunList.Add(urun);
                        }

                    }
                }
            }

            return urunList;
        }
        public List<Urun> EmtiaGetir()
        {
            List<Urun> emtiaList = new List<Urun>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT * FROM STOKM001 where EMTIANO BETWEEN 500000 AND 500099", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            Urun urun = new Urun();


                            urun.EMTIANO = reader.GetInt32(1);
                            urun.EMTIAAD = reader.GetString(2);


                            if (reader.IsDBNull(3)) { urun.YABADI = null; }
                            else { urun.YABADI = reader.GetString(3); }


                            emtiaList.Add(urun);
                        }

                    }
                }
            }
            return emtiaList;
        }
    }
}
