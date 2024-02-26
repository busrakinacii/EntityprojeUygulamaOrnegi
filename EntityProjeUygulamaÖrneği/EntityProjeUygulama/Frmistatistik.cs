using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString();
            label5.Text = db.TBLURUN.Count().ToString();
            label7.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            label21.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label11.Text = db.TBLURUN.Sum(y => y.STOK).ToString();
            label17.Text = db.TBLSATIS.Sum(z => z.FIYAT).ToString() + " TL";
            label13.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label23.Text = (from y in db.TBLURUN orderby y.FIYAT ascending select y.URUNAD).FirstOrDefault();
            label3.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            label19.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            label15.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label9.Text = db.MARKAGETIR().FirstOrDefault();
        }
    }
}
