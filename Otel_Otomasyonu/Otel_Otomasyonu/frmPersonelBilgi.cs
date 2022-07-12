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
    public partial class frmPersonelBilgi : Form
    {
        public frmPersonelBilgi()
        {
            InitializeComponent();
        }

        private void frmPersonelBilgi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select p.Personel_id, p.Personel_ad, p.Personel_soyad, p.Personel_cinsiyet, p.Personel_maas, p.Personel_Telefon, p.Personel_Dtarih, p.Personel_işegiriş_tarihi, p.Personel_İştençıkış_Tarihi, p.Personel_email, p.Personel_KanGrubu, pg.Görev_Adı from Personel p, Personel_Görev pg where p.personel_görev_id = pg.Personel_görev_id ", DataRepo.bag);
            DataTable t = new DataTable();
            adp.Fill(t);
            dataGridView1.DataSource = t;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        void KayıtSil(int personel)
        {
            SqlCommand komut;
            string sql = "DELETE FROM Personel WHERE Personel_id=@personel";
            komut = new SqlCommand(sql, DataRepo.bag);
            komut.Parameters.AddWithValue("@personel", personel);
            DataRepo.bag.Open();
            komut.ExecuteNonQuery();
            DataRepo.bag.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int personel = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(personel);
            }
            Listele();
        }
    }
}
