using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_and_Appointment_System_Automation
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            tc = mskdTC.Text;
            SqlCommand komut = new SqlCommand("Select * from TBL_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskdTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTel.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmdCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update  TBL_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTel.Text);
            komut2.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmdCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", mskdTC.Text);
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);



        }
    }
}
