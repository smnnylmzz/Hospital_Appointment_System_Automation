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
    public partial class FrmDoktorPanel : Form
    {
        public FrmDoktorPanel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmDoktorPanel_Load(object sender, EventArgs e)
        {
            // Doktorları DataGride Aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBL_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",txtAd.Text);
            komut.Parameters.AddWithValue("d2", txtSoyad.Text);
            komut.Parameters.AddWithValue("d3", cmdBrans.Text);
            komut.Parameters.AddWithValue("d4", mskdTC.Text);
            komut.Parameters.AddWithValue("d5", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmdBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskdTC.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Delete from TBL_Doktorlar where DoktorTC=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",mskdTC.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt silindi..","Silme",MessageBoxButtons.OK,MessageBoxIcon.Information); 
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update TBL_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4",bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1", txtAd.Text);
            komut2.Parameters.AddWithValue("d2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("d3", cmdBrans.Text);
            komut2.Parameters.AddWithValue("d4", mskdTC.Text);
            komut2.Parameters.AddWithValue("d5", txtSifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand komut2 = new SqlCommand("Select BransAd From TBL_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmdBrans.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();
        }
    }
}
