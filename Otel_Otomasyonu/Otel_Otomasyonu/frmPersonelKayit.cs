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
    public partial class frmPersonelKayit : Form
    {
        public frmPersonelKayit()
        {
            InitializeComponent();
        }
        void TextTemizle()
        {
            foreach (var item in this.Controls) // Form üzerindeki tüm Controllerin bir döngüyle Değişkene atanması
            {
                if (item is TextBox) // Bu değişkene atanan değerler içerisinde Textbox olanların ayıklanması
                {
                    TextBox t = item as TextBox; // Textbox controlünün .Text gibi özelliklerine erişmek için Textbox türünden türetilen nesnemizin itemden gelen textboxların değerini alması
                    t.Clear();  // itemden gelen textlerin Textbox gibi davranacağı  (yani .Text gibi özelliklerine erişebileceğimiz halinin) .Clear() özelliği ile temizlenmesi
                }
            }// tüm işlemler bir döngü içerisinde yapıldığından mantıken tüm textboxların içinin Clear methoduna tabi tutulması
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            DataRepo.bag.Open();
            SqlCommand komut = new SqlCommand("insert into Personel ([Personel_ad],[Personel_soyad],[Personel_cinsiyet]," +
                "[Personel_maas],[Personel_Telefon],[Personel_Dtarih],[Personel_işegiriş_tarihi],[Personel_İştençıkış_Tarihi],[Personel_email], [Personel_KanGrubu], [personel_görev_id]) " +
                "values (@Personel_ad,@Personel_soyad, @Personel_cinsiyet,@Personel_maas,@Personel_Telefon,@Personel_Dtarih," +
                "@Personel_işegiriş_tarihi,@Personel_İştençıkış_Tarihi ,@Personel_email, @Personel_KanGrubu, @personel_görev_id)", DataRepo.bag);
            komut.Parameters.AddWithValue("@Personel_ad", textBox1.Text);
            komut.Parameters.AddWithValue("@Personel_soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@Personel_cinsiyet", textBox3.Text);
            komut.Parameters.AddWithValue("@Personel_maas", textBox4.Text);
            komut.Parameters.AddWithValue("@Personel_Telefon", textBox5.Text);
            komut.Parameters.AddWithValue("@Personel_Dtarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@Personel_işegiriş_tarihi", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@Personel_İştençıkış_Tarihi", dateTimePicker3.Value);
            komut.Parameters.AddWithValue("@Personel_email", textBox6.Text);
            komut.Parameters.AddWithValue("@Personel_KanGrubu", textBox7.Text);
            komut.Parameters.AddWithValue("@personel_görev_id", comboBox1.SelectedValue);
            komut.ExecuteNonQuery();
            DataRepo.bag.Close();
            MessageBox.Show("Personel Bilgileri Kaydedildi");
            TextTemizle();
        }

        private void frmPersonelKayit_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Personel_Görev", DataRepo.bag);
            DataTable t = new DataTable();
            ad.Fill(t);
            comboBox1.DataSource = t;
            comboBox1.DisplayMember ="Görev_Adı";
            comboBox1.ValueMember ="Personel_Görev_İd";
        }
    }
}
