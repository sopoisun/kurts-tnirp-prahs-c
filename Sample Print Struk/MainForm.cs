using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Sample_Print_Struk
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            printdocument1.PrintPage += printDocument1_PrintPage;
        }

        private DataRow row;
        private DataTable table = new DataTable();
        PrintDocument printdocument1 = new PrintDocument();
        private string _txt = "";
        private int _length = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                using (PrintDialog pd = new PrintDialog())
                {
                    printdocument1.PrinterSettings = pd.PrinterSettings;
                    printdocument1.Print();
                }
            }
            else
            {
                MessageBox.Show("Tidak ada data disini !!");
            }
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font objFont = new Font("Courier New", 9F);//sets the font type and size
            Font fontHeader = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);//sets the font type and size
            //float fTopMargin = e.MarginBounds.Top;
            float fTopMargin = 0;
            float fLeftMargin = 5;//sets left margin
            float fRightMargin = e.MarginBounds.Right - 150;//sets right margin
            string text = "";

            e.Graphics.DrawString("Pondok Indah Banyuwangi", fontHeader, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.7;//skip two lines
            e.Graphics.DrawString("Jl. Lijen Km 8,7", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            e.Graphics.DrawString("0333-821449", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)2;//skip two lines

            text = String.Format("{0} {1, 3} {2}", "Kasir", ":", "Deny Dayanti");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            text = String.Format("{0} {1, 0} {2}", "Waiters", ":", "Jono");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1;//skip two lines

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            this._txt = "Nota : RS-020201611";
            this._length = this._txt.Length;

            text = String.Format("{0, " + this._length + "} {1, " + (10 + (20 - this._length)) + "}", this._txt, DateTime.Now.Date.ToString("dd/MM/yyyy"));

            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.3;//skip two lines

            /* produk */            
            foreach (DataRow row in table.Rows)
            {
                text = string.Concat(row["nama_produk"].ToString());
                e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
                fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

                text = String.Format("   {0, -3} {1, 11} {2, 12}", row["jumlah"], row["harga"], row["subtotal"]);
                e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
                fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            }
            /* produk */

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            text = String.Format("       {0} {1, 7} {2, 10}", "Total", ":", "12.000.000");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            this._txt = " 10%";
            this._length = 9 - _txt.Length;

            text = String.Format("       {0, -1} {1, " + this._length + "} {2, 10}", "Tax" + this._txt, ":", "2.000.000");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            this._txt = " 4%";
            this._length = 5 - _txt.Length;

            text = String.Format("       {0, -1} {1, " + this._length + "} {2, 10}", "Tax Byr" + this._txt, ":", "60.000");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("       {0, -1} {1, 6} {2, 10}", "Jumlah", ":", "2.260.000");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("       {0, -1} {1, 6} {2, 10}", "Diskon", ":", "0");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("       {0, -1} {1, 8} {2, 10}", "Sisa", ":", "2.260.000");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("       {0, -1} {1, 7} {2, 10}", "Bayar", ":", "2.260.000");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("       {0, -1} {1, 5} {2, 10}", "Kembali", ":", "0");
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1;//skip two lines

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            e.Graphics.DrawString("TRIMA KASIH ATAS KUNJUNGAN ANDA", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            objFont.Dispose();

            e.HasMorePages = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int jumData = (int.Parse(textBox1.Text));

                table = new DataTable();

                table.Columns.Add("no", System.Type.GetType("System.String"));
                table.Columns.Add("nama_produk", System.Type.GetType("System.String"));
                table.Columns.Add("harga", System.Type.GetType("System.String"));
                table.Columns.Add("jumlah", System.Type.GetType("System.String"));
                table.Columns.Add("subtotal", System.Type.GetType("System.String"));

                int nilai = 10000;
                for (int i = 0; i < jumData; i++)
                {
                    int harga = nilai * (i + 1);
                    int subtotal = harga * (i + 1);

                    row = table.NewRow();

                    row["no"] = i + 1;
                    row["nama_produk"] = "Produk " + (i + 1);
                    row["jumlah"] = i + 1;
                    row["harga"] = harga.ToString("C").Substring(2);
                    row["subtotal"] = subtotal.ToString("C").Substring(2);

                    table.Rows.Add(row);
                }

                dataGridView1.Columns.Clear();

                dataGridView1.DataSource = table;

                dataGridView1.Columns[0].HeaderText = "No";
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].HeaderText = "Nama Produk";
                dataGridView1.Columns[1].Width = 140;
                dataGridView1.Columns[1].Name = "nama_produk";
                dataGridView1.Columns[2].HeaderText = "Harga";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].Name = "harga";
                dataGridView1.Columns[3].HeaderText = "Qty";
                dataGridView1.Columns[3].Width = 60;
                dataGridView1.Columns[3].Name = "qty";
                dataGridView1.Columns[4].HeaderText = "Subtotal";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].Name = "subtotal";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input harus angka !!!");
            }            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.button2_Click(null, null);
            }
        }
    }
}
