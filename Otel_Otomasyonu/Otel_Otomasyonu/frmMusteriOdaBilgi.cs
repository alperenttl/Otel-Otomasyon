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

namespace Otel_Otomasyonu
{
    public partial class frmMusteriOdaBilgi : Form
    {
        public frmMusteriOdaBilgi()
        {
            InitializeComponent();
        }


        void Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select mus.islem_no, m.Müsteri_id, o.odaNo, m.Musteri_adi, m.Musteri_soyad,ot.Tür_adı, o.Oda_fiyat, mus.giris_tarihi, mus.cikis_tarihi, mus.kisi_sayisi from Musteri m , Musteri_hesap mus, Oda o, Oda_tür ot WHERE m.Müsteri_id = mus.musteri_no and mus.oda_no = o.Oda_id and o.Oda_Tür_id = ot.tür_id", DataRepo.bag);
            DataTable t = new DataTable();
            adp.Fill(t);
            dataGridView1.DataSource = t;

            comboBox1.DataSource = t;
            comboBox1.DisplayMember = "Musteri_adi";
            comboBox1.ValueMember = "Müsteri_id";
        }
        private void frmMusteriOdaBilgi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();

        }
        void KayıtSil(int oda)
        {
            SqlCommand komut;
            string sql = "DELETE FROM Musteri_hesap WHERE islem_no=@p1";
            komut = new SqlCommand(sql, DataRepo.bag);
            komut.Parameters.AddWithValue("@p1", oda);
            DataRepo.bag.Open();
            komut.ExecuteNonQuery();
            DataRepo.bag.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int oda = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(oda);
            }
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
