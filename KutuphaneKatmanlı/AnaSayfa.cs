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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            UyeEkrani uye = new UyeEkrani();
            uye.TopLevel= false;
            scpanel.Controls.Add(uye);
            uye.Show();
            uye.Dock= DockStyle.Fill;
            uye.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            Kitap ktp = new Kitap();
            ktp.TopLevel = false;
            scpanel.Controls.Add(ktp);
            ktp.Show();
            ktp.Dock = DockStyle.Fill;
            ktp.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scpanel.Controls.Clear();
            IslemEkrani isle = new IslemEkrani();
            isle.TopLevel = false;
            scpanel.Controls.Add(isle);
            isle.Show();
            isle.Dock = DockStyle.Fill;
            isle.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
