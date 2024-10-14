using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turkcell_GY_Urun_Takip_Entitiy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        DbUrunEntities1 db=new DbUrunEntities1();

         
        private void btnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TBLMusteris.ToList();
            var degerler = from x in db.TBLMusteris
                           select new
                           {
                               x.MusteriId,x.Ad,x.Soyad,x.Sehir,x.Bakiye
                           };
            dataGridView1.DataSource = degerler.ToList();


        }

        private void txtKaydet_Click(object sender, EventArgs e)
        {
            TBLMusteri t=new TBLMusteri();
            t.Ad = txtAd.Text;
            t.Soyad = txtSoyad.Text;
            t.Bakiye=decimal.Parse(txtBakiye.Text);
            t.Sehir= txtSehir.Text;
            db.TBLMusteris.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Müşteri Kaydı Yapıldı.");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var x=db.TBLMusteris.Find(id);
            db.TBLMusteris.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Müşteri Sistemden Silindi.");
        }

        private void btnGüncelleme_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = db.TBLMusteris.Find(id);
            x.Ad = txtAd.Text;
            x.Sehir = txtSehir.Text;
            x.Soyad= txtSoyad.Text;
            x.Bakiye = decimal.Parse(txtBakiye.Text);
            db.SaveChanges();
            MessageBox.Show("Müşteri Güncellendi.");

            
        }
    }
}
