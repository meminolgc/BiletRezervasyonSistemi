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

namespace BiletRezervasyon_KayıtSistemi
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		void seferListesi()
		{
			SqlDataAdapter da = new SqlDataAdapter("Select * From Tblseferbılgı", baglanti);
			DataTable dt = new DataTable();
			da.Fill(dt);
			dataGridView1.DataSource = dt;	
		}

		SqlConnection baglanti = new SqlConnection(@"Data Source=emin\SQLEXPRESS;Initial Catalog=BiletRezervasyonDb;Integrated Security=True;Encrypt=False");
		private void BtnKaydet_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("insert into tblyolcubılgı (ad,soyad,telefon,tc,cınsıyet,maıl) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
			komut.Parameters.AddWithValue("@p1", TxtAd.Text);
			komut.Parameters.AddWithValue("@p2", MskSoyad.Text);
			komut.Parameters.AddWithValue("@p3", MskTel.Text);
			komut.Parameters.AddWithValue("@p4", MskTC.Text);
			komut.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
			komut.Parameters.AddWithValue("@p6", MskMail.Text);
			komut.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Yolcu Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void BtnKaptan_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("insert into tblkaptan (kaptanno,adsoyad,telefon) values (@p1,@p2,@p3)", baglanti);
			komut.Parameters.AddWithValue("@p1", TxtKaptanNo.Text);
			komut.Parameters.AddWithValue("@p2", TxtKaptanAd.Text);
			komut.Parameters.AddWithValue("@p3", MskKaptanTel.Text);
			komut.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Kaptan Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("insert into tblseferbılgı (kalkıs,varıs,tarıh,saat,kaptan,fıyat) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
			komut.Parameters.AddWithValue("@p1", MskKalkis.Text);
			komut.Parameters.AddWithValue("@p2", MskVaris.Text);
			komut.Parameters.AddWithValue("@p3", MskTarih.Text);
			komut.Parameters.AddWithValue("@p4", MskSaat.Text);
			komut.Parameters.AddWithValue("@p5", MskKaptan.Text);
			komut.Parameters.AddWithValue("@p6", MskFiyat.Text);
			komut.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			seferListesi();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			seferListesi();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int secilen = dataGridView1.SelectedCells[0].RowIndex;

			TxtSeferNo.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

		}

		private void Btn1_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "1";
		}

		private void Btn2_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "2";
		}

		private void Btn3_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "3";
		}

		private void Btn4_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "4";
		}

		private void Btn5_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "5";
		}

		private void Btn6_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "6";
		}

		private void Btn7_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "7";
		}

		private void Btn8_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "8";
		}

		private void Btn9_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "9";
		}

		private void BtnRez_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("insert into seferdetay (seferno,yolcutc,koltuk) values (@p1,@p2,@p3)", baglanti);
			komut.Parameters.AddWithValue("@p1", TxtSeferNo.Text);
			komut.Parameters.AddWithValue("@p2", MskYolcuTC.Text);
			komut.Parameters.AddWithValue("@p3", TxtKoltukNo.Text);
			komut.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Rezervasyon işlemi tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			//rezervasyon işlemi yapıldığında koltuk renklerini değiştir.
		}
	}
}
