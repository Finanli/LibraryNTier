using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Entity;
using Facade;


namespace KutuphaneKatmanlı
{
    public partial class UyeEkrani : Form
    {
        public UyeEkrani()
        {
            InitializeComponent();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FUye.Listele();
            label5.Visible = true;
            textBox2.Visible = true;
        }



        private void kaydb_Click(object sender, EventArgs e)
        {
            
            EUye ekle = new EUye();
            ekle.uyeAdi = textBox1.Text;
            ekle.uyelikT = maskedTextBox1.Text;
            ekle.dogumT = maskedTextBox2.Text;
            ekle.meslek = textBox4.Text;

            if (BLEKitap.UEkle(ekle) == true)
            {
                MessageBox.Show("Başarılı");
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
            dataGridView1.DataSource = FUye.Listele();
        }

        private void yenileb_Click(object sender, EventArgs e)
        {
            EUye yenile = new EUye();
            yenile.uyeNo = Convert.ToInt32(textBox2.Text);
            yenile.uyeAdi = textBox1.Text;
            yenile.uyelikT = maskedTextBox1.Text;
            yenile.dogumT = maskedTextBox2.Text;
            yenile.meslek = textBox4.Text;

            if (!FUye.Guncelle(yenile))
            {
                MessageBox.Show("Güncellenemedi!!");
            }
            dataGridView1.DataSource = FUye.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Visible = true;
            textBox2.Visible = true;

            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox2.Text = row.Cells["uyeNo"].Value.ToString();
            textBox1.Text = row.Cells["uyeAdi"].Value.ToString();
            maskedTextBox1.Text = row.Cells["uyelikT"].Value.ToString();
            maskedTextBox2.Text = row.Cells["dogumT"].Value.ToString();
            textBox4.Text = row.Cells["meslek"].Value.ToString();

        }

        private void silb_Click(object sender, EventArgs e)
        {
            EUye sil = new EUye();
            sil.uyeNo = Convert.ToInt32(textBox2.Text);
            if (!FUye.Sil(sil))
            {
                MessageBox.Show("Silinemedi!!");
            }
            dataGridView1.DataSource = FUye.Listele();
        }

        private void UyeEkrani_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            textBox2.Visible = false;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //SqlDateTime dt = Convert.ToDateTime(maskedTextBox1.Text);
            //maskedTextBox1.Tag = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            XmlUye xmlUye = new XmlUye();
            this.Hide();
            
            xmlUye.Show();
        }
    }
}
