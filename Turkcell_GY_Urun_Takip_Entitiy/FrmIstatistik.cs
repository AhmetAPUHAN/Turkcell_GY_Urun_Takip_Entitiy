using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turkcell_GY_Urun_Takip_Entitiy
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DbUrunEntities1 db = new DbUrunEntities1();
        private void lblMusteriSayisi_Click(object sender, EventArgs e)
        {

        }

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            lblMusteriSayisi.Text = db.TBLMusteris.Count().ToString();
            lblKategoriSayisi.Text = db.TBLKategoris.Count().ToString();
            lblUrunSayisi.Text = db.TBLUrunlers.Count().ToString();
            lblBeyazEsyaSayisi.Text = db.TBLUrunlers.Count(x => x.Kategori == 1).ToString();
            lblStok.Text = db.TBLUrunlers.Sum(x => x.Stok).ToString();
            lblBugunSatıs.Text = db.TBLSatıslar.Count(x => x.Tarih == bugun).ToString();
            lblToplamKasa.Text = db.TBLSatıslar.Sum(x => x.Toplam).ToString() + " TL";
            lblBugunKasa.Text = db.TBLSatıslar.Where(x => x.Tarih == bugun).Sum(y => y.Toplam).ToString() + " TL";
            lblEnyüksekUrun.Text = (from x in db.TBLUrunlers orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
            lblEndusukUrun.Text = (from x in db.TBLUrunlers orderby x.SatisFiyati select x.UrunAd).FirstOrDefault();
            lblEnFazlaStok.Text = (from x in db.TBLUrunlers orderby x.Stok descending select x.UrunAd).FirstOrDefault();
            lblEnazStok.Text=(from x in db.TBLUrunlers orderby x.Stok ascending select x.UrunAd).FirstOrDefault();  
        
        }
    }
}
