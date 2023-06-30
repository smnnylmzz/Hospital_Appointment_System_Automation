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
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            frmGiris fr = new frmGiris();
            fr.Show();
            this.Hide();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("insert into TBL_Branslar (BransAd) values (@b1)",bgl.baglanti());
            komut3.Parameters.AddWithValue("@b1", txtBransad.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş eklendi", "Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtbransıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBransad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut4 = new SqlCommand("delete from TBL_Branslar where BransId=@b1",bgl.baglanti());
            komut4.Parameters.AddWithValue("@b1", txtbransıd.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt silinmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand("Update TBL_Branslar set BransAd=@p1 where BransId=@p2",bgl.baglanti());
            komut5.Parameters.AddWithValue("@p1",txtBransad.Text);
            komut5.Parameters.AddWithValue("@p2", txtbransıd.Text);
            komut5.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
