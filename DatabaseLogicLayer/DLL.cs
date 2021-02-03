using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogicLayer
{
    public class DLL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        int ReturnValues=0;
        public DLL()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=TelefonRehberi;Trusted_Connection=True");

        }
        public void BaglantiAyarla()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }
        public int SistemKontrol(Kullanici k)
        {
            try
            {
                cmd = new SqlCommand($"select count(*) from Kullanici where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre",con);
                cmd.Parameters.AddWithValue("@KullaniciAdi", k.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Sifre", k.Sifre);
                BaglantiAyarla();
                ReturnValues = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {


            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }
        public int KayitEkle(Rehber r1)
        {
            try
            {
                cmd = new SqlCommand("insert into Rehber(ID,Isim,Soyisim,TelefonNumarasiI,TelefonNumarasiII,TelefonNumarasiIII,EmailAdres,WebAdres,Adres,Aciklama) values (@ID,@Isim,@Soyisim,@TelfonNumarasiI,@TelefonNumarasiII,@TelefonNumarasiIII,@EmailAdres,@WebAdres,@Adres,@Aciklama)", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = r1.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = r1.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = r1.Soyisim;
                cmd.Parameters.Add("@TelfonNumarasiI", SqlDbType.NVarChar).Value = r1.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = r1.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = r1.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = r1.EmailAdres;
                cmd.Parameters.Add("@WebAdres", SqlDbType.NVarChar).Value = r1.WebAdres;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = r1.Adres;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = r1.Aciklama;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();




            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;

        }

        public int KayitDuzenle(Rehber r1)
        {
            try
            {
                cmd = new SqlCommand(@"update Rehber set
Isim = @Isim,
Soyisim = @Soyisim,
TelefonNumarasiI=@TelefonNumarasiI,
TelefonNumarasiII=@TelefonNumarasiII,
TelefonNumarasiIII=@TelefonNumarasiIII,
EmailAdres=@EmailAdres,
WebAdres=@WebAdres,
Aciklama = @Aciklama
where
ID = @ID", con);


                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = r1.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = r1.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = r1.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = r1.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = r1.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = r1.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = r1.EmailAdres;
                cmd.Parameters.Add("@WebAdres", SqlDbType.NVarChar).Value = r1.WebAdres;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = r1.Adres;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = r1.Aciklama;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {


            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public int KayitSil(Guid ID)
        {
            try
            {
                cmd = new SqlCommand(@"delete Rehber
where ID = @ID ", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {


            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }
        public SqlDataReader KayitListe()
        {
            cmd = new SqlCommand("Select * from Rehber", con);
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }
        public SqlDataReader KayitListeID(Guid ID)
        {
            cmd = new SqlCommand("Select * from Rehber where ID = @ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }


    }
}
