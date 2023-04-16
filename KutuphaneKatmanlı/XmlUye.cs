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
    public partial class XmlUye : Form
    {
        public XmlUye()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();

            XmlElement root = xdoc.CreateElement("Kutuphane");

            SqlConnection baglan = new SqlConnection("Server =LAPTOP-DI6H08K1; Database=Kutuphane; Integrated Security =true; ");

            SqlCommand cmd = new SqlCommand("select * from Uyeler", baglan);
            baglan.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                XmlElement uye = xdoc.CreateElement("Uye"); //tag oluşturuyo 
                XmlAttribute uyeno = xdoc.CreateAttribute("UyeNo"); //attribute adı oluştur (veri için etiket oluşturuluyor)
                uyeno.Value = reader["uyeNo"].ToString(); // sql den okuyor (column adı olmak zorudna)

                XmlAttribute uyeadi = xdoc.CreateAttribute("uyeAdi");
                uyeadi.Value = reader["uyeAdi"].ToString();

                XmlAttribute uyelikt = xdoc.CreateAttribute("uyelikT");
                uyelikt.Value = reader["uyelikT"].ToString();

                XmlAttribute dogumt = xdoc.CreateAttribute("dogumT");
                dogumt.Value = reader["dogumT"].ToString();

                XmlAttribute meslek = xdoc.CreateAttribute("meslek");
                meslek.Value = reader["meslek"].ToString();




                uye.Attributes.Append(uyeno); // tedarik taginin içine attribute ları ekler
                uye.Attributes.Append(uyeadi);
                uye.Attributes.Append(uyelikt);
                uye.Attributes.Append(dogumt);
                uye.Attributes.Append(meslek);
                root.AppendChild(uye);
            }
            baglan.Close();
            xdoc.AppendChild(root); // tüm elementleri ana köke ekker yani tedarikçiler 
            xdoc.Save(@"uyeveri.xml");
        
        }
        private void XmlUye_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            MessageBox.Show("XML Dosyası oluşturulmuştur!! CRUD İşlemlerinizi Yapabilirsiniz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        public void Listele()
        {
            XmlDocument i = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader xmlfile = XmlReader.Create(@"uyeveri.xml", new XmlReaderSettings());

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
            XDocument x = XDocument.Load("uyeveri.xml");
            x.Element("Kutuphane").Add(new XElement("uye"), new XElement("uyeno", textBox2.Text),
                new XElement("uyeadi", textBox1.Text), new XElement("uyelikT", maskedTextBox1.Text),
                new XElement("dogumT", maskedTextBox2.Text), new XElement("meslek", textBox4.Text));
            x.Save(@"uyeveri.xml");
            Listele();

        }

        private void yenileb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"uyeveri.xml");
            XElement node = x.Elements("Kutuphane").Elements("uye").FirstOrDefault(a => a.Element("uyeno").Value == textBox2.Text);

            node.SetElementValue("uyeno", textBox2.Text);
            node.SetElementValue("uyeadi", textBox1.Text);
            node.SetElementValue("uyelikT", maskedTextBox1.Text);
            node.SetElementValue("dogumT", maskedTextBox2.Text);
            node.SetElementValue("meslek", textBox4.Text);

            x.Save(@"uyeveri.xml");
            Listele();

        }

        private void silb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load("uyeveri.xml");
            x.Root.Elements().Where(a=> a.Element("uyeno").Value == textBox2.Text).Remove();

            x.Save("uyeveri.xml");
            Listele();

        }
    }
}
