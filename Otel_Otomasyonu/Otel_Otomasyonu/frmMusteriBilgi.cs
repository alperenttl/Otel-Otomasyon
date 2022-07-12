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
    public partial class frmMusteriBilgi : Form
    {
        public frmMusteriBilgi()
        {
            InitializeComponent();
        }

        void Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select mus.Müsteri_id, mus.Musteri_adi, mus.Musteri_soyad, mus.Musteri_Tc, mus.Musteri_telefon, mus.Musteri_uyruk, mus.Musteri_cinsiyet, mus.Musteri_adres, mus.Musteri_kan, mus.Musteri_eposta, i.iller, ic.ilceler " +
            "from Musteri mus, il i, ilce ic where mus.Il = i.il_id and mus.Ilce = ic.ilce_id", DataRepo.bag);
            DataTable t = new DataTable();
            adp.Fill(t);
            dataGridView1.DataSource = t;

            comboBox1.DataSource = t;
            comboBox1.DisplayMember = "Musteri_adi";
            comboBox1.ValueMember = "Müsteri_id";
        }
        private void frmMusteriBilgi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Musteri where Müsteri_id=@p1", DataRepo.bag);
            adp.SelectCommand.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
            DataTable t = new DataTable();
            adp.Fill(t);
        }
        private void KayıtSil(int müsteri)
        {
            SqlCommand komut2;
            string sql = "DELETE FROM Musteri WHERE Müsteri_id=@müsteri";
            komut2 = new SqlCommand(sql, DataRepo.bag);
            komut2.Parameters.AddWithValue("@müsteri", müsteri);
            DataRepo.bag.Open();
            komut2.ExecuteNonQuery();
            DataRepo.bag.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int müsteri = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(müsteri);
            }
            Listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMusteriOdaBilgi frmMusteriOdaBilgi = new frmMusteriOdaBilgi();
            frmMusteriOdaBilgi.ShowDialog();
        }
    }
}
