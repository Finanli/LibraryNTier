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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KutuphaneKatmanlı
{
    public partial class XmlIslem : Form
    {
        public XmlIslem()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            XmlElement root = xdoc.CreateElement("Kutuphane");

            SqlConnection baglan = new SqlConnection("Server =LAPTOP-DI6H08K1; Database=Kutuphane; Integrated Security =true; ");

            SqlCommand cmd = new SqlCommand("select * from Islemler", baglan);
            baglan.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                XmlElement islem = xdoc.CreateElement("Islem");
                XmlAttribute islemno = xdoc.CreateAttribute("islemno");
                islemno.Value = reader["islemno"].ToString();

                XmlAttribute uyeno = xdoc.CreateAttribute("uyeno");
                uyeno.Value = reader["uyeno"].ToString() ;

                XmlAttribute kitapno = xdoc.CreateAttribute("kitapno");
                kitapno.Value = reader["kitapno"].ToString();

                XmlAttribute islemt = xdoc.CreateAttribute("islemT");
                islemt.Value = reader["islemT"].ToString();

                XmlAttribute teslimt = xdoc.CreateAttribute("teslimT");
                teslimt.Value = reader["teslimT"].ToString();

                XmlAttribute islemdurum = xdoc.CreateAttribute("islemdurum");
                islemdurum.Value = reader["islemdurum"].ToString();

                islem.Attributes.Append(islemno);
                islem.Attributes.Append(uyeno);
                islem.Attributes.Append(kitapno);
                islem.Attributes.Append(islemt);
                islem.Attributes.Append(teslimt);
                islem.Attributes.Append(islemdurum);
                root.AppendChild(islem);
            }
            baglan.Close();
            xdoc.AppendChild(root);
            xdoc.Save("islemveri.xml");
        }

        private void XmlIslem_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            MessageBox.Show("XML Dosyası oluşturulmuştur!! CRUD İşlemlerinizi Yapabilirsiniz");
        }

        public void Listele()
        {
            XmlDocument xdoc = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader xmlfile = XmlReader.Create(@"islemveri.xml", new XmlReaderSettings());

            ds.ReadXml(xmlfile);
            dataGridView1.DataSource = ds.Tables[0];
            xmlfile.Close();
        }

        private void listb_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void kaydb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"islemveri.xml");
            x.Element("Kutuphane").Add(new XElement("Islem", new XElement("islemNo", textBox3.Text),
                new XElement("uyeno", textBox1.Text), new XElement("kitapno", textBox2.Text),
                new XElement("islemT", maskedTextBox1.Text), new XElement("teslimT", maskedTextBox2.Text), new XElement("islemdurum", comboBox1.SelectedText)));
            x.Save(@"islemveri.xml");
            Listele();
        }

        private void yenileb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"islemveri.xml");
            XElement node = x.Elements("Kutuphane").Elements("islem").FirstOrDefault(a => a.Element("islemno").Value == textBox3.Text);
            
            node.SetElementValue("islemno", textBox3.Text);
            node.SetElementValue("uyeno", textBox2.Text);
            node.SetElementValue("kitapno", textBox1.Text);
            node.SetElementValue("islemT", maskedTextBox1.Text);
            node.SetElementValue("teslimT", maskedTextBox2.Text);
            node.SetElementValue("islemdurum", comboBox1.SelectedText);

            x.Save(@"islemveri.xml");
            Listele();
        }

        private void silb_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"islemveri.xml");
            x.Root.Elements().Where(a => a.Element("islemno").Value == textBox3.Text).Remove();

            x.Save(@"uyeveri.xml");
            Listele();
        }
    }
}
