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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCNo;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskdTC.Text = TCNo;
            SqlCommand komut = new SqlCommand("Select * from TBL_Doktorlar where DoktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mskdTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmdBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[4].ToString();

            }
            bgl.baglanti().Close();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2",txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmdBrans.Text);
            komut.Parameters.AddWithValue("@p4",txtSifre.Text);
            komut.Parameters.AddWithValue("@p4", mskdTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }
    }
}
