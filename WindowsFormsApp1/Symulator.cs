using SymulatroLinii.Model;
using SymulatroLinii.Repository;
using SymulatroLinii.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static SymulatroLinii.Model.DbSerwerSQLite;
using System.Diagnostics;
using Dapper;

namespace WindowsFormsApp1
{
    public partial class Symulator : Form
    {
        Zmienne _zmienne { get; set; } = new Zmienne();
        DbTempTable _dbTempTable { get; set; } = new DbTempTable();
        public Symulator()
        {
            InitializeComponent();
            checkBox_symulacja.DataBindings.Add("Checked", _zmienne, "symulacjaONOFF", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox_wydajnosc.DataBindings.Add("Text", _dbTempTable, "Wydajnosc", true, DataSourceUpdateMode.OnPropertyChanged);
            hScrollBar_wydajnosc.DataBindings.Add("Value", _dbTempTable, "Wydajnosc", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox_licznik.DataBindings.Add("Text", _dbTempTable, "L_Opakowan", true, DataSourceUpdateMode.OnPropertyChanged);

            richTextBox_informacje.Text = "Numer linii: " + _dbTempTable.Nr_lini.ToString();
        }

        private void button_start_wydajnosc_Click(object sender, EventArgs e)
        {
            int maxWydajnosc = hScrollBar_wydajnosc.Maximum - hScrollBar_wydajnosc.LargeChange;
            textBox_wydajnosc.Text = maxWydajnosc.ToString();
            ZmienStanLicznika();

        }

        private void button_stop_wydajnosc_Click(object sender, EventArgs e)
        {            
            textBox_wydajnosc.Text = hScrollBar_wydajnosc.Minimum.ToString();
            ZmienStanLicznika();

        }

        private void hScrollBar_wydajnosc_Scroll(object sender, ScrollEventArgs e)
        {
            _dbTempTable.Wydajnosc = hScrollBar_wydajnosc.Value;
            ZmienStanLicznika();
        }

        private void ZmienStanLicznika()
        {
            if (_dbTempTable.Wydajnosc > 0)
            {
                timer_Licznik.Start();
            }
            else
            {
                timer_Licznik.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_dbTempTable.Wydajnosc + " " + _dbTempTable.FilRun + " " + _dbTempTable.Time_Stamp + " " + _zmienne.symulacjaONOFF);
        }

        private void hScrollBar_wydajnosc_ValueChanged(object sender, EventArgs e)
        {
            if (hScrollBar_wydajnosc.Value > 0)
                _dbTempTable.FilRun = 1;
            else
                _dbTempTable.FilRun = 0;
        }

        private void button_start_symulator_Click(object sender, EventArgs e)
        {
            if(SerwerCzyNieMaPustychPol())
            { 
            checkBox_symulacja.Checked = !checkBox_symulacja.Checked;
            if (!checkBox_symulacja.Checked)
            { 
                button_start_symulator.Text = "Start symulacji";
                timer_Symulacja.Stop();
                UstawPolaNaAktywne();
                PolaSymulatoraDostepne(false);
                timer_Licznik.Stop();
                textBox_wydajnosc.Text = 0.ToString();
                textBox_licznik.Text = 0.ToString();
                }
            else
            { 
                button_start_symulator.Text = "Stop symulacji";
                timer_Symulacja.Start();
                UstawPolaNaNieaktywne();
                PolaSymulatoraDostepne(true);
            }
            }
            else
            {
                MessageBox.Show("Nie ustawiono parametrów serwera.","Uwaga");
            }

        }

        private void PolaSymulatoraDostepne(bool dostepnosc)
        {
            button_start_wydajnosc.Enabled = dostepnosc;
            button_stop_wydajnosc.Enabled = dostepnosc;            
            button_licznik_reset.Enabled = dostepnosc;
            hScrollBar_wydajnosc.Enabled = dostepnosc;

        }

        private void UstawPolaNaNieaktywne()
            {
            button_serwer_zapisz.Enabled = false;
            button_serwer_usun.Enabled = false;
            comboBox_serwer.Enabled = false;
            textBox_serwer_adres.Enabled = false;
            textBox_serwer_haslo.Enabled = false;
            textBox_serwer_nazwa.Enabled = false;
            textBox_serwer_login.Enabled = false;
            textBox_baza.Enabled = false;
            comboBox_serwer.Enabled = false;
        }
        private void UstawPolaNaAktywne()
        {
            button_serwer_zapisz.Enabled = true;
            comboBox_serwer.Enabled = true;
            button_serwer_usun.Enabled = true;
            textBox_serwer_adres.Enabled = true;
            textBox_serwer_haslo.Enabled = true;
            textBox_serwer_nazwa.Enabled = true;
            textBox_serwer_login.Enabled = true;
            textBox_baza.Enabled = true;
            comboBox_serwer.Enabled = true;
        }

        private void Symulator_Load(object sender, EventArgs e)
        {

            ZaczytajDaneDoComboboxa();
        }

        private void button_serwer_zapisz_Click(object sender, EventArgs e)
        {
            if(SerwerCzyNieMaPustychPol())
            {
                var daneSerwera = new DbSerwer();
                daneSerwera.Nazwa = textBox_serwer_nazwa.Text;
                daneSerwera.Adres = textBox_serwer_adres.Text;
                daneSerwera.Login = textBox_serwer_login.Text;
                daneSerwera.Haslo = textBox_serwer_haslo.Text;
                daneSerwera.Baza = textBox_baza.Text;
                try
                {
                    using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
                    {
                        sqlite.Insert(daneSerwera);

                    }
                    ZaczytajDaneDoComboboxa();
                    MessageBox.Show("Ustawienia zostały zapisane.", "Zapis", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                }
                catch (Exception)
                {

                    MessageBox.Show("Operacja zakończyła się niepowodzeniem.", "Zapis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }         
                
            }
        }

        bool SerwerCzyNieMaPustychPol()
        {
            var result = false;
            if (textBox_serwer_nazwa.Text != "" && textBox_serwer_adres.Text != "" && textBox_serwer_login.Text !="" && textBox_serwer_haslo.Text !="" && textBox_baza.Text != "")
            {
                result = true;
            }
            return result;
        }

        private void ZaczytajDaneDoComboboxa()
        {
            comboBox_serwer.Items.Clear();
            using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
            {
                var nazwy = sqlite.GetAllColumnNazwa();
                foreach (string nazwa in nazwy)
                {
                    comboBox_serwer.Items.Add(nazwa);
                }

            }
        }

        private void button_serwer_usun_Click(object sender, EventArgs e)
        {
            var msgbox = MessageBox.Show("Czy potwierdzasz usunięcie " + comboBox_serwer.Text + " z lity ?", "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
            if (msgbox == DialogResult.Yes)
            { 
            using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
            {
                sqlite.Delete(comboBox_serwer.Text);
                ZaczytajDaneDoComboboxa();
                wyczyscPolaDaneSerwera();
            }
            }

        }

        private void comboBox_serwer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var daneSerwera = new DbSerwer();
            using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
            {                
                daneSerwera= sqlite.GetDbSerwer(comboBox_serwer.Text);
            }
            if(daneSerwera != null) { 
            textBox_serwer_adres.Text = daneSerwera.Adres;
            textBox_serwer_haslo.Text = daneSerwera.Haslo;
            textBox_serwer_nazwa.Text = daneSerwera.Nazwa;
            textBox_serwer_login.Text = daneSerwera.Login;
            textBox_baza.Text = daneSerwera.Baza;
            }
            else
            {
                wyczyscPolaDaneSerwera();
            }
        }
        private void wyczyscPolaDaneSerwera()
        {
            textBox_serwer_adres.Text = "";
            textBox_serwer_haslo.Text = "";
            textBox_serwer_nazwa.Text = "";
            textBox_serwer_login.Text = "";
            textBox_baza.Text = "";
            comboBox_serwer.Text = "";
        }

        private void timer_Symulacja_Tick(object sender, EventArgs e)
        {
            _dbTempTable.Time_Stamp = DateTime.Now;
            SqlConnection cnn;
            string connetionString = "Data Source=" + textBox_serwer_adres.Text + ";Initial Catalog="+ textBox_baza.Text +";User ID=" + textBox_serwer_login.Text + "; Password=" + textBox_serwer_haslo.Text;
            string query = @"INSERT INTO temp (Time_Stamp,L_Opakowan,Wydajnosc,L_OpAplikator,WydajnoscAplikator,FilTrybCIP,FilRezerwa1,FilRezerwa2,FilRezerwa3,FilSterylizacja,FilReadyProd,FilRun,FilRezerwa4,ErrorCode1,ErrorCode2,Nr_lini,Bias,Time_Stamp_ms) VALUES (@Time_Stamp,@L_Opakowan,@Wydajnosc,@L_OpAplikator,@WydajnoscAplikator,@FilTrybCIP,@FilRezerwa1,@FilRezerwa2,@FilRezerwa3,@FilSterylizacja,@FilReadyProd,@FilRun,@FilRezerwa4,@ErrorCode1,@ErrorCode2,@Nr_lini,@Bias,@Time_Stamp_ms)";
                Debug.WriteLine(connetionString + " " + query);
            var parameter = new DynamicParameters();
            parameter.Add("@Time_Stamp", _dbTempTable.Time_Stamp);
            parameter.Add("@L_Opakowan", _dbTempTable.L_Opakowan);
            parameter.Add("@Wydajnosc", _dbTempTable.Wydajnosc);
            parameter.Add("@L_OpAplikator", _dbTempTable.L_OpAplikator);
            parameter.Add("@WydajnoscAplikator", _dbTempTable.WydajnoscAplikator);
            parameter.Add("@FilTrybCIP", _dbTempTable.FilTrybCIP);
            parameter.Add("@FilRezerwa1", _dbTempTable.FilRezerwa1);
            parameter.Add("@FilRezerwa2", _dbTempTable.FilRezerwa2);
            parameter.Add("@FilRezerwa3", _dbTempTable.FilRezerwa3);
            parameter.Add("@FilSterylizacja", _dbTempTable.FilSterylizacja);
            parameter.Add("@FilReadyProd", _dbTempTable.FilReadyProd);
            parameter.Add("@FilRun", _dbTempTable.FilRun);
            parameter.Add("@FilRezerwa4", _dbTempTable.FilRezerwa4);
            parameter.Add("@ErrorCode1", _dbTempTable.ErrorCode1);
            parameter.Add("@ErrorCode2", _dbTempTable.ErrorCode2);
            parameter.Add("@Nr_lini", _dbTempTable.Nr_lini);
            parameter.Add("@Bias", _dbTempTable.Bias);
            parameter.Add("@Time_Stamp_ms", _dbTempTable.Time_Stamp_ms);


            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                cnn.Execute(query, parameter, commandType: System.Data.CommandType.Text);

                Debug.WriteLine(query + " " + connetionString);
                cnn.Close();
                SprawdzDlugoscRichTextBox_info();
                richTextBox_info.Text = _dbTempTable.Time_Stamp.ToString("yyyy-MM-dd hh:mm:ss") + " zapis do bazy: "+ _dbTempTable.Wydajnosc.ToString() + " " + _dbTempTable.L_Opakowan.ToString() + " "+ _dbTempTable.FilRun.ToString() + " " + "\r\n" + richTextBox_info.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udana próba połączenia z bazą ! " + ex.Message);
                SprawdzDlugoscRichTextBox_info();
                richTextBox_info.Text = _dbTempTable.Time_Stamp.ToString("rrrr-MM-dd hh:mm:ss") + " błąd zapisu: " + ex.Message + "\r\n" + richTextBox_info.Text;
            }
        }

        private void SprawdzDlugoscRichTextBox_info()
        {
            if (richTextBox_info.Text.Length > 2000000)
                richTextBox_info.Text = "";
        }

        private void button_licznik_reset_Click(object sender, EventArgs e)
        {
            textBox_licznik.Text = 0.ToString();
        }

        private void timer_Licznik_Tick(object sender, EventArgs e)
        {
            _dbTempTable.L_Opakowan = _dbTempTable.L_Opakowan + (int)(_dbTempTable.Wydajnosc / 3600);
            textBox_licznik.Text = _dbTempTable.L_Opakowan.ToString();
        }
    }
}
