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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
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
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *  from TBL_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskdTC.Text);
            komut.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreter fr = new FrmSekreter();
                fr.tc = mskdTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen bilgilerinizi kontrol edin.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            bgl.baglanti().Close();

        }

        private void mskdTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
