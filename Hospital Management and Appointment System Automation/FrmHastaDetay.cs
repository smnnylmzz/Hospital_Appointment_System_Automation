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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_Randevular set RandevuDurum=1,HastaTC=@k1,HastaSikayet=@k2 where RandevuId=@k3",bgl.baglanti());
            komut.Parameters.AddWithValue("@k1",lblTC.Text);
            komut.Parameters.AddWithValue("@k2", rchSikayet.Text);
            komut.Parameters.AddWithValue("@k3",txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu kaydı oluşturulmuştur. Lütfen Randevu saatinden 10 dakika önce ilgili poliklinik önünde bulununuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;
            //Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from TBL_Hastalar where HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] +" "+ dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_Randevular where HastaTC="+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from TBL_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Doktorları Çekme
            cmbDoktor.Items.Clear();

            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from TBL_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",cmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0]+ " " + dr3[1]);
            }
            bgl.baglanti().Close();

        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_Randevular where  RandevuBrans='" + cmbBrans.Text + "'" + " and RandevuDoktor='"+cmbDoktor.Text+"' and RandevuDurum=0",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource= dt;
        }

        private void lnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmGiris fr = new frmGiris();
            fr.Show();
            this.Hide();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }
    }
}
 