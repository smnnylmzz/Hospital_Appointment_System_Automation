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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            frmGiris fr = new frmGiris();
            fr.Show();
            this.Hide();
        }
        

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {
            
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskdTC.Text);
            komut.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.TC = mskdTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı T.C. No veya Şifre girdiniz. Lütfen bilgilerinizi kontrol ediniz..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }
    }
}
