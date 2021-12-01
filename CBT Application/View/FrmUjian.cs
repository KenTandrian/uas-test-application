using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CBT_Application.Entity;
using CBT_Application.DAL;

namespace CBT_Application
{
    public partial class FrmUjian : Form
    {
        List<Soal> listDataSoal = new List<Soal>();
        //string filename = @"..\..\..\data\dataSoal.json";
        User pengguna = new User();

        // Waktu Ujian
        int menit = 20;
        int detik = 0;

        public FrmUjian(User user)
        {
            InitializeComponent();
            pengguna = user;
            lblSubject.Text = pengguna.Topik.ToString();
        }

        public List<int> hasilRandom = new List<int>();
        public string[] jawabanSiswa = new string[10];
        public List<bool> benarSalah = new List<bool>();
        public int nomorSekarang = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Menampilkan Info Dulu sebelum mulai
            using (View.FrmInfoUjian form1 = new View.FrmInfoUjian(pengguna))
            {
                form1.ShowDialog();
            }

            // Setelah Info ditutup, ujian langsung mulai
            timer1.Start();
            lblTimer.Text = $"{menit.ToString("00")}:{detik.ToString("00")}";
            
            // Nonaktifkan tombol Finish
            this.btnFinish.Enabled = false;

            // Ambil Soal dari File JSON
            /*try
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
            }*/

            // Randomize nomor soal ke Sebuah List
            Random rng = new Random();
            for (int i = 0; i < 10; i++)
            {
                int nomornya = rng.Next(1, 51);
                do
                {
                    nomornya = rng.Next(1, 51); // More than or equal to 1 and less than 51
                } while (hasilRandom.Contains(nomornya)); // memastikan ga ada yang sama
                hasilRandom.Add(nomornya);
            }

            // Ambil soal dari Database
            for (int i = 0; i < 10; i++)
            {
                using (var dal = new DALSoal())
                {
                    var soal = dal.GetItem(hasilRandom[i], pengguna.Topik);
                    listDataSoal.Add(soal);
                }
            }
            loadSoal(nomorSekarang, hasilRandom[nomorSekarang-1]);
            /*if (listDataSoal != null)
            {
                this.lblJlhSoal.Text = $"Jumlah Soal Tersedia {this.listDataSoal.Count}";
            }*/
        }

        // Pergantian Soal untuk setiap tombol
        private void btn1_Click(object sender, EventArgs e) { nomorSekarang = 1; loadSoal(1, hasilRandom[0]); }
        private void btn2_Click(object sender, EventArgs e) { nomorSekarang = 2; loadSoal(2, hasilRandom[1]); }
        private void btn3_Click(object sender, EventArgs e) { nomorSekarang = 3; loadSoal(3, hasilRandom[2]); }
        private void btn4_Click(object sender, EventArgs e) { nomorSekarang = 4; loadSoal(4, hasilRandom[3]); }
        private void btn5_Click(object sender, EventArgs e) { nomorSekarang = 5; loadSoal(5, hasilRandom[4]); }
        private void btn6_Click(object sender, EventArgs e) { nomorSekarang = 6; loadSoal(6, hasilRandom[5]); }
        private void btn7_Click(object sender, EventArgs e) { nomorSekarang = 7; loadSoal(7, hasilRandom[6]); }
        private void btn8_Click(object sender, EventArgs e) { nomorSekarang = 8; loadSoal(8, hasilRandom[7]); }
        private void btn9_Click(object sender, EventArgs e) { nomorSekarang = 9; loadSoal(9, hasilRandom[8]); }
        private void btn10_Click(object sender, EventArgs e) { nomorSekarang = 10; loadSoal(10, hasilRandom[9]); }

        // Pergantian Nomor soal untuk Previous dan Next
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

        // Simpan Jawaban
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

        // Ganti Angka Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (detik == 0)
            {
                if (menit == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Waktu Ujian Sudah Habis!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Form ini Close, nanti masuk ke Form Hasil Ujian
                }
                else
                {
                    menit--; detik = 59;
                    lblTimer.Text = $"{menit.ToString("00")}:{detik.ToString("00")}";
                }
            }
            else
            {
                detik--;
                lblTimer.Text = $"{menit.ToString("00")}:{detik.ToString("00")}";
            }
        }
        int nilaiUjian = 0;
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) timer1.Stop();
            pengguna.Attempt += 1;
            DialogResult result = MessageBox.Show($"Waktu masih tersisa {menit} menit {detik} detik. Yakin ingin selesai?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (timer1.Enabled == true) timer1.Stop();
                this.Hide();
                for(int i = 0; i < 10; i++)
                {
                    if (jawabanSiswa[i].Trim().Equals(listDataSoal[i].jawabanSoal.Trim()))
                    {
                        nilaiUjian = nilaiUjian + 10;
                    }
                }
                pengguna.Score = nilaiUjian;
                // Simpan nilai ke database.
                using(var dal = new DALTestLog())
                {
                    dal.CreateNewLog(pengguna, nilaiUjian);
                }

                using (View.FrmHasilUjian form2 = new View.FrmHasilUjian(nilaiUjian, pengguna))
                {
                    form2.Closed += (s, args) => this.Close();
                    form2.ShowDialog();
                }
            } else
            {
                if (menit != 0 && detik != 0) timer1.Start();
            }
        }

        // Procedures
        int jlhTerisiSblmnya = 0;
        private void loadSoal(int nomorSekarang, int hasilRandom)
        {
            this.lblNomor.Text = $"{nomorSekarang}"; // Nanti Dihapus /{hasilRandom}
            this.lblKalimatSoal.Text = $"{listDataSoal[nomorSekarang - 1].kalimatSoal.Replace("\\n", "\n").Replace("\\t", "\t")}";
            this.lblPilihanA.Text = listDataSoal[nomorSekarang - 1].pilihanA;
            this.lblPilihanB.Text = listDataSoal[nomorSekarang - 1].pilihanB;
            this.lblPilihanC.Text = listDataSoal[nomorSekarang - 1].pilihanC;
            this.lblPilihanD.Text = listDataSoal[nomorSekarang - 1].pilihanD;

            // Aktif atau Nonaktifkan tombol Prev and Next
            if (nomorSekarang == 1)
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
            }
            else if (nomorSekarang == 10)
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
            }
            ChangeBtnSoalColor();

            // Reset warna button jawaban
            Helper.ResetBtnColor(btnA);
            Helper.ResetBtnColor(btnB);
            Helper.ResetBtnColor(btnC);
            Helper.ResetBtnColor(btnD);

            // Memberi warna hijau ke jawaban yang dipilih
            if (jawabanSiswa[nomorSekarang - 1] != null)
            {
                switch (jawabanSiswa[nomorSekarang - 1])
                {
                    case "A": Helper.SetBtnAnswered(btnA); break;
                    case "B": Helper.SetBtnAnswered(btnB); break;
                    case "C": Helper.SetBtnAnswered(btnC); break;
                    case "D": Helper.SetBtnAnswered(btnD); break;
                }
            }

            // Mengecek apakah Tombol Finish sudah boleh diaktifkan
            bool terisiSemua = true;
            int jlhTerisi = 10;
            foreach (var item in jawabanSiswa)
            {
                if (item == null) 
                { 
                    terisiSemua = false;
                    jlhTerisi--;
                }
            }
            for (int i=jlhTerisiSblmnya*100; i < (jlhTerisi*100); i++)
            {
                prbProgress.Value = i/10;
            }
            jlhTerisiSblmnya = jlhTerisi;
            if (terisiSemua) 
            {
                prbProgress.Value = 100;
                this.btnFinish.Enabled = true;
            }
            else { this.btnFinish.Enabled = false; }
        }
        private void ChangeBtnSoalColor()
        {
            Helper.ResetBtnColor(btn1);
            Helper.ResetBtnColor(btn2);
            Helper.ResetBtnColor(btn3);
            Helper.ResetBtnColor(btn4);
            Helper.ResetBtnColor(btn5);
            Helper.ResetBtnColor(btn6);
            Helper.ResetBtnColor(btn7);
            Helper.ResetBtnColor(btn8);
            Helper.ResetBtnColor(btn9);
            Helper.ResetBtnColor(btn10);

            for (int i = 0; i < 10; i++)
            {
                if (jawabanSiswa[i] != null)
                {
                    switch (i)
                    {
                        case 0: Helper.SetBtnAnswered(btn1); break;
                        case 1: Helper.SetBtnAnswered(btn2); break;
                        case 2: Helper.SetBtnAnswered(btn3); break;
                        case 3: Helper.SetBtnAnswered(btn4); break;
                        case 4: Helper.SetBtnAnswered(btn5); break;
                        case 5: Helper.SetBtnAnswered(btn6); break;
                        case 6: Helper.SetBtnAnswered(btn7); break;
                        case 7: Helper.SetBtnAnswered(btn8); break;
                        case 8: Helper.SetBtnAnswered(btn9); break;
                        case 9: Helper.SetBtnAnswered(btn10); break;
                    }
                }
            }
            switch (nomorSekarang - 1)
            {
                case 0: Helper.SetBtnCurrent(btn1); break;
                case 1: Helper.SetBtnCurrent(btn2); break;
                case 2: Helper.SetBtnCurrent(btn3); break;
                case 3: Helper.SetBtnCurrent(btn4); break;
                case 4: Helper.SetBtnCurrent(btn5); break;
                case 5: Helper.SetBtnCurrent(btn6); break;
                case 6: Helper.SetBtnCurrent(btn7); break;
                case 7: Helper.SetBtnCurrent(btn8); break;
                case 8: Helper.SetBtnCurrent(btn9); break;
                case 9: Helper.SetBtnCurrent(btn10); break;
            }
        }
    }
}
