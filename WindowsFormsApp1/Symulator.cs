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
        }

        private void button_start_wydajnosc_Click(object sender, EventArgs e)
        {
            int maxWydajnosc = hScrollBar_wydajnosc.Maximum - hScrollBar_wydajnosc.LargeChange;
            textBox_wydajnosc.Text = maxWydajnosc.ToString();
        }

        private void button_stop_wydajnosc_Click(object sender, EventArgs e)
        {            
            textBox_wydajnosc.Text = hScrollBar_wydajnosc.Minimum.ToString();
        }

        private void hScrollBar_wydajnosc_Scroll(object sender, ScrollEventArgs e)
        {
            _dbTempTable.Wydajnosc = hScrollBar_wydajnosc.Value;            
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
            checkBox_symulacja.Checked = !checkBox_symulacja.Checked;
            if (!checkBox_symulacja.Checked)
            { 
                button_start_symulator.Text = "Start symulacji";
                timer_Symulacja.Stop();
                UstawPolaNaAktywne();
            }
            else
            { 
                button_start_symulator.Text = "Stop symulacji";
                timer_Symulacja.Start();
                UstawPolaNaNieaktywne();
            }

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

                using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
                {
                     sqlite.Insert(daneSerwera);             

                }
                
                ZaczytajDaneDoComboboxa();
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
            using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
            {
                sqlite.Delete(comboBox_serwer.Text);
                ZaczytajDaneDoComboboxa();
                wyczyscPolaDaneSerwera();
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
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;
            string sql = null;            
            connetionString = "Data Source=" + textBox_serwer_adres.Text + ";Initial Catalog="+ textBox_baza.Text +";User ID=" + textBox_serwer_login.Text + "; Password=" + textBox_serwer_haslo.Text;
            sql = string.Format("INSERT INTO TEMP (Time_Stamp,L_Opakowan,Wydajnosc,L_OpAplikator,WydajnoscAplikator,FilTrybCIP,FilRezerwa1,FilRezerwa2,FilRezerwa3,FilSterylizacja,FilReadyProd,FilRun,FilRezerwa4,ErrorCode1,ErrorCode2,Nr_lini,Bias,Time_Stamp_ms,MaxWydajnosc) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})",
                _dbTempTable.Time_Stamp, _dbTempTable.L_Opakowan, _dbTempTable.Wydajnosc, _dbTempTable.L_OpAplikator, _dbTempTable.WydajnoscAplikator, _dbTempTable.FilTrybCIP, _dbTempTable.FilRezerwa1, _dbTempTable.FilRezerwa2, _dbTempTable.FilRezerwa3, _dbTempTable.FilSterylizacja, _dbTempTable.FilReadyProd, _dbTempTable.FilRun, _dbTempTable.FilRezerwa4, _dbTempTable.ErrorCode1, _dbTempTable.ErrorCode2, _dbTempTable.Nr_lini,_dbTempTable.Bias, _dbTempTable.Time_Stamp_ms, _dbTempTable.MaxWydajnosc);
            Debug.WriteLine(connetionString);
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                Debug.WriteLine(sql + " " + connetionString);
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udana próba połączenia z bazą ! " + ex.Message);
            }
        }
    }
}
