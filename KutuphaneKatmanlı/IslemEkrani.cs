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
using Entity;
using System.Collections;
using Business;

//using System.Data.SqlClient;

namespace KutuphaneKatmanlı
{
    public partial class IslemEkrani : Form
    {
        public IslemEkrani()
        {
            InitializeComponent();
        }


        //private void BindComboBox()
        //{
        //    FUye fUye = new FUye();

        //    ComboBox cmb = comboBox2;


        //    //cmb.Items.Add(fUye);

        //    cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
        //    cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        //    comboBox2.Items.Add(cmb);

        //    cmb.DataSource = fUye.FetchData();
        //    cmb.DisplayMember = fUye.FetchData().Columns["uyeadi"].Expression;
        //    cmb.ValueMember = "uyeno";

        //}

        private void IslemEkrani_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            //BindComboBox();

            //EUye uye = new EUye();
            ////comboBox2.DataSource = FUye.Listele().Columns[]
            ////comboBox2.Items.Add((FUye.Listele().Cells[""]);
            //////comboBox2.Items.AddRange(FUye.Listele().Columns["uyeadi"].ColumnName);
            ////comboBox2.SelectedText = FUye.Listele().Columns["uyeno"].ColumnName;
            //////comboBox2.Items.Add(comboBox2.SelectedIndex.ToString());
            //////comboBox2.Text = uye.uyeadi.ToString();
            //////comboBox2.SelectedValue = uye.uyeno.ToString();

        }


        private void listb_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FIslem.Listele();
        }

        private void kaydb_Click(object sender, EventArgs e)
        {
            EIslem ekle = new EIslem();
            ekle.uyeno = Convert.ToInt32(textBox1.Text);
            ekle.kitapno = Convert.ToInt32(textBox2.Text);
            ekle.islemT = maskedTextBox1.Text;
            ekle.teslimT = maskedTextBox2.Text;
            ekle.islemdurum = comboBox1.Text;

            if (BLEKitap.IEkle(ekle) == true)
            {
                MessageBox.Show("İşlem Başarılı!");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız!");
            }

            dataGridView1.DataSource = FIslem.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            label6.Visible = false;
            dataGridView2.Visible = true;
            dataGridView2.DataSource = FUye.Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            label6.Visible = false;
            dataGridView3.DataSource = FKitap.KitapListe();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            //if (dataGridView1.Columns[0].Name == "uyeno")
            //{
            //    textBox1.Text = satir.Cells["UyeNo"].Value.ToString();
            //}
            //else if (dataGridView1.Columns[0].Name == "kitapno")
            //{
            //    textBox1.Text = satir.Cells["kitapno"].Value.ToString();
            //}
            //else /*if (dataGridView1.Columns[1].Name == "uyeno" && dataGridView1.Columns[2].Name == "kitapno")*/
            //{
                textBox1.Tag = satir.Cells["islemno"].Value.ToString();
                textBox1.Text = satir.Cells["uyeno"].Value.ToString();
                textBox2.Text = satir.Cells["kitapno"].Value.ToString();
                maskedTextBox1.Text = satir.Cells["islemT"].Value.ToString();
                maskedTextBox2.Text = satir.Cells["teslimT"].Value.ToString();
                comboBox1.SelectedText = satir.Cells["islemdurum"].Value.ToString();
            //}
                //if (dataGridView1.DataSource == FUye.Listele())
                //{
                //    textBox1.Text = satir.Cells["UyeNo"].Value.ToString();
                //}
                //else if (dataGridView1.DataSource == FKitap.KitapListe())
                //{
                //    textBox2.Text = satir.Cells["KitapNo"].Value.ToString();
                //}
                //else /*if (dataGridView1.DataSource == FIslem.Listele())*/
                //{
                //textBox1.Tag = satir.Cells["islemno"].Value.ToString();
                //textBox1.Text = satir.Cells["uyeno"].Value.ToString();
                //textBox2.Text = satir.Cells["kitapno"].Value.ToString();
                //maskedTextBox1.Text = satir.Cells["islemT"].Value.ToString();
                //maskedTextBox2.Text = satir.Cells["teslimT"].Value.ToString();
                //comboBox1.SelectedText = satir.Cells["islemdurum"].Value.ToString();

            //}

        }

        private void yenileb_Click(object sender, EventArgs e)
        {
            EIslem yenile = new EIslem();
            yenile.islemno = Convert.ToInt32(textBox1.Tag);
            yenile.uyeno = Convert.ToInt32(textBox1.Text);
            yenile.kitapno = Convert.ToInt32(textBox2.Text);
            yenile.islemT = maskedTextBox1.Text;
            yenile.teslimT = maskedTextBox2.Text;
            yenile.islemdurum = comboBox1.Text;

            if (!FIslem.Guncelle(yenile))
            {
                MessageBox.Show("Güncellenemedi!!");
            }
            dataGridView1.DataSource = FIslem.Listele();
        }

        private void silb_Click(object sender, EventArgs e)
        {
            EIslem sil = new EIslem();
            sil.islemno = Convert.ToInt32(textBox1.Tag);

            if (!FIslem.Sil(sil))
            {
                MessageBox.Show("Silinemedi!!");
            }
            dataGridView1.DataSource = FIslem.Listele();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView2.CurrentRow;
            
                textBox1.Text = satir.Cells["UyeNo"].Value.ToString();
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView3.CurrentRow;
            textBox2.Text = satir.Cells["KitapNo"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlIslem xmlislem = new XmlIslem();
            this.Hide();
            xmlislem.Show();
        }
    }
}
