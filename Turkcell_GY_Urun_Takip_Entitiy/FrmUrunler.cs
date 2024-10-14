using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turkcell_GY_Urun_Takip_Entitiy
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }


        DbUrunEntities1 db = new DbUrunEntities1();

        void urunListele()  //ürün listele metodu
        {
            var urunler = from x in db.TBLUrunlers   //istenilen sutun geliyor
                          select new
                          {
                              x.UrunId,
                              x.UrunAd,
                              x.Stok,
                              x.AlisFiyat,
                              x.SatisFiyati,
                              x.TBLKategori.Ad
                          };
            dataGridView1.DataSource = urunler.ToList();
        }

        void temizle() //temizle metodu
        {
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            txtStok.Text = "";
            txtId.Text = "";
            txtUrunAd.Text = "";
            db.SaveChanges();
        }


        private void btnListele_Click(object sender, EventArgs e)
        {
            urunListele();
            //dataGridView1.DataSource = db.TBLUrunlers.ToList();   tüm sütunları getiriyor.
            
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            urunListele();
            cmbKategori.DataSource = db.TBLKategoris.ToList();
            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "Ad";
        }

        private void txtKaydet_Click(object sender, EventArgs e)
        {
            TBLUrunler t=new TBLUrunler();
            t.AlisFiyat =decimal.Parse( txtAlisFiyat.Text);
            t.SatisFiyati = decimal.Parse(txtSatisFiyat.Text);
            t.UrunAd= txtUrunAd.Text;
            t.Stok = short.Parse(txtStok.Text);
            t.Kategori = int.Parse(cmbKategori.SelectedValue.ToString());
            db.TBLUrunlers.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün kaydedildi.");
            urunListele();
            temizle();
        }

        

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbKategori.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();   

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                var x = db.TBLUrunlers.Find(id);
                db.TBLUrunlers.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Ürün Silindi", "Silme işlemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else { MessageBox.Show("Silmek istediğiniz satırı tıklayın"); }

            urunListele();
            temizle();
        }

        private void btnGüncelleme_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var x = db.TBLUrunlers.Find(id);
            x.UrunAd=txtUrunAd.Text;
            x.Stok=short.Parse(txtStok.Text);
            x.SatisFiyati=decimal.Parse(txtSatisFiyat.Text);
            x.AlisFiyat =decimal.Parse( txtAlisFiyat.Text);
            x.Kategori = int.Parse(cmbKategori.SelectedValue.ToString());

            db.SaveChanges();
            MessageBox.Show("Güncellendi.");
            urunListele();
            temizle() ;
        }
    }
}
