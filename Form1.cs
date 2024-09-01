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

namespace StokKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-D97CNQAS\MSQLSERVER; Initial Catalog=StokYonetim; Integrated Security=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { //EKLE
            String t1 = textBox1.Text; //Malzeme kodu
            String t2 = textBox2.Text; //Malzeme adı
            String t3 = textBox3.Text; //Yıllık satış
            String t4 = textBox4.Text; //Bitim fiyat
            String t5 = textBox5.Text; //Min stok
            String t6 = textBox6.Text; //Temin süresi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler (MalzemeKodu, MalzemeAdi, YillikSatis, BirimFiyat, MinStok, TSuresi) VALUES ('"+t1+ "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele() // Veri tabanındaki kayıtların görüntülenmesi amacıyla
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Malzemeler",baglanti);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {//SİL
            String t1 = textBox1.Text; //Seçilen satırın malzeme kodunu alır
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('" + t1 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {//GÜNCELLE
            String t1 = textBox1.Text; //Malzeme kodu
            String t2 = textBox2.Text; //Malzeme adı
            String t3 = textBox3.Text; //Yıllık satış
            String t4 = textBox4.Text; //Bitim fiyat
            String t5 = textBox5.Text; //Min stok
            String t6 = textBox6.Text; //Temin süresi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='"+t1+ "',MalzemeAdi='" + t2 + "',YillikSatis='" + t3 + "',BirimFiyat='" + t4 + "',MinStok='" + t5 + "',TSuresi='" + t6 + "' WHERE MalzemeKodu='"+t1+"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
    }
}
