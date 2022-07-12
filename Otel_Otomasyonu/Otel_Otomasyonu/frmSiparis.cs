using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Otomasyonu
{
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        private void frmSiparis_Load(object sender, EventArgs e)
        {
            musteriGetir();
            menu1Getir();
            menu2Getir();
            menu3Getir();
            menu4Getir();
            DataRepo.bag.Open();
            SqlCommand komut = new SqlCommand("SELECT menu_id, menu_fiyat FROM Menu ", DataRepo.bag);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if(dr["menu_id"].ToString() == "1")
                {
                    textBox2.Text = dr["menu_fiyat"].ToString();

                }else if (dr["menu_id"].ToString() == "2")
                {
                    textBox3.Text = dr["menu_fiyat"].ToString();

                }
                else if(dr["menu_id"].ToString() == "3")
                {
                    textBox4.Text = dr["menu_fiyat"].ToString();

                }else if(dr["menu_id"].ToString() == "4")
                {
                    textBox5.Text = dr["menu_fiyat"].ToString();

                }

            }
            dr.Close();
            DataRepo.bag.Close();

        }

        public void musteriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select mh.islem_no as islemNo, CONCAT(m.Musteri_adi, ' ', m.Musteri_soyad) as musteri FROM Musteri m LEFT JOIN Musteri_hesap mh ON mh.musteri_no = m.Müsteri_id", DataRepo.bag);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DisplayMember = "musteri";
            comboBox1.ValueMember = "islemNo";
            comboBox1.DataSource = dt;

        }


        public void menu1Getir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Menu_icerik WHERE menu_id=1", DataRepo.bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            menu_1.DisplayMember = "menu_icerik";
            menu_1.ValueMember = "menu_id";
            menu_1.DataSource = dt;
    
        }
        public void menu2Getir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Menu_icerik WHERE menu_id=2", DataRepo.bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            menu_2.DisplayMember = "menu_icerik";
            menu_2.ValueMember = "menu_id";
            menu_2.DataSource = dt;

        }
        public void menu3Getir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Menu_icerik WHERE menu_id=3", DataRepo.bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            menu_3.DisplayMember = "menu_icerik";
            menu_3.ValueMember = "menu_id";
            menu_3.DataSource = dt;

        }
        public void menu4Getir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Menu_icerik WHERE menu_id=4", DataRepo.bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            menu_4.DisplayMember = "menu_icerik";
            menu_4.ValueMember = "menu_id";
            menu_4.DataSource = dt;

        }


        private void button2_Click(object sender, EventArgs e)
        {

            int hesap = 0;
            if (checkBox1.Checked)
            {
                hesap = hesap + Convert.ToInt32(Regex.Match(textBox2.Text, @"\d+").Value);
            }
            if (checkBox2.Checked)
            {
                hesap = hesap + Convert.ToInt32(Regex.Match(textBox3.Text, @"\d+").Value);

            }
            if (checkBox3.Checked)
            {
                hesap = hesap + Convert.ToInt32(Regex.Match(textBox4.Text, @"\d+").Value);

            }
            if (checkBox4.Checked)
            {
                hesap = hesap + Convert.ToInt32(Regex.Match(textBox5.Text, @"\d+").Value);

            }

            textBox1.Text = hesap.ToString() + "TL";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmsSiparisBilgi frmsSiparisBilgi = new frmsSiparisBilgi();
            frmsSiparisBilgi.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4 };
            TextBox[] fiyatlar = { textBox2, textBox3, textBox4, textBox5 };
            DateTime tarih = DateTime.Now;
            
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    SqlCommand komut = new SqlCommand("insert into Siparis(hesap_no, menu_id, hesap, siparis_tarihi) values (@p1,@p2,@p3,@p4)", DataRepo.bag);

                    komut.Parameters.AddWithValue("@p1", comboBox1.SelectedValue);
                    komut.Parameters.AddWithValue("@p2", (i+1).ToString());
                    komut.Parameters.AddWithValue("@p3", fiyatlar[i].Text);
                    komut.Parameters.AddWithValue("@p4", tarih);
                    DataRepo.bag.Open();

                    komut.ExecuteNonQuery();
                    DataRepo.bag.Close();
                }
            }

            MessageBox.Show("Sipariş Bilgileri Kaydedildi");
        }
    }
}
