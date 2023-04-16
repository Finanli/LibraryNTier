using Business;
using Entity;
using Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KutuphaneKatmanlı
{
    public partial class Kitap : Form
    {
        public Kitap()
        {
            InitializeComponent();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FKitap.KitapListe();
        }

        private void kaydb_Click(object sender, EventArgs e)
        {
            EKitap ekle = new EKitap();
            ekle.kitapadi = textBox1.Text;
            ekle.yazaradi = textBox2.Text;
            ekle.sayfasayi = Convert.ToInt32(textBox3.Text);
            ekle.konu = textBox4.Text;
            ekle.yayinevi = textBox5.Text;

            if (BLEKitap.KEkle(ekle) == true)
            {
                MessageBox.Show("Başarılı!");
            }
            else
            {
                MessageBox.Show("Başarısız!");
            }
            dataGridView1.DataSource = FKitap.KitapListe();
        }

        private void yenileb_Click(object sender, EventArgs e)
        {
            EKitap yenile = new EKitap();
            yenile.kitapno = Convert.ToInt32(textBox1.Tag);
            yenile.kitapadi = textBox1.Text;
            yenile.yazaradi = textBox2.Text;
            yenile.sayfasayi = Convert.ToInt32(textBox3.Text);
            yenile.konu = textBox4.Text;
            yenile.yayinevi = textBox5.Text;
            if (!FKitap.KitapGuncelle(yenile))
            {
                MessageBox.Show("Güncellenemedi! Tekrar Dene!!");
            }

            dataGridView1.DataSource = FKitap.KitapListe();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["kitapno"].Value.ToString();
            textBox1.Text = row.Cells["kitapadi"].Value.ToString();
            textBox2.Text = row.Cells["yazaradi"].Value.ToString();
            textBox3.Text = row.Cells["sayfasayi"].Value.ToString();
            textBox4.Text = row.Cells["konu"].Value.ToString();
            textBox5.Text = row.Cells["yayinevi"].Value.ToString();

        }

        private void silb_Click(object sender, EventArgs e)
        {
            EKitap sil = new EKitap();
            sil.kitapno = Convert.ToInt32(textBox1.Tag);
            if (!FKitap.KitapSil(sil))
            {
                MessageBox.Show("Silinemedi....");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlKitap xmlKitap = new XmlKitap();
            this.Hide();
            xmlKitap.Show();
            
        }

    }
}
