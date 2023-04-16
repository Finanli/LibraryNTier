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
using System.Xml;
using System.Xml.Linq;

namespace KutuphaneKatmanlı
{
    public partial class XmlKitap : Form
    {
        public XmlKitap()
        {
            InitializeComponent();
        }

        private void XmlKitap_Load(object sender, EventArgs e)
        {
            groupBox1.Visible= false;
            MessageBox.Show("XML Dosyası oluşturulmuştur!! CRUD İşlemlerinizi Yapabilirsiniz");
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();

            XmlElement root = xdoc.CreateElement("Kutuphane");

            SqlConnection baglan = new SqlConnection("Server =LAPTOP-DI6H08K1; Database=Kutuphane; Integrated Security =true; ");

            SqlCommand cmd = new SqlCommand("select * from Kitap", baglan);
            baglan.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                XmlElement kitaplar = xdoc.CreateElement("Kitaplar"); //tag oluşturuyo 
                XmlAttribute kitapno = xdoc.CreateAttribute("KitapNo"); //attribute adı oluştur (veri için etiket oluşturuluyor)
                kitapno.Value = reader["kitapNo"].ToString(); // sql den okuyor (column adı olmak zorudna)

                XmlAttribute kitapadi = xdoc.CreateAttribute("KitapAdi");
                kitapadi.Value = reader["kitapAdi"].ToString();

                XmlAttribute yazaradi = xdoc.CreateAttribute("YazarAdi");
                yazaradi.Value = reader["yazarAdi"].ToString();

                XmlAttribute sayfasayi = xdoc.CreateAttribute("SayfaSayi");
                sayfasayi.Value = reader["sayfaSayi"].ToString();

                XmlAttribute konu = xdoc.CreateAttribute("Konu");
                konu.Value = reader["konu"].ToString();

                XmlAttribute yayinevi = xdoc.CreateAttribute("YayinEvi");
                yayinevi.Value = reader["yayinEvi"].ToString();


                kitaplar.Attributes.Append(kitapno); // tedarik taginin içine attribute ları ekler
                kitaplar.Attributes.Append(kitapadi);
                kitaplar.Attributes.Append(yazaradi);
                kitaplar.Attributes.Append(sayfasayi);
                kitaplar.Attributes.Append(konu);
                kitaplar.Attributes.Append(yayinevi);
                root.AppendChild(kitaplar); // tedarikçi tagine ekliyo ekleyerek ilerlemesini sağlar
            }


            baglan.Close();
            xdoc.AppendChild(root); // tüm elementleri ana köke ekker yani tedarikçiler 
            xdoc.Save("kitapveri.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;

        }
        public void Listele()
        {
            XmlDocument i = new XmlDocument(); 
            DataSet ds = new DataSet();
            XmlReader xmlfile = XmlReader.Create(@"kitapveri.xml", new XmlReaderSettings());
            
            ds.ReadXml(xmlfile); 
            dataGridView1.DataSource = ds.Tables[0]; 
            xmlfile.Close();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void kaydb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"kitapveri.xml");
            x.Element("Kutuphane").Add(new XElement("Kitaplar", new XElement("KitapNo", textBox6.Text),
                new XElement("uyeno", textBox1.Text), new XElement("kitapno", textBox2.Text),
                new XElement("SayfaSayi", textBox3.Text), new XElement("Konu", textBox4.Text), new XElement("YayinEvi", textBox5.Text)));
            x.Save(@"kitapveri.xml");
            Listele();
        }

        private void yenileb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"kitapveri.xml");
            XElement node = x.Elements("kutuphane").Elements("kitaplar").FirstOrDefault(a => a.Element("kitapNo").Value == textBox6.Text);

            node.SetElementValue("KitapAdi", textBox1.Text);
            node.SetElementValue("YazarAdi", textBox2.Text); //elementin değerini değiştir.
            node.SetElementValue("SayfaSayi", textBox3.Text);
            node.SetElementValue("Konu", textBox4.Text);
            node.SetElementValue("YayinEvi", textBox5.Text);

            x.Save(@"kitapveri.xml");
            Listele();
        }

        private void silb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"kitapveri.xml"); //xml dosyasnda değişiklik yapacağında
            x.Root.Elements().Where(a => a.Element("kitapNo").Value == textBox6.Text).Remove();
            x.Save(@"kitapveri.xml");
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }
    }
}
