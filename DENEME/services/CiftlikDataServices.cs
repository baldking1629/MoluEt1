using System.Data;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;
using MoluEt.Models;
using System.Data.Common;
using System.Collections.Generic;
using System.Reflection.Metadata;


public class CiftlikDataService
{
    private readonly string _connectionString;

    public CiftlikDataService()
    {
        _connectionString = ("Data Source=192.168.1.3:1521/MOLUDB;User ID=SAHIN;Password=MERT;");
    }



    public List<Ciftlik> GetList()
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

    public Ciftlik GetListForId(int id)
    {
        Ciftlik ciftlik = new Ciftlik();

        using (OracleConnection connection = new OracleConnection(_connectionString))
        {
            connection.Open();
            using (OracleCommand command = new OracleCommand("SELECT * FROM CFKMT001 where CIFTLIKNO=" + id, connection))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {


                    while (reader.Read())
                    {

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

                    }
                }
            }
        }
        return ciftlik;
    }

    public void CiftlikEkle(Ciftlik c)
    {
        OracleConnection connection = new OracleConnection(_connectionString);
        connection.Open();
        int ciftlikno = GetList().Max(o => o.CIFTLIKNO) + 1;
        var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO CFKMT001 (SIRKETNO,CIFTLIKNO,CIFTLIKADI,ADRES,ILCE,IL,TELEFON,FAX,E_MAIL,VERGI_DAIRESI,VERGI_NO,DEPONO,RUHSATNO,ISLETMENO) VALUES(1,{ciftlikno},'{c.CIFTLIKADI}','{c.ADRES}','{c.ILCE}','{c.IL}','{c.TELEFON}','{c.FAX}','{c.E_MAIL}','{c.VERGI_DAIRESI}','{c.VERGI_NO}',{c.DEPONO},'{c.RUHSATNO}','{c.ISLETMENO}')";
        command.ExecuteNonQuery();


    }

    public void CiftlikGuncelleme(Ciftlik c, int ciftlikNo)
    {
        OracleConnection connection = new OracleConnection(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $"UPDATE CFKMT001 SET CIFTLIKADI = '{c.CIFTLIKADI}', ADRES = '{c.ADRES}',ILCE = '{c.ILCE}',IL = '{c.IL}',TELEFON ='{c.TELEFON}',FAX='{c.FAX}',E_MAIL='{c.E_MAIL}'" +
            $",VERGI_DAIRESI = '{c.VERGI_DAIRESI}', VERGI_NO='{c.VERGI_NO}',DEPONO={Convert.ToInt32(c.DEPONO)},RUHSATNO='{c.RUHSATNO}',ISLETMENO= '{c.ISLETMENO}' where CIFTLIKNO = {ciftlikNo}";

        command.ExecuteNonQuery();
    }

    public void CiftlikSil(int id)
    {
        OracleConnection connection = new OracleConnection(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM CFKMT001 WHERE CIFTLIKNO={id}";
        command.ExecuteNonQuery();
    }

    public List<Ciftlik> CiftlikAra(string searchTerm)
    {
        List<Ciftlik> ciftliklist = new List<Ciftlik>();

        using (OracleConnection connection = new OracleConnection(_connectionString))
        {
            connection.Open();
            using (OracleCommand command = new OracleCommand("SELECT * FROM CFKMT001 WHERE UPPER(CIFTLIKADI) LIKE UPPER(:searchTerm) AND LOWER(CIFTLIKADI) LIKE LOWER(:searchTerm)", connection))
            {
                command.Parameters.Add(new OracleParameter("searchTerm", $"%{searchTerm}%"));
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

}









