﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using CBT_Application.Entity;

namespace CBT_Application
{
    public partial class FrmUjian : Form
    {
        List<Soal> listDataSoal = null;
        string filename = @"..\..\..\data\dataSoal.json";
        
        public FrmUjian()
        {
            InitializeComponent();
        }

        public List<int> hasilRandom = new List<int>();
        public string[] jawabanSiswa = new string[10];
        public List<bool> benarSalah = new List<bool>();
        public int nomorSekarang = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Ambil Soal dari File JSON
            try
            {
                if (File.Exists(filename))
                {
                    string fileContent = File.ReadAllText(filename);
                    listDataSoal = JsonConvert.DeserializeObject<List<Soal>>(fileContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.lblJlhSoal.Text = $"Jumlah Soal Tersedia {this.listDataSoal.Count}";

            // Randomize nomor soal
            
            Random rng = new Random();
            for (int i = 0; i < 10; i++)
            {
                int nomornya = rng.Next(1, 11); //Nanti ganti ke 50
                do
                {
                    nomornya = rng.Next(1, 11); //Nanti ganti ke 50
                } while (hasilRandom.Contains(nomornya));
                hasilRandom.Add(nomornya);
            }
            loadSoal(nomorSekarang, hasilRandom[nomorSekarang-1]);
        }

        private void loadSoal(int nomorSekarang, int hasilRandom)
        {
            this.lblNomor.Text = $"{nomorSekarang}"; ///{hasilRandom+1}
            this.lblKalimatSoal.Text = listDataSoal[hasilRandom-1].kalimatSoal;
            this.lblPilihanA.Text = listDataSoal[hasilRandom-1].pilihanA;
            this.lblPilihanB.Text = listDataSoal[hasilRandom-1].pilihanB;
            this.lblPilihanC.Text = listDataSoal[hasilRandom-1].pilihanC;
            this.lblPilihanD.Text = listDataSoal[hasilRandom-1].pilihanD;
            if (nomorSekarang == 1)
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
            }
            else if (nomorSekarang == 10)
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = false;
            } else
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
            }
            for (int i=0; i<10; i++)
            {
                if (jawabanSiswa[i] != null)
                {
                    switch (i)
                    {
                        case 0: btn1.BackColor = Color.LightGreen; break;
                        case 1: btn2.BackColor = Color.LightGreen; break;
                        case 2: btn3.BackColor = Color.LightGreen; break;
                        case 3: btn4.BackColor = Color.LightGreen; break;
                        case 4: btn5.BackColor = Color.LightGreen; break;
                        case 5: btn6.BackColor = Color.LightGreen; break;
                        case 6: btn7.BackColor = Color.LightGreen; break;
                        case 7: btn8.BackColor = Color.LightGreen; break;
                        case 8: btn9.BackColor = Color.LightGreen; break;
                        case 9: btn10.BackColor = Color.LightGreen; break;
                    }
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            loadSoal(1, hasilRandom[0]);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            loadSoal(2, hasilRandom[1]);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            loadSoal(3, hasilRandom[2]);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            loadSoal(4, hasilRandom[3]);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            loadSoal(5, hasilRandom[4]);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            loadSoal(6, hasilRandom[5]);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            loadSoal(7, hasilRandom[6]);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            loadSoal(8, hasilRandom[7]);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            loadSoal(9, hasilRandom[8]);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            loadSoal(10, hasilRandom[9]);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            nomorSekarang--;
            loadSoal(nomorSekarang, hasilRandom[nomorSekarang - 1]);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            nomorSekarang++;
            loadSoal(nomorSekarang, hasilRandom[nomorSekarang - 1]);
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            jawabanSiswa[nomorSekarang - 1] = "A"; loadSoal(nomorSekarang, hasilRandom[nomorSekarang - 1]);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            jawabanSiswa[nomorSekarang - 1] = "B"; loadSoal(nomorSekarang, hasilRandom[nomorSekarang - 1]);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            jawabanSiswa[nomorSekarang - 1] = "C"; loadSoal(nomorSekarang, hasilRandom[nomorSekarang - 1]);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            jawabanSiswa[nomorSekarang - 1] = "D"; loadSoal(nomorSekarang, hasilRandom[nomorSekarang - 1]);
        }
    }
}