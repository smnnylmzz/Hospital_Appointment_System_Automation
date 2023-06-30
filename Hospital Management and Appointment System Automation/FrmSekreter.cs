using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Hospital_Management_and_Appointment_System_Automation
{
    public partial class FrmSekreter : Form
    {
        public FrmSekreter()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmSekreter_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;


            // Ad Soyad çekme
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From TBL_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", tc); // tc değişkenini @p1 parametresine ata
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString(); // lblAdSoyad.Text'i dr1[0]'dan al
            }
            bgl.baglanti().Close();

            //Branşı comboxa atama
            SqlCommand komut2 = new SqlCommand("Select BransAd From TBL_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmdBrans.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();

            //Branş Listesini Aktarma

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            // Doktorları DataGride Aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar', DoktorBrans from TBL_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into TBL_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1",mskdTarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", mskdSaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmdBrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmdDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturulmuştur","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void cmdBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from TBL_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",cmdBrans.Text);
            SqlDataReader dr = komut3.ExecuteReader();
            while (dr.Read())
            {
                cmdDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut4 = new SqlCommand("insert into TBL_Duyuru (Duyuru) values (@d1)", bgl.baglanti());
            komut4.Parameters.AddWithValue("@d1",rchDuyuru.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        private void btnDoktor_Click(object sender, EventArgs e)
        {
            FrmDoktorPanel drp = new FrmDoktorPanel();
            drp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGiris fr = new frmGiris();
            fr.Show();
            this.Hide();
        }

        private void btnBrans_Click(object sender, EventArgs e)
        {
            FrmBransPaneli fr = new FrmBransPaneli();
            fr.Show();
        }

        private void btnRandevuList_Click(object sender, EventArgs e)
        {
            FrmRandevular fr = new FrmRandevular();
            fr.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Duyurular fr = new Duyurular();
            fr.Show();
        }
    }
}
