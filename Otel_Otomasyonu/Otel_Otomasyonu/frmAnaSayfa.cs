namespace Otel_Otomasyonu
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           MusteriKayitfrm frmMusteriKayit = new MusteriKayitfrm();
            frmMusteriKayit.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPersonelKayit frmPersonelKayit = new frmPersonelKayit();
            frmPersonelKayit.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMusteriBilgi frmMusteriBilgi = new frmMusteriBilgi();
            frmMusteriBilgi.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPersonelBilgi frmPersonelBilgi = new frmPersonelBilgi();
            frmPersonelBilgi.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmOdalar frmOdalar = new frmOdalar();
            frmOdalar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            frmSiparis.ShowDialog();
        }
    }
}