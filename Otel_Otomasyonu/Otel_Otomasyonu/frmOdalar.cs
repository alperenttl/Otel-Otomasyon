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
    public partial class frmOdalar : Form
    {
        public frmOdalar()
        {
            InitializeComponent();
        }

        private void frmOdalar_Load(object sender, EventArgs e)
        {
            musteriGetir();
            odaTurGetir();
        }

        public void musteriGetir()
        {
                SqlDataAdapter da = new SqlDataAdapter("select * from Musteri", DataRepo.bag);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Musteri_adi";
                comboBox1.ValueMember = "Müsteri_id";
          
        }
        public void odaTurGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Oda_tür", DataRepo.bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DisplayMember = "Tür_adı";
            comboBox2.ValueMember = "tür_id";
            comboBox2.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand hesap = new SqlCommand("insert into Musteri_hesap(musteri_no, oda_no, giris_tarihi, cikis_tarihi, kisi_sayisi) values (@p1,@p2,@p3,@p4,@p5)", DataRepo.bag);
            hesap.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
            hesap.Parameters.AddWithValue("@p2", comboBox3.SelectedValue);
            hesap.Parameters.AddWithValue("@p3", Convert.ToDateTime(dateTimePicker1.Text));
            hesap.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateTimePicker2.Text));
            hesap.Parameters.AddWithValue("@p5", textBox10.Text);
            DataRepo.bag.Open();

            hesap.ExecuteNonQuery();

            DataRepo.bag.Close();
            MessageBox.Show("Oda rezerve edildi");
        }

        public void odaGetir() 
        {
            int secilenTur = Convert.ToInt32(comboBox2.SelectedValue);

            SqlDataAdapter komut = new SqlDataAdapter("SELECT * FROM Oda WHERE Oda_Tür_İd='" + secilenTur +"'", DataRepo.bag);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            comboBox3.DisplayMember = "OdaNo";
            comboBox3.ValueMember = "Oda_id";
            comboBox3.DataSource = dt;


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            odaGetir();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilenOda = Convert.ToInt32(comboBox3.SelectedValue);
            DataRepo.bag.Open();
            SqlCommand komut = new SqlCommand("SELECT Oda_kat, Oda_fiyat FROM Oda WHERE Oda_id='" + secilenOda + "'", DataRepo.bag);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Oda_kat"].ToString();
                textBox2.Text = dr["Oda_fiyat"].ToString();

            }
            dr.Close();
            DataRepo.bag.Close();

        }
    }
}
