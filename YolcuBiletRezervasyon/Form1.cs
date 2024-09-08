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

namespace YolcuBiletRezervasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KIMUOA0\SQLEXPRESS;Initial Catalog=DbYolcuBiletRezervasyon;Integrated Security=True");

        void seferListe()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLSEFERBILGI", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void yolcuListe()
        {
            SqlDataAdapter da = new SqlDataAdapter("select SEFERNO,YOLCUTC,KOLTUK from TBLSEFERDETAY", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        void seferSayisiGuncelle()
        {
            SqlCommand komut = new SqlCommand("select count(*) from TBLSEFERBILGI", baglanti);
            baglanti.Open();
            int seferSayisi = (int)komut.ExecuteScalar();
            textBoxSEFERSAYISI.Text = seferSayisi.ToString();
            baglanti.Close();
        }

        void yolcuSayisiGuncelle()
        {
            SqlCommand komut = new SqlCommand("select count(*) from TBLKISIBILGI", baglanti);
            baglanti.Open();
            int yolcuSayisi = (int)komut.ExecuteScalar();
            textBoxYOLCUSAYISI.Text = yolcuSayisi.ToString();
            baglanti.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKISIBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", textBoxAD.Text);
            komut.Parameters.AddWithValue("@P2", textBoxSOYAD.Text);
            komut.Parameters.AddWithValue("@P3", maskedTextBoxTEL.Text);
            komut.Parameters.AddWithValue("@P4", maskedTextBoxTC.Text);
            komut.Parameters.AddWithValue("@P5", comboBoxCINSIYET.Text);
            komut.Parameters.AddWithValue("@P6", textBoxMAIL.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu bilgileri sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TextBox ve MaskedTextBox'ları temizle
            textBoxAD.Text = "";
            textBoxSOYAD.Text = "";
            maskedTextBoxTEL.Text = "";
            maskedTextBoxTC.Text = "";
            comboBoxCINSIYET.SelectedIndex = -1; // ComboBox'u sıfırlamak için
            textBoxMAIL.Text = "";

            // Yolcu sayısını güncelle
            yolcuSayisiGuncelle();
        }

        private void btnKaptanKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKAPTANBILGI (KAPTANNO,ADSOYAD,TELEFON) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", maskedTextBoxKAPTANNO.Text);
            komut.Parameters.AddWithValue("@P2", textBoxKAPTANADSOYAD.Text);
            komut.Parameters.AddWithValue("@P3", maskedTextBoxKAPTANTEL.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan bilgileri sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            maskedTextBoxKAPTANNO.Text = "";
            textBoxKAPTANADSOYAD.Text = "";
            maskedTextBoxKAPTANTEL.Text = "";
        }

        private void btnSeferOlustur_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT) values (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", textBoxKALKIS.Text);
            komut.Parameters.AddWithValue("@P2", textBoxVARIS.Text);
            komut.Parameters.AddWithValue("@P3", maskedTextBoxTARIH.Text);
            komut.Parameters.AddWithValue("@P4", maskedTextBoxSAAT.Text);
            komut.Parameters.AddWithValue("@P5", maskedTextBoxKAPTAN.Text);
            komut.Parameters.AddWithValue("@P6", textBoxFIYAT.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer bilgileri sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);

            seferListe();
            yolcuListe();
            seferSayisiGuncelle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferListe();
            yolcuListe();
            seferSayisiGuncelle();
            yolcuSayisiGuncelle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxYOLCUSEFERNO.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "9";
        }

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            // Yolcu TC'nin daha önce TBLKISIBILGI tablosuna girilmiş olup olmadığını kontrol et
            SqlCommand kontrolKomutu = new SqlCommand("select count(*) from TBLKISIBILGI where TC = @P2", baglanti);
            kontrolKomutu.Parameters.AddWithValue("@P2", maskedTextBoxYOLCUTC.Text);
            int yolcuVarMi = (int)kontrolKomutu.ExecuteScalar();

            if (yolcuVarMi == 0)
            {
                MessageBox.Show("Bu TC kimlik numarası sistemde kayıtlı değil. Lütfen geçerli bir yolcu TC kimlik numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Yolcu zaten kayıtlıysa rezervasyon yapılır
                SqlCommand komut = new SqlCommand("insert into TBLSEFERDETAY (SEFERNO,YOLCUTC,KOLTUK) values (@P1,@P2,@P3)", baglanti);
                komut.Parameters.AddWithValue("@P1", textBoxYOLCUSEFERNO.Text);
                komut.Parameters.AddWithValue("@P2", maskedTextBoxYOLCUTC.Text);
                komut.Parameters.AddWithValue("@P3", textBoxKOLTUKNO.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Rezervasyon Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                seferListe();
                yolcuListe();
            }

            baglanti.Close();
        }


        private void textBoxYOLCUSAYISI_TextChanged(object sender, EventArgs e)
        {
            // Yolcu sayısı textbox'ında değişiklik olduğunda otomatik olarak güncelleme sağlanır.
        }

        private void textBoxSEFERSAYISI_TextChanged(object sender, EventArgs e)
        {
            // Sefer sayısı textbox'ında değişiklik olduğunda otomatik olarak güncelleme sağlanır.
        }

        private void maskedTextBoxYOLCUTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Yolcu TC'nin girilmesi sırasında maskeli giriş hatası olursa burada yakalanabilir.
        }
    }
}
