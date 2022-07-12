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
    public partial class frmsSiparisBilgi : Form
    {
        public frmsSiparisBilgi()
        {
            InitializeComponent();
        }

        private void frmsSiparisBilgi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select s.id, mus.Musteri_adi, mus.Musteri_soyad, s.hesap, m.menu_adı, s.siparis_tarihi FROM Siparis s, Menu m, Musteri mus, Musteri_hesap mh WHERE s.menu_id = m.menu_id AND s.hesap_no = mh.islem_no AND  mh.musteri_no = mus.Müsteri_id", DataRepo.bag);
            DataTable t = new DataTable();
            adp.Fill(t);
            dataGridView1.DataSource = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        void KayıtSil(int siparis)
        {
            SqlCommand komut;
            string sql = "DELETE FROM Siparis WHERE id=@p1";
            komut = new SqlCommand(sql, DataRepo.bag);
            komut.Parameters.AddWithValue("@p1", siparis);
            DataRepo.bag.Open();
            komut.ExecuteNonQuery();
            DataRepo.bag.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int siparis = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(siparis);
            }
            Listele();
        }

    }
}
